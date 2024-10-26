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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai02 : Form
    {
        private Socket sk_listener;
        private Thread thd_server;



        public Bai02()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Bắt đầu một thread mới để tránh khóa giao diện
            thd_server = new Thread(new ThreadStart(StartUnsafeThread));
            thd_server.Start();
        }

        private void StartUnsafeThread()
        {
            try
            {
                // Khởi tạo socket lắng nghe kết nối từ client
                sk_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Any, 8080);

                // Gán socket lắng nghe tới địa chỉ IP và port
                sk_listener.Bind(ipepServer);

                // Bắt đầu lắng nghe, với giá trị backlog là 10 (số kết nối hàng đợi)
                sk_listener.Listen(10);
                AddMessageToListView("Server started, waiting for connections...");

                // Chấp nhận kết nối từ client
                Socket clientSocket = sk_listener.Accept();
                AddMessageToListView("New client connected.");

                // Mảng byte nhận dữ liệu
                byte[] recv = new byte[1024];
                int bytesReceived;
                string text;

                // Nhận dữ liệu từ client
                while (clientSocket.Connected)
                {
                    text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        text += Encoding.UTF8.GetString(recv, 0, bytesReceived);
                    } while (text[text.Length - 1] != '\n'); // Kết thúc khi nhận ký tự xuống dòng

                    // Hiển thị dữ liệu lên ListView (sử dụng phương thức an toàn cho UI)
                    AddMessageToListView(text.TrimEnd('\n'));
                }

                clientSocket.Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                sk_listener?.Close();
            }
        }
        private void AddMessageToListView(string message)
        {
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new MethodInvoker(() => listView1.Items.Add(new ListViewItem(message))));
            }
            else
            {
                listView1.Items.Add(new ListViewItem(message));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đảm bảo đóng socket và dừng thread khi đóng form
            sk_listener.Close();
            thd_server.Abort();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
