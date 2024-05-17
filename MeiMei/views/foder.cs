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
    public partial class foder : UserControl
    {
        HoaDonRepository hoaDonRepository = new HoaDonRepository();
        NhanVien nhanVien = SessionManager.getNhanVien();
        public foder()
        {
            InitializeComponent();
            loadban();
        }
        private void loadban()
        {
            List<HoaDon> list = hoaDonRepository.GetHoaDonList();
            if(list == null)
            {
                return;
            }
            foreach (HoaDon hoaDon in list)
            {
                if (hoaDon.TenBan.Equals(label1.Text))
                {
                    defaultstatustable(label1, label2, panel1);
                }else if (hoaDon.TenBan.Equals(label4.Text))
                {
                    defaultstatustable(label4, label3, panel2);
                }
                else if (hoaDon.TenBan.Equals(label6.Text))
                {
                    defaultstatustable(label6, label5, panel3);
                }
                else if (hoaDon.TenBan.Equals(label8.Text))
                {
                    defaultstatustable(label8, label7, panel4);
                }
                else if (hoaDon.TenBan.Equals(label10.Text))
                {
                    defaultstatustable(label10, label9, panel5);
                }
                else if (hoaDon.TenBan.Equals(label12.Text))
                {
                    defaultstatustable(label12, label11, panel6);
                }
                else if (hoaDon.TenBan.Equals(label14.Text))
                {
                    defaultstatustable(label14, label13, panel7);
                }
                else if (hoaDon.TenBan.Equals(label16.Text))
                {
                    defaultstatustable(label16, label15, panel8);
                }
                else if (hoaDon.TenBan.Equals(label18.Text))
                {
                    defaultstatustable(label18, label17, panel9);
                }
                else if (hoaDon.TenBan.Equals(label20.Text))
                {
                    defaultstatustable(label20, label19, panel10);
                }
                else if (hoaDon.TenBan.Equals(label22.Text))
                {
                    defaultstatustable(label22, label21, panel11);
                }
                else if (hoaDon.TenBan.Equals(label24.Text))
                {
                    defaultstatustable(label24, label23, panel12);
                }
                else if (hoaDon.TenBan.Equals(label26.Text))
                {
                    defaultstatustable(label26, label25, panel13);
                }
                else if (hoaDon.TenBan.Equals(label28.Text))
                {
                    defaultstatustable(label28, label27, panel14);
                }
                else if (hoaDon.TenBan.Equals(label30.Text))
                {
                    defaultstatustable(label30, label29, panel15);
                }
                else if (hoaDon.TenBan.Equals(label32.Text))
                {
                    defaultstatustable(label32, label31, panel16);
                }
                 
            }
        }
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label1, label2, panel1);
        }
        private void oder(Label tenban,Label trangthai,Panel panel)
        {
            var ban = tenban.Text;
            trangthai.Text = "Trạng Thái: Có Khách";
            panel.BackColor = Color.Red;
            int idhd = hoaDonRepository.CreateHoaDon(ban, nhanVien.ID);
            Console.WriteLine(idhd);
            fdatmon demo = new fdatmon(ban, idhd);
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(demo);
        }
        private void defaultstatustable(Label tenban, Label trangthai, Panel panel)
        {
            trangthai.Text = "Trạng Thái: Có Khách";
            panel.BackColor = Color.Red;
        }
        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label4, label3, panel2);
        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label6, label5, panel3);
        }

        private void panel4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label8, label7, panel4);
        }

        private void panel5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label10, label9, panel5);
        }

        private void panel6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label12, label11, panel6);
        }

        private void panel7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label14, label13, panel7);
        }

        private void panel8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label16, label15, panel8);
        }

        private void panel9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label18, label17, panel9);
        }

        private void panel10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label20, label19, panel10);
        }

        private void panel11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label22, label21, panel11);
        }

        private void panel12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label24, label23, panel12);
        }

        private void panel13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label26, label25, panel13);
        }

        private void panel14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label28, label27, panel14);
        }

        private void panel15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label30, label29, panel15);
        }

        private void panel16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            oder(label32, label31, panel16);
        }
    }
}
