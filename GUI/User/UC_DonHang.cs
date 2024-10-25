using BUS;
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

namespace DangNhap.User
{
    public partial class UC_DonHang : UserControl
    {
        private readonly HoaDonService hoaDonService = new HoaDonService();

        public UC_DonHang()
        {
            InitializeComponent();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            QRThanhToan qRThanhToan = new QRThanhToan();
            qRThanhToan.Show();
        }

        private void UC_DonHang_Load(object sender, EventArgs e)
        {
            try
            {
                var listHoadon = hoaDonService.GetAll();
                BrindGrip(listHoadon);
            }
            catch(Exception ex)  
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BrindGrip(List<HoaDon> listHoadon)
        {
            dgvDonHang.Rows.Clear();
            foreach(HoaDon item in listHoadon)
            {
                int index = dgvDonHang.Rows.Add(item);
                dgvDonHang.Rows[index].Cells[0].Value = item.MaHoaDon;
                dgvDonHang.Rows[index].Cells[0].Value = item.SoLuongBan;
                dgvDonHang.Rows[index].Cells[0].Value = item.GiaBan;
                dgvDonHang.Rows[index].Cells[0].Value = item.ThanhTien;
            }
        }
    }
}
