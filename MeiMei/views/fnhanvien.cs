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

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fThongTinNhanVien fThongTinNhanVien =  new fThongTinNhanVien();
            panel3.Controls.Clear();
            panel3.Controls.Add(fThongTinNhanVien);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //String url = "https://userdhieu.id.vn/";
            //webOpenutil.OpenUrl(url);
            String url = "C:\\Users\\Hieu\\Desktop\\MeiMei\\web\\index.html";
            webOpenutil.OpenHtmlFileInBrowser(url);
        }
    }
}
