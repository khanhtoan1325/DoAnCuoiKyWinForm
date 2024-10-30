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
using System.Xml.Linq;

namespace DangNhap
{
    public partial class DangNhap : Form
    {
        private readonly VaiTroService vaiTroService = new VaiTroService();
        private readonly NguoiDungService nguoiDungService = new NguoiDungService();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                var user = nguoiDungService.GetUserByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

                if (user != null)
                {
                    if ((int)cbbVaiTro.SelectedValue == user.VaiTro.IDVaiTro)
                    {
                        if (user.VaiTro.TenVaiTro == "Admin")
                        {
                            frmAddmin admin = new frmAddmin();
                            admin.Show();
                        }
                        else
                        {
                            frmNguoiDung frmNguoiDung = new frmNguoiDung();
                            frmNguoiDung.SetUserName(user.HoTen);
                            frmNguoiDung.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Vai trò không hợp lệ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmDangKy frmDangKy = new frmDangKy();
            frmDangKy.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var listVaiTro = vaiTroService.GetAll();
                var listNguoiDung = nguoiDungService.GetAll();

                fillVaiTro(listVaiTro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillVaiTro(List<VaiTro> listVaiTro)
        {
            this.cbbVaiTro.DataSource = listVaiTro;
            this.cbbVaiTro.DisplayMember = "TenVaiTro";
            this.cbbVaiTro.ValueMember = "IDVaiTro";
        }
    }
}
