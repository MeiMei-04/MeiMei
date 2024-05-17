using MeiMei.Model;
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
    public partial class fnhanvien : Form
    {
        NhanVien nhanVien = SessionManager.getNhanVien();
        public fnhanvien()
        {
            InitializeComponent();
            label2.Text = "Nhân Viên: " + nhanVien.HoTen;
            label3.Text = "Chức Vụ: " + nhanVien.ChucVu;
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            foder foder = new foder();
            panel3.Controls.Clear();
            panel3.Controls.Add(foder);
        }
    }
}
