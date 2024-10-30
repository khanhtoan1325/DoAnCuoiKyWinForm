using BUS;
using DangNhap.User;
using DLA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DangNhap
{
    public partial class frmNguoiDung : Form
    {
        private readonly NguoiDungService nguoiDungService = new NguoiDungService();
        //private UC_Profile profile;
        private NguoiDung currentUser; // Khai báo biến để lưu người dùng hiện tại

        public frmNguoiDung(NguoiDung user) // Nhận một đối tượng người dùng trong constructor
        {
            InitializeComponent();
            currentUser = user; // Gán đối tượng người dùng cho biến currentUser
        }
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void btnDatThuoc_Click(object sender, EventArgs e)
        {
            uC_DatThuoc1.Visible = true;
            uC_DatThuoc1.BringToFront();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            uC_DatThuoc1.Visible = false;
            uC_GioiThieu1.Visible = true;
            donHang1.Visible = false;
            lichSu1.Visible = false;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DangNhap f1 = new DangNhap();
            f1.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_GioiThieu1.Visible = true;
            uC_GioiThieu1.BringToFront();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            donHang1.Visible = true;
            donHang1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            lichSu1.Visible = true;
            lichSu1.BringToFront();
        }
        public void SetUserName(string fullName)
        {
            txtname.Text = fullName;
        }

        private void uC_Profile1_Load(object sender, EventArgs e)
        {

        }
    }
}
