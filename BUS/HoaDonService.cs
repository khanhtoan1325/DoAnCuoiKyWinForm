using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonService
    {
        public List<HoaDon> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.HoaDons.ToList();
        }
    }
}
