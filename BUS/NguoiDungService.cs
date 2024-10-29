using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BUS
{
    public class NguoiDungService
    {
        public List<NguoiDung> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.NguoiDungs.ToList();
        }
        public NguoiDung GetUserByUsernameAndPassword(string username, string password)
        {
            using (var context = new QLThuocContext())
            {
                return context.NguoiDungs
                    .Include(u => u.VaiTro) // nếu bạn cần vai trò người dùng
                    .FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);
            }
        }
    }
}
