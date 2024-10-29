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
    public partial class ChatRoomForm : Form
    {
        public ChatRoomForm()
        {
            InitializeComponent();
        }

        IFirebaseClient client;

        private void ChatRoomForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = FirebaseHelper.GetFirebaseClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thiết lập kết nối với DB: {ex}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void bt_join_Click(object sender, EventArgs e)
        {
            // Lấy ID phòng từ TextBox
            string roomId = tb_room_id.Text.Trim();

            // Kiểm tra nếu ID phòng rỗng
            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Vui lòng nhập ID của phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy dữ liệu phòng từ Firebase
                FirebaseResponse response = await client.GetAsync("Rooms/" + roomId);
                RoomDetail roomData = response.ResultAs<RoomDetail>(); // Thay đổi kiểu dữ liệu tùy theo cấu trúc của bạn

                // Kiểm tra nếu phòng tồn tại
                if (roomData != null)
                {
                    // Thông báo thành công và chuyển đến phòng chat
                    MessageBox.Show($"Tham gia thành công vào phòng với ID: {roomId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Gọi phương thức để mở ChatRoomForm hoặc thực hiện hành động chuyển hướng
                    OpenChatRoomForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng với ID đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi khi không thể lấy dữ liệu phòng từ Firebase
                MessageBox.Show($"Lỗi khi tham gia phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức mở ChatRoomForm
        private void OpenChatRoomForm()
        {
            Room clientForm = new Room(tb_room_id.Text.Trim()); // Truyền ID phòng vào client
            clientForm.Show();
            //this.Close();
        }


        private async void bt_create_Click(object sender, EventArgs e)
        {
            // Lấy ID phòng từ TextBox
            string roomId = tb_room_id.Text.Trim();

            // Kiểm tra nếu ID phòng rỗng
            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Vui lòng nhập ID của phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra xem mã phòng đã tồn tại trong database chưa
                FirebaseResponse checkResponse = await client.GetAsync("Rooms/" + tb_room_id.Text);
                if (checkResponse == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ Firebase.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tiếp tục kiểm tra nếu tên người dùng đã tồn tại
                if (checkResponse.Body != "null")
                {
                    MessageBox.Show("Mã phòng đã tồn tại. Vui lòng chọn mã phòng khác khác.", "Mã phòng trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuẩn bị dữ liệu phòng mới
                var roomData = new RoomDetail
                { 
                    RoomId = roomId, 
                    CreatedAt = DateTime.UtcNow.ToString("o") 
                };

                // Đưa dữ liệu phòng lên Firebase
                // Gửi yêu cầu lên Firebase và nhận phản hồi
                SetResponse setResponse = await client.SetAsync("Rooms/" + tb_room_id.Text, roomData);
                RoomDetail result = setResponse.ResultAs<RoomDetail>();

                MessageBox.Show($"Đã tạo phòng với ID: {roomId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi khi không thể thêm phòng vào Firebase
                MessageBox.Show($"Lỗi khi tạo phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
