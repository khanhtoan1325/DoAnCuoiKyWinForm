using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhomThuocService
    {
        public List<NhomThuoc> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.NhomThuocs.ToList();
        }
    }
}
