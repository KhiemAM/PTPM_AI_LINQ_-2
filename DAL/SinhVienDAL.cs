using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SinhVienDAL
    {
        QLSINHVIENDataContext qlsv = new QLSINHVIENDataContext();
        public SinhVienDAL() { }

        public IQueryable listSinhVienByMaLop(string pMaLop)
        {
            return qlsv.SinhViens.Where(sv => sv.MaLop == pMaLop).Join(qlsv.Lops, sv => sv.TenLop, l => l.TenLop, (sv, l) => new { sv.MaSinhVien, sv.HoTen, sv.NgaySinh, l.TenLop });
        }

    }
}
