using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietHoaDonService
    {
        public List<ChiTietHoaDon> GettAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.ChiTietHoaDons.ToList();
        }
        public void InsertUpdate(ChiTietHoaDon chiTietHoaDon)
        {
            using (QLThuocContext context = new QLThuocContext())
            {
                var existingEntity = context.ChiTietHoaDons.Find(chiTietHoaDon.IDCTHD);
                if (existingEntity != null)
                {
                    // Update existing entity
                    existingEntity.SoLuong = chiTietHoaDon.SoLuong; // Update other properties as necessary
                    context.SaveChanges();
                }
                else
                {
                    // Add new entity
                    context.ChiTietHoaDons.Add(chiTietHoaDon);
                    context.SaveChanges();
                }
            }
        }
        public void RemoveCTHD(int IDCthd)
        {
            using (QLThuocContext context = new QLThuocContext())
            {
                var chiTietHoaDon = context.ChiTietHoaDons.Find(IDCthd);
                if (chiTietHoaDon != null)
                {
                    context.ChiTietHoaDons.Remove(chiTietHoaDon);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Chi tiết hóa đơn không tồn tại!");
                }
            }
        }
    }
}
