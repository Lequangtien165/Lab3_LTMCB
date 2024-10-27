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
    public partial class Bai04 : Form
    {
        public Bai04()
        {
            InitializeComponent();
        }

        private void Bai04_Load(object sender, EventArgs e)
        {

        }

        private void button_openC_Click(object sender, EventArgs e)
        {
            Bai04_Client newC = new Bai04_Client();
            newC.Show();
        }

        private void button_openS_Click(object sender, EventArgs e)
        {
            Bai04_Server newS = new Bai04_Server();
            newS.Show();
        }
    }
}
