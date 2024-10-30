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
    public partial class UC_LichSu : UserControl
    {
        private readonly ChiTietHoaDonService chiTietHoaDonService = new ChiTietHoaDonService();
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly ThuocService thuocService = new ThuocService();
        private readonly NhaCungCapService nhaCungCapService = new NhaCungCapService();
        private readonly DonViTinhService donViTinhService = new DonViTinhService();
        private readonly NhomThuocService nhomThuocService = new NhomThuocService();
        private readonly NguoiDungService nguoiDungService = new NguoiDungService();
        public UC_LichSu()
        {
            InitializeComponent();
        }

        private void UC_LichSu_Load(object sender, EventArgs e)
        {
            try
            {
                var listhoadon = hoaDonService.GetAll();
                var listnguoiDung = nguoiDungService.GetAll();

                BridGrip(listhoadon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BridGrip(List<HoaDon> listhoadon)
        {
            dgvlichsu.Rows.Clear();
            foreach(var item in listhoadon)
            {
                int index = dgvlichsu.Rows.Add();
                dgvlichsu.Rows[index].Cells[0].Value = item.MaHoaDon;
                dgvlichsu.Rows[index].Cells[1].Value = item.NguoiDung.HoTen;
                dgvlichsu.Rows[index].Cells[2].Value = item.NgayMua;
                dgvlichsu.Rows[index].Cells[3].Value = item.TongTien;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maHoaDon = txtMaHoaDon.Text.Trim();
                if (string.IsNullOrEmpty(maHoaDon))
                {
                    var listhoadon = hoaDonService.GetAll();
                    BridGrip(listhoadon);
                }
                else
                {
                    var filteredHoaDon = hoaDonService.GetAll().Where(hd => hd.MaHoaDon.Equals(maHoaDon, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (filteredHoaDon.Any())
                    {
                        BridGrip(filteredHoaDon);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn với mã: " + maHoaDon);
                        dgvlichsu.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

    }
}
