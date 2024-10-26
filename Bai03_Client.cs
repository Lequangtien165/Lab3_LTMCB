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
        private int port;
        private string serverIP;
        private TcpClient tcpClient;

        public Bai03_Client()
        {
            InitializeComponent();
        }

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

            // Khởi tạo kết nối tới Server
            try
            {
                tcpClient = new TcpClient(serverIP, port);
                rtb_sent_mess.AppendText("Connected.\n");
            }
            catch (Exception ex)
            {
                rtb_sent_mess.AppendText("Error: " + ex.Message + "\n");
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            // Nếu đã client đã thiết lập kết nối thì ...
            if (tcpClient != null && tcpClient.Connected)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(rtb_send_mess.Text))
                    {
                        var result = MessageBox.Show("Your message is currently empty, do you still want to send it?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Hỏi xem nếu người dùng có muốn gửi tin nhắn rỗng hay không?
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                    // Thiết lập NetworkStream để gửi tin nhắn cho Server
                    NetworkStream stream = tcpClient.GetStream();
                    byte[] sendBuffer = Encoding.UTF8.GetBytes(rtb_send_mess.Text);
                    stream.Write(sendBuffer, 0, sendBuffer.Length);
                    rtb_sent_mess.AppendText("Message sent: " + rtb_send_mess.Text + "\n");
                    rtb_send_mess.Text = "";
                }
                catch (Exception ex) // Bắt lỗi
                {
                    rtb_sent_mess.AppendText("Error sending message: " + ex.Message + "\n");
                }
            }
            else // Nếu đối tượng của lớp TCPClient chưa thiết lập kết nối thì hiện lỗi lên richtextbox
            {
                rtb_sent_mess.AppendText("Not connected to server.\n");
            }
        }

        private void Bai03_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close(); // đóng kết nối
            }
        }

        // Xử lý thói quen nhấn phím Enter khi gửi tin nhắn của người dùng, nhưng mà cũng phải thêm tổ hợp shift + Enter để có thể xuống dòng
        private void rtb_send_mess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                if (e.Shift)
                {
                    rtb_send_mess.SelectedText = Environment.NewLine; // cho phép xuống dòng nhiều lần, và cũng tránh được lỗi cách lố 1 dòng ghi sử dụng AppendText("\n")
                }
                else
                {
                    bt_send_Click(sender, EventArgs.Empty);
                }
            }
        }
    }
}
