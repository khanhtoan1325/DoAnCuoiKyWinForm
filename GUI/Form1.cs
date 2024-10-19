using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "KhanhToan" && txtPassword.Text == "1325")
            {
                frmAddmin admin = new frmAddmin();
                admin.Show();
                this.Hide();
            }  
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu","Thông Bào",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }    
        }

        private void btnReloat_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        
    }
}
