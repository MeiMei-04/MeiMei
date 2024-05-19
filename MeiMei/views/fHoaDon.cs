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
    
    public partial class fHoaDon : UserControl
    {
        HoaDonRepository hoadonRepository = new HoaDonRepository(); 
        List<HoaDon> listHoaDon = new List<HoaDon>();   
        public fHoaDon()
        {
            InitializeComponent();
            fillTableNhanVien();
        }
        void fillTableNhanVien()
        {
            dataGridView1.Rows.Clear();
            listHoaDon = hoadonRepository.GetHoaDonListAll();
            foreach (var item in listHoaDon)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.ID;
                dataGridView1.Rows[rowIndex].Cells[1].Value = item.HoTen;
                dataGridView1.Rows[rowIndex].Cells[2].Value = item.TenBan;
                dataGridView1.Rows[rowIndex].Cells[3].Value = item.NgayTao;
                dataGridView1.Rows[rowIndex].Cells[4].Value = item.NgayThanhToan;
                dataGridView1.Rows[rowIndex].Cells[5].Value = item.TongTien;
                dataGridView1.Rows[rowIndex].Cells[6].Value = item.TrangThai == 1 ? "Đang Chờ" : "Đã Thanh Toán";
            }
        }
    }
}
