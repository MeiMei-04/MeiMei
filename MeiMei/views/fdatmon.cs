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
    public partial class fdatmon : UserControl
    {
        ThucDonRepository thucDonRepository = new ThucDonRepository();
        ChiTietHoaDonRepository chiTietHoaDonRepository = new ChiTietHoaDonRepository();
        string tenban = null;
        int id = -1;
        int tongtien = 0;
        public fdatmon(string tenban, int id)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.tenban = tenban;
            this.id = id;
            fillChiTietHoaDon();
        }
        void oderThucDon()
        {
            List<ChiTietHoaDon> lst = chiTietHoaDonRepository.getChiTietHoaDonById(this.id);
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if(selectedRow != null)
            {
                int idtd = Convert.ToInt32(selectedRow.Cells[0].Value);
                int gia = Convert.ToInt32(selectedRow.Cells[2].Value);
                int soluong = 1;
                int giatien = 0;
                foreach (var item in lst)
                {
                    if (item.ThucDonID == idtd)
                    {
                        item.SoLuong += soluong;
                        giatien = item.SoLuong * gia;
                        chiTietHoaDonRepository.updateSoLuong(idtd, item.SoLuong, giatien);
                    }
                }
            }
        }
        void fillChiTietHoaDon()
        {
            dataGridView2.Rows.Clear();
            List<ChiTietHoaDon> lst = chiTietHoaDonRepository.getChiTietHoaDonById(this.id);
            if(lst == null)
            {
                return;
            }
            foreach(var item in lst)
            {
                int rowIndex = dataGridView2.Rows.Add();
                dataGridView2.Rows[rowIndex].Cells[0].Value = item.TenMon;
                dataGridView2.Rows[rowIndex].Cells[1].Value = item.SoLuong;
                dataGridView2.Rows[rowIndex].Cells[2].Value = item.DonGia;
                tongtien += item.DonGia;
            }
            label1.Text = "Tổng Tiền: " + tongtien;
        }
        void fillTableThucDon()
        {
            dataGridView1.Rows.Clear();
            string type =  comboBox1.SelectedItem.ToString();
            List<ThucDon> lst = thucDonRepository.getByType(type);
            foreach (var item in lst)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.ID;
                dataGridView1.Rows[rowIndex].Cells[1].Value = item.TenMon;
                dataGridView1.Rows[rowIndex].Cells[2].Value = item.Gia;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillTableThucDon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oderThucDon();
            fillChiTietHoaDon();
        }
    }
}
