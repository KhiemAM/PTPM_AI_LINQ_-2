using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class FormQLDiemSV : Form
    {
        KhoaBLL khoaBLL = new KhoaBLL();
        LopBLL lopBLL = new LopBLL();
        SinhVienBLL sinhVienBLL = new SinhVienBLL();
        public FormQLDiemSV()
        {
            InitializeComponent();
            this.Load += FormQLDiemSV_Load;
            this.cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            this.cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
        }

        void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSinhVien(cboLop.SelectedValue.ToString());
        }

        void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLop(cboKhoa.SelectedValue.ToString());
        }

        void FormQLDiemSV_Load(object sender, EventArgs e)
        {
            loadKhoa();
        }

        public void loadKhoa()
        {
            cboKhoa.DataSource = khoaBLL.listKhoa();
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
        }

        public void loadLop(string pMaKhoa)
        {
            cboLop.DataSource = lopBLL.listLopByMaKhoa(pMaKhoa);
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        public void loadSinhVien(string pMaLop)
        {
            dgvSinhVien.DataSource = sinhVienBLL.listSinhVienByMaLop(pMaLop);
        }
    }
}
