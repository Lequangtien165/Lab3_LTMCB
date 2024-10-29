using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        IFirebaseClient client;

        /// <summary>
        /// Sự kiện bấm nút đăng ký
        /// </summary>
        private async void bt_sign_up_Click(object sender, EventArgs e)
        {
            try
            {
                bt_sign_up.Hide();
                bt_sign_up.Enabled = false;

                if (string.IsNullOrEmpty(tb_username.Text) ||
                    string.IsNullOrEmpty(tb_pass.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các thông tin yêu cầu.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                client = FirebaseHelper.GetFirebaseClient();

                if (client == null)
                {
                    MessageBox.Show("Kết nối Firebase thất bại. Vui lòng kiểm tra lại cấu hình.", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem username đã tồn tại trong database chưa
                FirebaseResponse checkResponse = await client.GetAsync("Users/" + tb_username.Text);
                if (checkResponse == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ Firebase.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tiếp tục kiểm tra nếu tên người dùng đã tồn tại
                if (checkResponse.Body != "null")
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.", "Tên đăng nhập trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearInputFields();
                    return;
                }

                lbl_status.Show();

                // Tạo đối tượng User để thêm vào Firebase
                var newUser = new User
                {
                    Username = tb_username.Text,
                    Password = tb_pass.Text, 
                };

                // Gửi yêu cầu lên Firebase và nhận phản hồi
                SetResponse setResponse = await client.SetAsync("Users/" + tb_username.Text, newUser);
                User result = setResponse.ResultAs<User>();

                lbl_status.Hide();
                bt_sign_up.Enabled = true;
                bt_sign_up.Show();

                // Thông báo khi người dùng mới đã được đăng ký thành công
                MessageBox.Show("Đăng ký thành công! Bạn có thể đóng cửa sổ này để quay về cửa sổ Đăng nhập", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa các trường nhập liệu sau khi thành công
                ClearInputFields();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex}", "Cảnh báo lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// /// Hàm xóa các trường nhập liệu
        /// </summary>
        private void ClearInputFields()
        {
            tb_username.Clear();
            tb_pass.Clear();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            lbl_status.Hide();
        }
    }
}
