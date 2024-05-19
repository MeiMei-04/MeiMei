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
    public partial class fThongTinNhanVien : UserControl
    {
        NhanVien nhanVien = SessionManager.getNhanVien();
        CalamRepository calamRepository = new CalamRepository();
        NhanVienRepository nhanVienRepository = new NhanVienRepository();
        Calam calam = new Calam();
        public fThongTinNhanVien()
        {
            InitializeComponent();
            fillThongTin();


        }
        void fillThongTin()
        {
            calam = calamRepository.getCalamByIdNv(nhanVien.ID);
            label2.Text = "Họ Tên: " + nhanVien.HoTen;
            label7.Text = "Căn Cước: " + nhanVien.CCCD;
            label3.Text = "Ngày Làm Việc: " + calam.NgayLamViec;
            label4.Text = "Giờ Bắt Đầu: " + calam.GioBatDau;
            label5.Text = "Giờ Kết Thúc: " + calam.GioKetThuc;
            if(calam.TrangThai == 1)
            {
                label6.Text = "Chưa Làm";
            }else
            {
                label6.Text = "Đã Làm";
            }
        }
        static bool IsCurrentTimeWithinRange(TimeSpan start, TimeSpan end)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            if (start <= end)
            {
                return currentTime >= start && currentTime <= end;
            }
            else
            {
                return currentTime >= start || currentTime <= end;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsCurrentTimeWithinRange(calam.GioBatDau, calam.GioKetThuc)){
                calamRepository.checkin(nhanVien.ID);
                fillThongTin();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                if(textBox1.Text == textBox2.Text)
                {
                    nhanVienRepository.changePass(nhanVien.ID, textBox1.Text);
                }
            }
        }
    }
}
