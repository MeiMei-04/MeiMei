using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Model
{
    internal class ChiTietHoaDon
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int ThucDonID { get; set; }
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int TrangThai { get; set; }

        // Constructor mặc định
        public ChiTietHoaDon()
        {
        }

        // Constructor với các tham số
        public ChiTietHoaDon(int id, int id_hd, int id_td, int soluong, int dongia, int trangthai)
        {
            this.ID = id;
            this.HoaDonID = id_hd;
            this.ThucDonID = id_td;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.TrangThai = trangthai;
        }
        public ChiTietHoaDon(int id, int id_hd,int id_td, string tenmon, int soluong, int dongia, int trangthai)
        {
            this.ID = id;
            this.HoaDonID = id_hd;
            this.ThucDonID = id_td;
            this.TenMon = tenmon;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.TrangThai = trangthai;
        }
    }
}
