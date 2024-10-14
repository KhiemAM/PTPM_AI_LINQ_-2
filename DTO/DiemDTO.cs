using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DiemDTO
    {
        private string _MaSV;
        private string _MaMH;
        private double _Diem;

        public DiemDTO() { }

        public string MaSV { get => _MaSV; set => _MaSV = value; }
        public string MaMH { get => _MaMH; set => _MaMH = value; }
        public double Diem { get => _Diem; set => _Diem = value; }
    }
}
