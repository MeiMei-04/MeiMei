using MeiMei.Model;
using MeiMei.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeiMei.views
{
    public partial class fQLNV : UserControl
    {
        NhanVienRepository nhanVienRepository = new NhanVienRepository();
        private List<NhanVien> lstNhanVien = new List<NhanVien> ();
        public fQLNV()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            fillTableNhanVien();
        }
        void fillTableNhanVien()
        {
            dataGridView1.Rows.Clear();
            lstNhanVien = nhanVienRepository.getListNhanVien();
            foreach (var item in lstNhanVien)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.ID;
                dataGridView1.Rows[rowIndex].Cells[1].Value = item.HoTen;
                dataGridView1.Rows[rowIndex].Cells[2].Value = item.ChucVu;
                dataGridView1.Rows[rowIndex].Cells[3].Value = item.TenDangNhap;
                dataGridView1.Rows[rowIndex].Cells[4].Value = item.CCCD;
                dataGridView1.Rows[rowIndex].Cells[5].Value = item.TrangThai==1?"Còn Sống":"Đã Chết";
            }
        }
        void setForm()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtID.Text = selectedRow.Cells[0].Value.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells[2].Value.ToString();
                txtTenDangNhap.Text = selectedRow.Cells[3].Value.ToString();
                txtCanCuoc.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            setForm();
        }
        NhanVien getForm()
        {
            NhanVien nhanVien = new NhanVien();
            String idstr = txtID.Text;
            if(idstr.Length > 0)
            {
                nhanVien.ID = Convert.ToInt32(idstr);
            }
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.ChucVu = comboBox1.SelectedItem.ToString();
            nhanVien.TenDangNhap = txtTenDangNhap.Text;
            nhanVien.CCCD = txtCanCuoc.Text;
            return nhanVien;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = getForm();
            nhanVienRepository.create(nhanVien);
            fillTableNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = getForm();
            nhanVienRepository.update(nhanVien);
            fillTableNhanVien();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = getForm();
            nhanVienRepository.delete(nhanVien);
            fillTableNhanVien();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtID.Text = null;
            txtCanCuoc.Text = null;
            txtHoTen.Text = null;
            txtTenDangNhap.Text = null;
            comboBox1.SelectedIndex = 0;
        }
    }
}
