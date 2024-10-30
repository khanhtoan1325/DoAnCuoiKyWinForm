using BUS;
using DLA.Data;
using Guna.UI2.WinForms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DangNhap.User
{
    public partial class UC_DatThuoc : UserControl
    {
        private readonly ChiTietHoaDonService chiTietHoaDonService = new ChiTietHoaDonService();
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly ThuocService thuocService = new ThuocService();
        private readonly NhaCungCapService nhaCungCapService = new NhaCungCapService();
        private readonly DonViTinhService donViTinhService = new DonViTinhService();
        private readonly NhomThuocService nhomThuocService = new NhomThuocService();
        public UC_DatThuoc()
        {
            InitializeComponent();
        }

        private void UC_DatThuoc_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dataGrip);
                var listThuoc = thuocService.GetAll();
                var listNhomThuoc = nhomThuocService.GetAll();
                var listNCC = nhaCungCapService.GetAll();

                fillNhomThuoc(listNhomThuoc);
                BindGrid(listThuoc);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setGridViewStyle(Guna2DataGridView dataGrip)
        {
            dataGrip.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGrip.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dataGrip.BackgroundColor = Color.White;
            dataGrip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void BindGrid(List<Thuoc> listThuoc)
        {
            dataGrip.Rows.Clear();
            foreach(var item in listThuoc)
            {
                int index = dataGrip.Rows.Add();
                dataGrip.Rows[index].Cells[0].Value = item.IDThuoc;
                dataGrip.Rows[index].Cells[1].Value = item.TenThuoc;
                dataGrip.Rows[index].Cells[2].Value = item.GiaBan;
                dataGrip.Rows[index].Cells[3].Value = item.SoLuong;
                dataGrip.Rows[index].Cells[4].Value = item.NhomThuoc.TenNhomThuoc;
                dataGrip.Rows[index].Cells[5].Value = item.NhaCungCap.TenNCC;
                dataGrip.Rows[index].Cells[6].Value = item.HSD;
            }
        }

        private void fillNhomThuoc(List<NhomThuoc> listNhomThuoc)
        {
            this.cbbNhomThuoc.DataSource = listNhomThuoc;
            this.cbbNhomThuoc.DisplayMember = "TenNhomThuoc";
            this.cbbNhomThuoc.ValueMember = "IDNhomThuoc";
        }

        private void dataGrip_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrip.CurrentRow != null)
            {
                DataGridViewRow row = dataGrip.CurrentRow;

                txtTenThuoc.Text = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                txtGiaTien.Text = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
                txtNCC.Text = row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : string.Empty;                
                cbbNhomThuoc.Text = row.Cells[4].Value != null ? row.Cells[4].Value.ToString() : string.Empty;                
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenThuoc = txtTenThuoc.Text.Trim();
                string idnhomthuoc = cbbNhomThuoc.SelectedValue != null ? cbbNhomThuoc.SelectedValue.ToString() : string.Empty;

                var listThuoc = thuocService.GetAll();
                var filteredList = listThuoc.Where(t =>(string.IsNullOrEmpty(tenThuoc) || t.TenThuoc.IndexOf(tenThuoc, StringComparison.OrdinalIgnoreCase)>=0) 
                &&(string.IsNullOrEmpty(idnhomthuoc) || t.NhomThuoc.IDNhomThuoc.ToString() == idnhomthuoc)).ToList();

                BindGrid(filteredList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrip.CurrentRow != null)
                {
                    if (dataGrip.CurrentRow.Cells[0].Value != null &&
                        int.TryParse(dataGrip.CurrentRow.Cells[0].Value.ToString(), out int idThuoc))
                    {
                        if (int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
                        {
                            if (decimal.TryParse(txtGiaTien.Text, out decimal giaBan) &&
                                giaBan > 0)
                            {
                                var chiTietHoaDon = new ChiTietHoaDon
                                {
                                    IDThuoc = idThuoc,
                                    SoLuong = soLuong,
                                    GiaBan = giaBan,
                                };

                                chiTietHoaDonService.Insert(chiTietHoaDon);
                                MessageBox.Show("Thêm thành công thuốc vào giỏ hàng.");
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập giá tiền hợp lệ.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số lượng.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("IDThuoc không hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để thêm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào ChiTietHoaDon: " + ex.Message);
            }
        }
    }
}
