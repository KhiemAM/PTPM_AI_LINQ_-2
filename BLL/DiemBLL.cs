using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DiemBLL
    {
        DiemDAL diemDAL = new DiemDAL();
        public DiemBLL() { }

        public List<DiemDTO> listDiemByMaSV(string pMaSV) 
        {
            return diemDAL.listDiem()
                .Where(d => d.MaSinhVien == pMaSV)
                .AsEnumerable()
                .Select(d => new DiemDTO { MaSV = d.MaSinhVien, MaMH = d.MaMonHoc, Diem = (double)d.Diem1})
                .ToList();
        }

        public bool addDiem(Diem diem)
        {
            return diemDAL.addDiem(diem);
        }

        public bool updateDiem(Diem diem)
        {
            return diemDAL.updateDiem(diem);
        }

        public bool deleteDiem(string pMaSV, string pMaMH)
        {
            return diemDAL.deleteDiem(pMaSV, pMaMH);
        }
    }
}
