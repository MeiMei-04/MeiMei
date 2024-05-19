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
    public partial class fQlyThucDon : UserControl
    {
        ThucDonRepository thucDonRepository = new ThucDonRepository();
        List<ThucDon> lstThucDon = new List<ThucDon>();
        public fQlyThucDon()
        {
            InitializeComponent();
            fillTableNhanVien();
        }
        void fillTableNhanVien()
        {
            dataGridView1.Rows.Clear();
            lstThucDon = thucDonRepository.getListThucDon();
            foreach (var item in lstThucDon)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.ID;
                dataGridView1.Rows[rowIndex].Cells[1].Value = item.TenMon;
                dataGridView1.Rows[rowIndex].Cells[2].Value = item.DanhMuc;
                dataGridView1.Rows[rowIndex].Cells[3].Value = item.Gia;
                dataGridView1.Rows[rowIndex].Cells[4].Value = item.TrangThai == 1 ? "Vẫn Ăn Được" : "Đã Chết";
            }
        }
        void setForm()
        {   
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtID.Text = selectedRow.Cells[0].Value.ToString();
                txtTenMon.Text = selectedRow.Cells[1].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells[2].Value.ToString();
                txtGia.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            setForm();
        }
        ThucDon getForm()
        {
            ThucDon thucDon = new ThucDon();
            String idstr = txtID.Text;
            if (idstr.Length > 0)
            {
                thucDon.ID = Convert.ToInt32(idstr);
            }
            thucDon.TenMon = txtTenMon.Text;
            thucDon.DanhMuc = comboBox1.SelectedItem.ToString();
            thucDon.Gia = Convert.ToInt32(txtGia.Text);
            return thucDon;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThucDon thucDon = getForm();
            thucDonRepository.create(thucDon);
            fillTableNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThucDon thucDon = getForm();
            thucDonRepository.update(thucDon);
            fillTableNhanVien();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThucDon thucDon = getForm();
            thucDonRepository.delete(thucDon);
            fillTableNhanVien();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtGia.Text = null;
            txtID.Text = null;
            txtTenMon.Text = null;
            comboBox1.SelectedIndex = 0;
        }
    }
}
