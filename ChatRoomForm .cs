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

        private void ChatRoomForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string roomCode = textBox1.Text;

            //if (string.IsNullOrEmpty(roomCode))
            //{
            //    MessageBox.Show("Vui lòng nhập mã phòng.");
            //    return;
            //}

            //// Kiểm tra mã phòng có tồn tại không
            //if (DatabaseHelper.JoinRoom(roomCode))
            //{
            //    MessageBox.Show("Đã tham gia thành công phòng chat: " + roomCode);
            //    // Thực hiện logic tham gia phòng chat (ví dụ: mở giao diện chat)
            //}
            //else
            //{
            //    MessageBox.Show("Phòng chat không tồn tại.");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string roomCode = textBox1.Text; // Mã phòng do người dùng nhập
            //int userId = 1; // ID người dùng hiện tại (cần thay đổi theo logic ứng dụng)

            //if (string.IsNullOrEmpty(roomCode))
            //{
            //    MessageBox.Show("Vui lòng nhập mã phòng mới.");
            //    return;
            //}

            //// Tạo phòng chat mới trong cơ sở dữ liệu
            //if (DatabaseHelper.CreateChatRoom(roomCode, userId))
            //{
            //    MessageBox.Show("Đã tạo phòng chat thành công: " + roomCode);
            //}
            //else
            //{
            //    MessageBox.Show("Không thể tạo phòng chat. Mã phòng có thể đã tồn tại.");
            //}
        }
    }
}
