using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class SinhVien
    {
        string _TenLop;

        public string TenLop
        {
            get { return _TenLop; }
            set { _TenLop = value; }
        }
    }
}
