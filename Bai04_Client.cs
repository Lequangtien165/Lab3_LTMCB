using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai04_Client : Form
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _receiveThread;
        private volatile bool _isRunning = true; // Thêm flag để kiểm soát thread

        public Bai04_Client()
        {
            InitializeComponent();
            ConnectToServer(); // Kết nối đến server ngay khi form được mở
        }

        private void ConnectToServer()
        {
            try
            {
                _client = new TcpClient("127.0.0.1", 8080);
                _stream = _client.GetStream();
                _receiveThread = new Thread(ReceiveMessages);
                _receiveThread.Start();
                UpdateChat("Connected to server.");
            }
            catch (SocketException)
            {
                // Hiển thị thông báo nhắc nhở người dùng
                MessageBox.Show("Không thể kết nối với máy chủ. Vui lòng đảm bảo máy chủ đang chạy và lắng nghe.",
                                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Ngắt kết nối và đóng form nếu thao tác thất bại
                _client?.Close();
                _stream = null;
                MessageBox.Show("Hãy đóng Form Client vừa tạo ra và thực hiện lại.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while (_isRunning && _client != null && _stream != null) // Thêm điều kiện kiểm tra
                {
                    if (_stream.DataAvailable)
                    {
                        bytesRead = _stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            UpdateChat(message);
                        }
                    }
                    Thread.Sleep(100); // Thêm delay nhỏ để giảm tải CPU
                }
            }
            catch (Exception ex)
            {
                if (_isRunning) // Chỉ hiện message box nếu chưa đóng form
                {
                    MessageBox.Show($"Lỗi: {ex}", "Cảnh báo lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                _stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gặp lỗi khi gửi tin nhắn: {ex}", "Cảnh báo lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateChat(string message)
        {
            if (listBox_chatboxC.InvokeRequired)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox_chatboxC.Items.Add(message);
                    });
                }
            }
            else
            {
                listBox_chatboxC.Items.Add(message);
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isRunning = false; // Set flag để dừng thread

            try
            {
                if (_stream != null)
                {
                    _stream.Close();
                    _stream = null;
                }

                if (_client != null)
                {
                    _client.Close();
                    _client = null;
                }

                // Đợi thread kết thúc một cách an toàn
                if (_receiveThread != null && _receiveThread.IsAlive)
                {
                    _receiveThread.Join(1000); // Đợi tối đa 1 giây
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu cần
                Console.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string message = $"{textBox_name.Text}: {textBox_message.Text}";
            SendMessage(message);
            textBox_message.Clear();
        }

        private void textBox_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                button_send_Click(sender, EventArgs.Empty);
            }
        }
    }
}
