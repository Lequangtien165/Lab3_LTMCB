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
            if(string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.");
                return;
            }
            var password = textBox2.Text;
            if(string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                return;
            }
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
