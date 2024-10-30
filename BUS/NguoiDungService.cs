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
                    .Include(u => u.VaiTro)
                    .FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);
            }
        }

        public void AddUser(NguoiDung user)
        {
            using (var context = new QLThuocContext())
            {
                context.NguoiDungs.Add(user);
                context.SaveChanges();
            }
        }
        public void UpdateUser(NguoiDung user)
        {
            using (var context = new QLThuocContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var context = new QLThuocContext())
            {
                var user = context.NguoiDungs.Find(userId);
                if (user != null)
                {
                    context.NguoiDungs.Remove(user);
                    context.SaveChanges();
                }
            }
        }

    }
}
