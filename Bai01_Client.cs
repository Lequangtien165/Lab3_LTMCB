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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab03_23521572_LeQuangTien
{
    public partial class Bai01_Client : Form
    {
        public Bai01_Client()
        {
            InitializeComponent();
        }

        Socket client;
        IPEndPoint EP;
        int RemotePort;
        bool IsConnected = false;

        private void Bai01_Client_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connect
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                RemotePort = Convert.ToInt32(textBox2.Text);
                EP = new IPEndPoint(IPAddress.Parse(textBox1.Text), RemotePort);
                MessageBox.Show("Delivered!", "Notification");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please type the server IP and port", "Warning");
                textBox1.Clear();
                textBox1.Clear();
            }

            //Send
            byte[] message = Encoding.UTF8.GetBytes(textBox3.Text);
            client.SendTo(message, EP);

            IsConnected = true;
        }

    }
}
