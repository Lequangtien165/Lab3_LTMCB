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
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
        }

        IFirebaseClient client;

        /// <summary>
        /// Sự kiện bấm nút đăng nhập
        /// </summary>
        private void bt_sign_in_Click(object sender, EventArgs e)
        {
            try
            {
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

                string username = tb_username.Text.Trim();
                string password = tb_pass.Text;

                // Retrieve user data from Firebase
                FirebaseResponse response = client.Get("Users/" + username);
                User user = response.ResultAs<User>(); // Deserialize the data to User object

                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy username.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the password matches
                bool isPasswordValid = user.Password == password;

                if (isPasswordValid)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenChatRoomForm(); // Mở form ChatRoom nếu đăng nhập thành công

                    InitializeServer(); // Mở form Server
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex}", "Cảnh báo lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeServer()
        {
            Bai05_Server bai05_Server = new Bai05_Server();
            bai05_Server.Show();
        }

        /// <summary>
        /// Phương thức mở form giao diện tạo/tham gia phòng chat
        /// </summary>
        private void OpenChatRoomForm()
        {
            ChatRoomForm chatRoomForm = new ChatRoomForm();
            chatRoomForm.Show();
            this.Close();
        }

        /// <summary>
        /// Xử lý sự kiện nhấn vào link label "Đăng ký" thì mở form đăng ký và dấu đi form đăng nhập
        /// </summary>
        private void lbl_to_sign_up_form_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp newForm = new SignUp();
            newForm.FormClosed += (s, args) => this.Show(); // Đăng ký sự kiện FormClosed để hiển thị lại form gốc
            newForm.Show();
            this.Hide();
        }
    }
}
