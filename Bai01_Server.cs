using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai01_Server : Form
    {
        public Bai01_Server()
        {
            InitializeComponent();
        }
        Socket server;
        IPEndPoint EP;
        int RemotePort = 4000;
        int LocalPort;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LocalPort = Convert.ToInt32(textBox1.Text);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                EP = new IPEndPoint(IPAddress.Any, LocalPort);
                server.Bind(EP);
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, RemotePort);

                // Start receiving data asynchronously
                richTextBox1.Text = "Connected, waiting for data...\n";
                StateObject state = new StateObject();
                state.workSocket = server;
                server.BeginReceiveFrom(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, ref remoteEP, new AsyncCallback(receive), state);

                button1.Enabled = false;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please type the server port", "Warning");
                textBox1.Clear();
            }
        }
        void receive(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket server = state.workSocket;
            EndPoint remoteEP = new IPEndPoint(IPAddress.Any, RemotePort);

            int bytesRead = server.EndReceiveFrom(ar, ref remoteEP);
            string ReceivedData = Encoding.UTF8.GetString(state.buffer, 0, bytesRead);
            UpdateChat(ReceivedData);

            // Continue receiving
            server.BeginReceiveFrom(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, ref remoteEP, new AsyncCallback(receive), state);
        }

        void UpdateChat(string data)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                UpdateChatViewCallBack updateChat = new UpdateChatViewCallBack(UpdateChat);
                this.Invoke(updateChat, new object[] { data });
            }
            else
            {

                richTextBox1.AppendText("Data received from Client: " + data + "\r\n");
            }
        }

        public class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
        }
        delegate void UpdateChatViewCallBack(string text);
    }
}
