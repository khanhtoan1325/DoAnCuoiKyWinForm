using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap.User
{
    public partial class UC_DonHang : UserControl
    {
        public UC_DonHang()
        {
            InitializeComponent();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            QRThanhToan qRThanhToan = new QRThanhToan();
            qRThanhToan.Show();
        }
    }
}
