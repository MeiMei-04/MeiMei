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
    public partial class fquanly : Form
    {
        NhanVien nhanVien = SessionManager.getNhanVien();
        public fquanly()
        {
            InitializeComponent();
            label2.Text = "Nhân Viên: " + nhanVien.HoTen;
            label3.Text = "Chức Vụ: " + nhanVien.ChucVu;
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            fQLNV fQLNV = new fQLNV();
            panel3.Controls.Clear();
            panel3.Controls.Add(fQLNV);
        }

        private void btnQLTHUCDON_Click(object sender, EventArgs e)
        {
            fQlyThucDon fQlyThucDon = new fQlyThucDon();
            panel3.Controls.Clear();
            panel3.Controls.Add(fQlyThucDon);
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            fQlCaLam fQlCaLam = new fQlCaLam();
            panel3.Controls.Clear();
            panel3.Controls.Add(fQlCaLam);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fHoaDon fHoaDon = new fHoaDon();
            panel3.Controls.Clear();
            panel3.Controls.Add(fHoaDon);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var thongbao = MessageBox.Show("Bạn Có Muốn Đăng Xuất Không", "Thông Báo", MessageBoxButtons.YesNo);
            if (thongbao == DialogResult.Yes)
            {
                SessionManager.logout();
                this.Close();
                flogin flogin = new flogin();
                flogin.Show();
            }
        }

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fThongTinNhanVien fThongTinNhanVien = new fThongTinNhanVien();
            panel3.Controls.Clear();
            panel3.Controls.Add(fThongTinNhanVien);
        }
    }
}
