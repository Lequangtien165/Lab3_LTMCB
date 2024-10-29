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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            if (DatabaseHelper.RegisterUser(username, password))
            {
                MessageBox.Show("Đăng ký thành công.");
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại.");
            }
        }
    }
}
