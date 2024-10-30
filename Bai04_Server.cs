using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai04_Server : Form
    {
        private TcpListener _server;
        private List<TcpClient> _clients = new List<TcpClient>();
        private Thread _listenerThread;

        public Bai04_Server()
        {
            InitializeComponent();
        }

        private void button_Listen_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        private void StartServer()
        {
            try
            {
                _server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080); // Thay đổi IP thành loopback
                _server.Start();
                _listenerThread = new Thread(ListenForClients);
                _listenerThread.Start();
                UpdateStatus($"Server running on 127.0.0.1:8080");
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Unable to start server on port 8080. It may already be in use.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _isListening = false; // Thêm cờ kiểm soát

        private void ListenForClients()
        {
            _isListening = true;
            while (_isListening)
            {
                try
                {
                    if (_server != null)
                    {
                        // Set timeout cho socket
                        _server.Server.ReceiveTimeout = 1000; // 1 giây
                        _server.Server.SendTimeout = 1000;

                        if (_server.Pending()) // Kiểm tra xem có client đang chờ kết nối không
                        {
                            TcpClient client = _server.AcceptTcpClient();
                            Thread clientThread = new Thread(HandleClientComm);
                            clientThread.Start(client);

                            IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                            string clientInfo = $"New client connected from: {clientEndPoint.Address}:{clientEndPoint.Port}";
                            UpdateStatus(clientInfo);
                        }
                        else
                        {
                            Thread.Sleep(100); // Tránh tiêu tốn CPU
                        }
                    }
                }
                catch (SocketException ex)
                {
                    // Xử lý exception nếu cần
                    if (!_isListening) break; // Thoát nếu đã yêu cầu dừng
                }
            }
        }
        private void HandleClientComm(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
            string clientIP = clientEndPoint.Address.ToString();
            int clientPort = clientEndPoint.Port;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Kiểm tra nếu nhận được thông báo "ClientDisconnected"
                    if (message == "ClientDisconnected")
                    {
                        _clients.Remove(client);
                        UpdateStatus($"{clientIP}:{clientPort} - Client disconnected.");
                        break;
                    }

                    BroadcastMessage(clientIP, clientPort, message);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"{clientIP}:{clientPort} - Error: {ex.Message}");
            }
            finally
            {
                // Đảm bảo client bị loại bỏ khi ngắt kết nối
                if (_clients.Contains(client))
                {
                    _clients.Remove(client);
                    UpdateStatus($"{clientIP}:{clientPort} - Client disconnected.");
                }
                client.Close();
            }
        }

        private void BroadcastMessage(string clientIP, int clientPort, string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            foreach (TcpClient client in _clients)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }

            // Cập nhật trạng thái với thông tin chi tiết
            UpdateStatus($"{clientIP}:{clientPort}: {message}");
        }

        private void UpdateStatus(string message)
        {
            if (listBox_listChat.InvokeRequired)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox_listChat.Items.Add(message);
                    });
                }
            }
            else
            {
                listBox_listChat.Items.Add(message);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _isListening = false; // Đặt cờ để dừng vòng lặp lắng nghe

                if (_server != null)
                {
                    _server.Stop();
                }

                if (_listenerThread != null && _listenerThread.IsAlive)
                {
                    _listenerThread.Join(2000); // Đợi tối đa 2 giây

                    // Nếu thread vẫn chưa kết thúc sau 2 giây, có thể buộc kết thúc
                    if (_listenerThread.IsAlive)
                    {
                        _listenerThread.Abort();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }
    }
}
