using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DonViTinhService
    {
        public List<DonViTinh> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.DonViTinhs.ToList();
        }
    }
}
