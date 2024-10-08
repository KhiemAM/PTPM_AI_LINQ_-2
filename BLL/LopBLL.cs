using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LopBLL
    {
        LopDAL lopDAL = new LopDAL();

        public LopBLL() { }

        public List<Lop> listLopByMaKhoa(string pMaKhoa)
        {
            List<Lop> list = lopDAL.listLop();
            return list.Where(l => l.MaKhoa == pMaKhoa).ToList<Lop>();
        }
    }
}
