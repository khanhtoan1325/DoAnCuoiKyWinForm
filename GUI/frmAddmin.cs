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
    public partial class frmAddmin : Form
    {
        private void frmAddmin_Load(object sender, EventArgs e)
        {
            uC_Dashbord1.Visible = false;
            uC_KhoThuoc1.Visible = false;
            
        }
        public frmAddmin()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_Dashbord1.Visible = true;
            uC_Dashbord1.BringToFront();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_KhoThuoc1.Visible = true;
            uC_KhoThuoc1 .BringToFront();
        }

        
    }
}
