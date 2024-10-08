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
    public partial class FormMonHoc : Form
    {
        MonHocBLL monHocBLL = new MonHocBLL();
        public FormMonHoc()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Load += FormMonHoc_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dgvMonHoc.SelectionChanged += dgvMonHoc_SelectionChanged;
        }

        void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvMonHoc.SelectedCells.Count > 0)
            {
                txtMaMonHoc.Text = dgvMonHoc.CurrentRow.Cells[0].Value.ToString();
                txtTenMonHoc.Text = dgvMonHoc.CurrentRow.Cells[1].Value.ToString();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            string maMonHoc = txtMaMonHoc.Text;
            if (monHocBLL.deleteMonHoc(maMonHoc))
            {
                MessageBox.Show("Thao tac thanh cong");
                loadMonHoc();
                return;
            }
            MessageBox.Show("Thao tac khong thanh cong");
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.MaMonHoc = txtMaMonHoc.Text;
            mh.TenMonHoc = txtTenMonHoc.Text;
            if(monHocBLL.updateMonHoc(mh))
            {
                MessageBox.Show("Thao tac thanh cong");
                loadMonHoc();
                return;
            }
            MessageBox.Show("Thao tac khong thanh cong");
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            string pMaMonHoc = txtMaMonHoc.Text;
            string ptenMonHoc =  txtTenMonHoc.Text;

            if(!string.IsNullOrEmpty(pMaMonHoc) || !string.IsNullOrEmpty(ptenMonHoc))
            {
                MonHoc mh = new MonHoc();
                mh.MaMonHoc = txtMaMonHoc.Text;
                mh.TenMonHoc = txtTenMonHoc.Text;

                if (monHocBLL.checkPrimaryKey(txtMaMonHoc.Text))
                {
                    MessageBox.Show("Trung khoa chinh");
                    return;
                }

                if (monHocBLL.addMonHoc(mh))
                {
                    MessageBox.Show("Thao tac thanh cong");
                    loadMonHoc();
                    return;
                }
                MessageBox.Show("Thao tac khong thanh cong");
            }
            else
            {
                MessageBox.Show("Ma hoac ten mon hoc khong duoc de trong");
            }
            
        }

        void FormMonHoc_Load(object sender, EventArgs e)
        {
            dgvMonHoc.ClearSelection();
            loadMonHoc();
        }

        public void loadMonHoc()
        {
            dgvMonHoc.DataSource = monHocBLL.listMonHoc();
        }
    }
}
