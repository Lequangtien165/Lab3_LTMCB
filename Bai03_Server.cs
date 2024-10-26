using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai03_Server : Form
    {
        /// <summary>
        /// TcpListener để lắng nghe các kết nối đến
        /// </summary>
        private TcpListener tcpListener;

        /// <summary>
        /// Token nguồn để kiểm soát việc hủy các tác vụ đang chạy
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// Số cổng để lắng nghe kết nối
        /// </summary>
        private int port;

        /// <summary>
        /// Địa chỉ IP của server
        /// </summary>
        private IPAddress localIPAddress;

        public Bai03_Server()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện click nút Listen - Bắt đầu lắng nghe kết nối từ client
        /// </summary>
        private async void bt_listen_Click(object sender, EventArgs e)
        {
            try
            {
                // Vô hiệu hóa nút listen để tránh việc người dùng cố tình spam nút này
                bt_listen.Enabled = false;

                // Kiểm tra xem đã nhập đầy đủ các trường thông tin chưa
                if (string.IsNullOrEmpty(tb_IP.Text) ||
                string.IsNullOrEmpty(tb_port.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra tính hợp lệ của địa chỉ IP
                if (!IPAddress.TryParse(tb_IP.Text, out _))
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra tính hợp lệ của số hiệu cổng
                if (!int.TryParse(tb_port.Text, out int port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("Số hiệu cổng không hợp lệ (phải từ 1-65535)", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thiết lập tcpListener lắng nghe trên giao diện {IP Address : Port}
                localIPAddress = IPAddress.Parse(tb_IP.Text);
                tcpListener = new TcpListener(localIPAddress, port);
                tcpListener.Start();
                AppendToRichTextBox($"Server đang lắng nghe tại {localIPAddress}:{port}\n");

                // Tạo một cancel token để có thể kiểm soát/dừng các task một cách "gracefully"
                // Code có thể chạy được mà không cần CancellationToken, nhưng việc sử dụng nó là 
                // best practice khi làm việc với async/await và network programming
                cts = new CancellationTokenSource();
                await Task.Run(() => ListenForClients(cts.Token));
            }
            catch (Exception ex)
            {
                AppendToRichTextBox($"Lỗi khi khởi động server: {ex.Message}\n");
            }
            finally
            {
                bt_listen.Enabled = true;
            }
        }

        /// <summary>
        /// Phương thức lắng nghe liên tục các kết nối từ client
        /// </summary>
        /// <param name="token">Token để kiểm soát việc hủy task</param>
        private async Task ListenForClients(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // Chấp nhận kết nối từ client
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    AppendToRichTextBox("Client đã kết nối.\n");

                    // Gọi phương thức xử lý giao tiếp với client và bỏ qua kết quả trả về của nó.
                    // "_" là một placeholder: C# cho phép sử dụng _ để nhận kết quả trả về mà không cần sử dụng nó,
                    // rất hữu ích khi gọi các phương thức không quan trọng việc lưu lại giá trị trả về.

                    // Lưu ý: Dòng này sẽ không tự động tạo một task hay luồng mới. Nếu muốn chạy HandleClientComm
                    // trong một task riêng, cần dùng Task.Run để tạo luồng riêng cho tác vụ này.
                    _ = HandleClientComm(client, token);
                }
            }
            catch (OperationCanceledException)
            {
                // Bắt ngoại lệ khi server bị dừng có chủ ý
                AppendToRichTextBox("Server đã dừng lắng nghe.\n");
            }
            catch (Exception ex)
            {
                AppendToRichTextBox($"Lỗi trong quá trình lắng nghe: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Xử lý giao tiếp với một client cụ thể
        /// </summary>
        /// <param name="client">TcpClient đã được kết nối</param>
        /// <param name="token">Token để kiểm soát việc hủy task</param>
        private async Task HandleClientComm(TcpClient client, CancellationToken token)
        {
            try
            {
                // Sử dụng using để đảm bảo giải phóng tài nguyên
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Đọc dữ liệu từ client cho đến khi client ngắt kết nối hoặc server dừng
                    while (!token.IsCancellationRequested &&
                           (bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token)) != 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        AppendToRichTextBox($"Đã nhận: {message}\n");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Bỏ qua ngoại lệ này vì nó xảy ra khi server dừng có chủ ý
            }
            catch (Exception ex)
            {
                AppendToRichTextBox($"Lỗi: {ex.Message}\n");
            }
            finally
            {
                AppendToRichTextBox("Client đã ngắt kết nối.\n");
            }
        }

        /// <summary>
        /// Phương thức cập nhật giao diện một cách an toàn đa luồng
        /// Sử dụng BeginInvoke khi được gọi từ thread không phải UI
        /// </summary>
        /// <param name="text">Văn bản cần hiển thị</param>
        private void AppendToRichTextBox(string text)
        {
            if (rtb_rcv_mess.InvokeRequired)
            {
                // Chuyển việc gọi hàm sang UI thread
                rtb_rcv_mess.BeginInvoke(new Action<string>(AppendToRichTextBox), text);
            }
            else
            {
                rtb_rcv_mess.AppendText(text);
            }
        }

        /// <summary>
        /// Dừng server và giải phóng tài nguyên
        /// </summary>
        private void StopServer()
        {
            // Hủy các tác vụ đang chạy
            cts?.Cancel();
            // Dừng lắng nghe kết nối mới
            tcpListener?.Stop();
            AppendToRichTextBox("Server đã dừng.\n");
        }

        /// <summary>
        /// Xử lý sự kiện đóng form
        /// </summary>
        private void Bai03_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }
    }
}