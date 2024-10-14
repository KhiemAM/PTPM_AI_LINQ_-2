using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class MonHocBLL
    {
        MonHocDAL monHocDAL = new MonHocDAL();
        public MonHocBLL()
        {

        }


        public List<MonHoc> listMonHoc()
        {
            return monHocDAL.listMonHoc();
        }

        public bool addMonHoc(MonHoc mh)
        {
            return monHocDAL.addMonHoc(mh);
        }

        public bool updateMonHoc(MonHoc mh)
        {
            return monHocDAL.updateMonHoc(mh);
        }

        public bool deleteMonHoc(string pMaMonHoc)
        {
            return monHocDAL.deleteMonHoc(pMaMonHoc);
        }

        public bool checkPrimaryKey(string pMaMH)
        {
            return monHocDAL.checkPrimaryKey(pMaMH);
        }
    }
}
