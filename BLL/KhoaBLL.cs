using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class KhoaBLL
    {
        KhoaDAL khoaDAL = new KhoaDAL();
        public KhoaBLL() { }

        public List<Khoa> listKhoa()
        {
            return khoaDAL.listKhoa();
        }
    }
}
