using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiemDAL
    {
        QLSINHVIENDataContext qlsv = new QLSINHVIENDataContext();
        public DiemDAL() { }

        public List<Diem> listDiem()
        {
            return qlsv.Diems.Select(d => d).ToList<Diem>();
        }


        public bool addDiem(Diem diem)
        {
            try
            {
                qlsv.Diems.InsertOnSubmit(diem);
                qlsv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateDiem(Diem diem)
        {
            try
            {
                Diem d = qlsv.Diems.Where(p => p.MaSinhVien == diem.MaSinhVien && p.MaMonHoc == diem.MaMonHoc).FirstOrDefault();
                d.Diem1 = diem.Diem1;
                qlsv.SubmitChanges();
                return true;
            }catch { return false; }
        }

        public bool deleteDiem(string pMaSV, string pMaMH)
        {
            try
            {
                Diem d = qlsv.Diems.Where(p => p.MaSinhVien == pMaSV && p.MaMonHoc == pMaMH).FirstOrDefault();
                qlsv.Diems.DeleteOnSubmit(d);
                qlsv.SubmitChanges();
                return true;
            }catch { return false; }
        }
    }
}
