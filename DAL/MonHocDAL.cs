using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class MonHocDAL 
    {
        QLSINHVIENDataContext qlsv = new QLSINHVIENDataContext();
        public MonHocDAL()
        {

        }


        public IQueryable listMonHoc()
        {
            return qlsv.MonHocs.Select(mh => mh);
        }

        public bool addMonHoc(MonHoc mh)
        {
            try
            {
                qlsv.MonHocs.InsertOnSubmit(mh);
                qlsv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateMonHoc(MonHoc mh)
        {
            try
            {
                MonHoc monHoc = qlsv.MonHocs.Where(m => m.MaMonHoc == mh.MaMonHoc).FirstOrDefault();
                monHoc.TenMonHoc = mh.TenMonHoc;
                qlsv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteMonHoc(string pMaMonHoc)
        {
            try
            {
                MonHoc monHoc = qlsv.MonHocs.Where(mh => mh.MaMonHoc == pMaMonHoc).FirstOrDefault();
                qlsv.MonHocs.DeleteOnSubmit(monHoc);
                qlsv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool checkPrimaryKey(string pMaMH)
        {
            MonHoc mh = qlsv.MonHocs.Where(m => m.MaMonHoc == pMaMH).FirstOrDefault();
            if(mh != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
