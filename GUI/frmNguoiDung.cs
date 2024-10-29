<<<<<<< HEAD
﻿using BUS;
using DangNhap.User;
=======
﻿using DangNhap.User;
>>>>>>> e0dc7c3ece99bee22186e2e63e1b22415e82d051
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
    public partial class frmNguoiDung : Form
    {
<<<<<<< HEAD
        private readonly NguoiDungService nguoiDungService = new NguoiDungService();
=======
>>>>>>> e0dc7c3ece99bee22186e2e63e1b22415e82d051
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
<<<<<<< HEAD
            DangNhap f1 = new DangNhap();
=======
            Form1 f1 = new Form1();
>>>>>>> e0dc7c3ece99bee22186e2e63e1b22415e82d051
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
    }
}
