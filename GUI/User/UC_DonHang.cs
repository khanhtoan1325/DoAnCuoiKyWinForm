using BUS;
using DLA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DangNhap.User
{
    public partial class UC_DonHang : UserControl
    {
        private readonly ChiTietHoaDonService chiTietHoaDonService = new ChiTietHoaDonService();
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly ThuocService thuocService = new ThuocService();
        private readonly NhaCungCapService nhaCungCapService = new NhaCungCapService();
        private readonly DonViTinhService donViTinhService = new DonViTinhService();
        private readonly NhomThuocService nhomThuocService = new NhomThuocService();
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
                var listhoadon = hoaDonService.GetAll();
                var listcthd = chiTietHoaDonService.GettAll();
                var listthuoc = thuocService.GetAll();
                var listDVT = donViTinhService.GetAll();
                var listNcc = nhaCungCapService.GetAll();
                var listNhomthuoc = nhomThuocService.GetAll();

                dgvDonHang.Columns[4].ReadOnly = false;
                for (int i = 0; i < dgvDonHang.Columns.Count; i++)
                {
                    if (i != 4) 
                    {
                        dgvDonHang.Columns[i].ReadOnly = true;
                    }
                }

                BrindGrip(listcthd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BrindGrip(List<ChiTietHoaDon> listcthd)
        {
            dgvDonHang.Rows.Clear();
            foreach(var item in listcthd)
            {
                int index = dgvDonHang.Rows.Add();
                dgvDonHang.Rows[index].Cells[0].Value = item.Thuoc.TenThuoc;
                dgvDonHang.Rows[index].Cells[1].Value = item.Thuoc.NhomThuoc.TenNhomThuoc;
                dgvDonHang.Rows[index].Cells[2].Value = item.Thuoc.NhaCungCap.TenNCC;
                dgvDonHang.Rows[index].Cells[3].Value = item.Thuoc.GiaBan;
                dgvDonHang.Rows[index].Cells[4].Value = item.SoLuong;
                dgvDonHang.Rows[index].Cells[5].Value = item.Thuoc.DonViTinh.TenDVT;
                dgvDonHang.Rows[index].Cells[6].Value = item.IDCTHD;
            }
        }

        private void dgvDonHang_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow != null)
            {
                DataGridViewRow row = dgvDonHang.CurrentRow;

                txtTenThuoc.Text = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                txtSoLuong.Text = row.Cells[4].Value != null ? row.Cells[4].Value.ToString() : string.Empty;
                txtGiaTien.Text = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;
                txtNCC.Text = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
                txtNT.Text = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow != null)
            {
                DataGridViewRow row = dgvDonHang.CurrentRow;

                if (int.TryParse(txtSoLuong.Text, out int newQuantity))
                {
                    row.Cells[4].Value = newQuantity;
                    var chiTietHoaDonId = (int)row.Cells[6].Value;
                    var chiTietHoaDon = chiTietHoaDonService.GettAll().FirstOrDefault(x => x.IDCTHD == chiTietHoaDonId);

                    if (chiTietHoaDon != null)
                    {
                        chiTietHoaDon.SoLuong = newQuantity;
                        chiTietHoaDonService.InsertUpdate(chiTietHoaDon);
                        MessageBox.Show("Cập nhật thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin chi tiết hóa đơn.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow != null)
            {
                var chiTietHoaDonId = (int)dgvDonHang.CurrentRow.Cells[6].Value;
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        chiTietHoaDonService.RemoveCTHD(chiTietHoaDonId);
                        dgvDonHang.Rows.Remove(dgvDonHang.CurrentRow);
                        MessageBox.Show("Xóa thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.");
            }
        }

    }
}
