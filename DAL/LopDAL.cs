using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LopDAL
    {
        QLSINHVIENDataContext qlsv = new QLSINHVIENDataContext();

        public LopDAL() { }

        public List<Lop> listLop()
        {
            return qlsv.Lops.Select(l => l).ToList<Lop>();
        }
    }
}
