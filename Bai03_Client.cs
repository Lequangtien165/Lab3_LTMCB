using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai03_Client : Form
    {
        private int port; // Số hiệu cổng của server
        private string serverIP; // Địa chỉ IP của server
        private TcpClient tcpClient; // Đối tượng TcpClient để kết nối tới server

        public Bai03_Client()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Phương thức xử lý sự kiện khi nhấn nút Connect.
        /// Kiểm tra các thông tin IP và cổng hợp lệ, sau đó tạo kết nối đến server.
        /// </summary>
        /// <param name="sender">Nguồn sự kiện</param>
        /// <param name="e">Thông tin sự kiện</param>
        private void bt_connect_Click(object sender, EventArgs e)
        {
            // Kiểm tra các địa chỉ IP và số hiệu cổng đã được nhập vào chưa
            if (string.IsNullOrEmpty(tb_IP.Text) ||
                string.IsNullOrEmpty(tb_port.Text))
            {
                MessageBox.Show("Please enter all required information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra địa chỉ IP hợp lệ
            if (!IPAddress.TryParse(tb_IP.Text, out _))
            {
                MessageBox.Show("Invalid IP Address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số hiệu cổng hợp lệ
            if (!int.TryParse(tb_port.Text, out port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Invalid port number (must be between 1-65535)", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            serverIP = tb_IP.Text;

            try
            {
                tcpClient = new TcpClient(serverIP, port);
                rtb_sent_mess.AppendText("Connected.\n"); // Xác nhận kết nối thành công
            }
            catch (Exception ex)
            {
                rtb_sent_mess.AppendText("Error: " + ex.Message + "\n"); // Thông báo lỗi nếu kết nối thất bại
            }
        }

        /// <summary>
        /// Phương thức xử lý sự kiện khi nhấn nút Send.
        /// Kiểm tra kết nối, sau đó gửi tin nhắn nhập vào đến server và hiển thị trên giao diện.
        /// </summary>
        /// <param name="sender">Nguồn sự kiện</param>
        /// <param name="e">Thông tin sự kiện</param>
        private void bt_send_Click(object sender, EventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                // Kiểm tra nếu đã kết nối thì mới cho phép gửi tin nhắn
                if (tcpClient != null && tcpClient.Connected)
                {
                    try
                    {
                        // Kiểm tra xem tin nhắn có rỗng không
                        if (string.IsNullOrWhiteSpace(rtb_send_mess.Text))
                        {
                            var result = MessageBox.Show("Your message is currently empty, do you still want to send it?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            // Nếu người dùng chọn No, hủy việc gửi tin nhắn
                            if (result == DialogResult.No)
                            {
                                return;
                            }
                        }

                        // Thiết lập NetworkStream để gửi tin nhắn cho Server
                        NetworkStream stream = tcpClient.GetStream();
                        byte[] sendBuffer = Encoding.UTF8.GetBytes(rtb_send_mess.Text);
                        stream.Write(sendBuffer, 0, sendBuffer.Length); // Gửi dữ liệu tới server
                        rtb_sent_mess.AppendText("Message sent: " + rtb_send_mess.Text + "\n"); // Hiển thị tin nhắn đã gửi trên giao diện
                        rtb_send_mess.Text = ""; // Xóa nội dung trong hộp gửi tin nhắn sau khi gửi
                    }
                    catch (Exception ex) // Bắt lỗi khi gửi tin nhắn không thành công
                    {
                        rtb_sent_mess.AppendText("Error sending message: " + ex.Message + "\n");
                    }
                }
                else // Thông báo lỗi nếu chưa kết nối tới server
                {
                    rtb_sent_mess.AppendText("Not connected to server.\n");
                }
            }
        }

        /// <summary>
        /// Phương thức xử lý sự kiện khi form đóng.
        /// Đảm bảo rằng kết nối TCP được đóng khi người dùng đóng form.
        /// </summary>
        /// <param name="sender">Nguồn sự kiện</param>
        /// <param name="e">Thông tin sự kiện</param>
        private void Bai03_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close(); // Đóng kết nối khi form đóng
            }
        }

        /// <summary>
        /// Phương thức xử lý sự kiện nhấn phím trong hộp tin nhắn.
        /// Cho phép người dùng nhấn Enter để gửi tin nhắn hoặc Shift + Enter để xuống dòng.
        /// </summary>
        /// <param name="sender">Nguồn sự kiện</param>
        /// <param name="e">Thông tin sự kiện phím</param>
        private void rtb_send_mess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn hành vi mặc định của phím Enter

                if (e.Shift)
                {
                    rtb_send_mess.SelectedText = Environment.NewLine; // Xuống dòng nếu nhấn Shift + Enter
                }
                else
                {
                    bt_send_Click(sender, EventArgs.Empty); // Gửi tin nhắn nếu chỉ nhấn Enter
                }
            }
        }
    }
}
