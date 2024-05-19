using MeiMei.Model;
using MeiMei.Repository;
using MeiMei.util;
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
    public partial class fQlCaLam : UserControl
    {
        CalamRepository calamRepository = new CalamRepository();
        NhanVienRepository nhanVienRepository = new NhanVienRepository();
        private List<Calam> listCaLam = new List<Calam>();
        public fQlCaLam()
        {
            InitializeComponent();
            fillTableCaLam();
            fillCbbNhanVien();
        }
        void fillTableCaLam()
        {
            dataGridView1.Rows.Clear();
            listCaLam = calamRepository.getListCaLam();
            foreach (var item in listCaLam)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.ID;
                dataGridView1.Rows[rowIndex].Cells[1].Value = item.HoTen;
                dataGridView1.Rows[rowIndex].Cells[2].Value = item.NgayLamViec;
                dataGridView1.Rows[rowIndex].Cells[3].Value = item.GioBatDau;
                dataGridView1.Rows[rowIndex].Cells[4].Value = item.GioKetThuc;
                dataGridView1.Rows[rowIndex].Cells[5].Value = item.TrangThai == 1 ? "Còn Sống" : item.TrangThai==2?"Nghỉ Làm":"Đã Làm";
            }
        }
        void fillCbbNhanVien()
        {
            List<NhanVien> list = nhanVienRepository.getListNhanVien();
            comboBox1.Items.Clear();
            foreach (var item in list)
            {
                comboBox1.Items.Add(item.HoTen);
            }
            comboBox1.SelectedIndex = 0;
        }
        private int getIdNhanVien()
        {
            List<NhanVien> list = nhanVienRepository.getListNhanVien();
            int index = comboBox1.SelectedIndex;
            return list[index].ID;
        }
        void setForm()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtID.Text = selectedRow.Cells[0].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells[1].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells[2].Value.ToString();
                dateTimePicker2.Text = selectedRow.Cells[3].Value.ToString();
                dateTimePicker3.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            setForm();
        }
        Calam getForm()
        {
            Calam calam = new Calam();
            String idstr = txtID.Text;
            if (idstr.Length > 0)
            {
                calam.ID = Convert.ToInt32(idstr);
            }
            calam.HoTen = comboBox1.SelectedItem.ToString();
            calam.NhanVienID = getIdNhanVien();
            calam.NgayLamViec = Dateutil.ConvertStringToDateTime(dateTimePicker1.Text);
            calam.GioBatDau = Dateutil.ConvertStringToTimeSpan(dateTimePicker2.Text);
            calam.GioKetThuc = Dateutil.ConvertStringToTimeSpan(dateTimePicker3.Text);
            return calam;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Calam calam = getForm();
            calamRepository.create(calam);
            fillTableCaLam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calam calam = getForm();
            calamRepository.update(calam);
            fillTableCaLam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calam calam = getForm();
            calamRepository.delete(calam);
            fillTableCaLam();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtID.Text = null;
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Text = null;
            dateTimePicker2.Text = null;
            dateTimePicker3.Text = null;
        }
    }
}
