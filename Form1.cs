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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
               
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bai01_Client client = new Bai01_Client();
            client.Show();
            Bai01_Server server = new Bai01_Server();
            server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai02 bai02 = new Bai02();
            bai02.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Bai03_Client client = new Bai03_Client();
            client.Show();

            Bai03_Server server = new Bai03_Server();
            server.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }   
    }
}
