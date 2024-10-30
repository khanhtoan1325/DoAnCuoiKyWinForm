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
                    existingEntity.SoLuong = chiTietHoaDon.SoLuong;
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
        public void Insert(ChiTietHoaDon chiTietHoaDon)
        {
            using (QLThuocContext context = new QLThuocContext())
            {
                try
                {
                    var existingRecord = context.ChiTietHoaDons
                        .FirstOrDefault(c => c.IDThuoc == chiTietHoaDon.IDThuoc && c.IDHoaDon == chiTietHoaDon.IDHoaDon);

                    if (existingRecord == null)
                    {
                        context.ChiTietHoaDons.Add(chiTietHoaDon);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Chi tiết hóa đơn đã tồn tại.");
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    // Lấy chi tiết lỗi xác thực
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(e => e.ValidationErrors)
                        .Select(e => $"Property: {e.PropertyName}, Error: {e.ErrorMessage}");

                    // Kết hợp các thông báo lỗi
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    throw new Exception("Lỗi xác thực: " + fullErrorMessage);
                }
            }
        }
        public void Update(ChiTietHoaDon chiTietHoaDon)
        {
            using (QLThuocContext context = new QLThuocContext())
            {
                var existingEntity = context.ChiTietHoaDons.Find(chiTietHoaDon.IDCTHD);
                if (existingEntity != null)
                {
                    // Cập nhật bản ghi hiện có
                    existingEntity.SoLuong = chiTietHoaDon.SoLuong;
                    existingEntity.GiaBan = chiTietHoaDon.GiaBan;
                    existingEntity.DonVi = chiTietHoaDon.DonVi;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy bản ghi chi tiết hóa đơn để cập nhật.");
                }
            }
        }
    }
}
