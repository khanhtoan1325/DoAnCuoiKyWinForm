using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThuocService
    {
        public List<Thuoc> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.Thuocs.ToList();
        }

        public List<Thuoc> GetAllNhomThuoc()
        {
            QLThuocContext context = new QLThuocContext();
            return context.Thuocs.Where(p => p.IDNhomThuoc == null ).ToList();
        }

        public Thuoc FinbyID(int IDThuoc)
        {
            QLThuocContext context = new QLThuocContext();  
            return context.Thuocs.FirstOrDefault(p => p.IDThuoc == IDThuoc);
        }

        public void InsertUpdate(Thuoc thuoc)
        {
            QLThuocContext context = new QLThuocContext();
            context.Thuocs.Add(thuoc);
            context.SaveChanges();
        }

        public void AddThuoc(Thuoc thuoc)
        {
            QLThuocContext context = new QLThuocContext();
            if (thuoc != null)
            {
                throw new ArgumentException(nameof(thuoc));
            }
            context.Thuocs.Add(thuoc);
            context.SaveChanges();
        }

        public void RemoveThuoc(int IDThuoc)
        {
            using (QLThuocContext context = new QLThuocContext())
            {
                var thuoc = context.Thuocs.Find(IDThuoc);
                if (thuoc != null)
                {
                    context.Thuocs.Remove(thuoc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Thuốc không tồn tại!");
                }
            }
        }
    }
}
