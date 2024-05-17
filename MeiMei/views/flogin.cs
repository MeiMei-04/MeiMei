
using MeiMei.Model;
using MeiMei.Repository;
using MeiMei.util;
using MeiMei.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeiMei
{
    public partial class flogin : Form
    {
        NhanVienRepository NhanVienRepository = new NhanVienRepository();
        public flogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var thongbao = MessageBox.Show("Bạn Có Muốn Thoát Không","Thông Báo",MessageBoxButtons.YesNo);
            if(thongbao == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var tendangnhap = txtTenDangNhap.Text;
            var matkhau = txtMatKhau.Text;
            NhanVien nv = NhanVienRepository.getNhanVien(tendangnhap, matkhau);
            if (nv != null)
            {
                SessionManager.setNhanVien(nv);
                var chucvu = nv.ChucVu;
                this.Hide();
                if (chucvu.Equals("Nhân Viên"))
                {
                    fnhanvien fnhanvien = new fnhanvien();
                    fnhanvien.ShowDialog();
                }
                else if (chucvu.Equals("Quản lý"))
                {
                    fquanly fquanly = new fquanly();
                    fquanly.ShowDialog();
                }
            }
        }
    }
}
