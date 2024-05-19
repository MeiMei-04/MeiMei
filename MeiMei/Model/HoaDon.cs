using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Model
{
    internal class HoaDon
    {
        public int ID { get; set; }
        public string TenBan { get; set; }
        public int NhanVienID { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public int TongTien { get; set; }
        public int TrangThai { get; set; }

        // Constructor mặc định
        public HoaDon()
        {
            this.NgayTao = DateTime.Now; // Đặt ngày tạo là ngày hiện tại mặc định
            this.TongTien = 0; // Giá trị mặc định cho tổng tiền
        }

        // Constructor với các tham số
        public HoaDon(int id, string tenban, int id_nv, DateTime ngaytao, DateTime? ngaythanhtoan, int tongtien, int trangthai)
        {
            this.ID = id;
            this.TenBan = tenban;
            this.NhanVienID = id_nv;
            this.NgayTao = ngaytao;
            this.NgayThanhToan = ngaythanhtoan;
            this.TongTien = tongtien;
            this.TrangThai = trangthai;
        }
        public HoaDon(int id, string tenban, int id_nv,String hoten, DateTime ngaytao, DateTime? ngaythanhtoan, int tongtien, int trangthai)
        {
            this.ID = id;
            this.TenBan = tenban;
            this.NhanVienID = id_nv;
            this.HoTen = hoten;
            this.NgayTao = ngaytao;
            this.NgayThanhToan = ngaythanhtoan;
            this.TongTien = tongtien;
            this.TrangThai = trangthai;
        }
    }
}
