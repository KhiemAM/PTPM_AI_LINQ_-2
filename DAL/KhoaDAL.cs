using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhoaDAL
    {
        QLSINHVIENDataContext qlsv = new QLSINHVIENDataContext();
        public KhoaDAL() { }

        public List<Khoa> listKhoa()
        {
            return qlsv.Khoas.Select(k => k).ToList<Khoa>();
        }
    }
}
