using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Model
{
    internal class NhanVien
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string CCCD { get; set; }
        public int TrangThai { get; set; }

        // Constructor mặc định
        public NhanVien()
        {
        }

        // Constructor với các tham số
        public NhanVien(int id, string hoten, string chucvu, string tendangnhap, string matkhau, string cccd, int trangthai)
        {
            this.ID = id;
            this.HoTen = hoten;
            this.ChucVu = chucvu;
            this.TenDangNhap = tendangnhap;
            this.MatKhau = matkhau;
            this.CCCD = cccd;
            this.TrangThai = trangthai;
        }
    }
}
