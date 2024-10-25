using DLA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCapService
    {
        public List<NhaCungCap> GetAll()
        {
            QLThuocContext context = new QLThuocContext();
            return context.NhaCungCaps.ToList();
        }
    }
}
