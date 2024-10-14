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
        DiemBLL diemBLL = new DiemBLL();
        MonHocBLL monHocBLL = new MonHocBLL();
        public FormQLDiemSV()
        {
            InitializeComponent();
            this.Load += FormQLDiemSV_Load;
            this.cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            this.cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            this.dgvSinhVien.SelectionChanged += DgvSinhVien_SelectionChanged;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnClose.Click += BtnClose_Click;
            this.dgvDiem.SelectionChanged += DgvDiem_SelectionChanged;
        }

        private void DgvDiem_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiem.SelectedRows.Count > 0)
            {
                txtMaSV.Text = dgvDiem.CurrentRow.Cells[0].Value.ToString();
                cboMonHoc.Text = dgvDiem.CurrentRow.Cells[1].Value.ToString();
                txtDiem.Text = dgvDiem.CurrentRow.Cells[2].Value.ToString();
            }    
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Diem diem = new Diem();
            diem.MaSinhVien = txtMaSV.Text;
            diem.MaMonHoc = cboMonHoc.SelectedValue.ToString();
            diem.Diem1 = double.Parse(txtDiem.Text);
            if (diemBLL.updateDiem(diem))
            {
                MessageBox.Show("Thao tác thành công");
                loadDiem(txtMaSV.Text);
                return;
            }
            else
            {
                MessageBox.Show("Thao tác không thành công");
                return;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string pMaSV = txtMaSV.Text;
            string pMaMH = cboMonHoc.SelectedValue.ToString();

            if(diemBLL.deleteDiem(pMaSV, pMaMH))
            {
                MessageBox.Show("Thao tác thành công");
                loadDiem(txtMaSV.Text);
                return;
            }    
            else
            {
                MessageBox.Show("Thao tác không thành công");
                return;
            }    
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Diem diem = new Diem();
            diem.MaSinhVien = txtMaSV.Text;
            diem.MaMonHoc = cboMonHoc.SelectedValue.ToString();
            diem.Diem1 = double.Parse(txtDiem.Text);
            if(diemBLL.addDiem(diem))
            {
                MessageBox.Show("Thao tác thành công");
                loadDiem(txtMaSV.Text);
                return;
            }
            else
            {
                MessageBox.Show("Thao tác không thành công");
                return;
            }    
        }

        private void DgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvSinhVien.SelectedRows.Count > 0)
            {
                loadDiem(dgvSinhVien.CurrentRow.Cells[0].Value.ToString());
            }    
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
            loadMonHoc();
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

        public void loadDiem(string pMaSV)
        {
            dgvDiem.DataSource = diemBLL.listDiemByMaSV(pMaSV);

        }

        public void loadMonHoc()
        {
            cboMonHoc.DataSource = monHocBLL.listMonHoc();
            cboMonHoc.DisplayMember = "TenMonHoc";
            cboMonHoc.ValueMember = "MaMonHoc";
        }
    }
}
