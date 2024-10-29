using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class VaiTroService
    {
        public List<VaiTro> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.VaiTroes.ToList();
        }
    }
}
