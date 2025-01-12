﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SinhVienBLL
    {
        SinhVienDAL sinhVienDAL = new SinhVienDAL();

        public SinhVienBLL() { }

        public IQueryable listSinhVienByMaLop(string pMaLop)
        {
            return sinhVienDAL.listSinhVienByMaLop(pMaLop);
        }
    }
}
