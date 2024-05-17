using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Model
{
    internal class Calam
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public DateTime NgayLamViec { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public int TrangThai { get; set; }

        // Constructor mặc định
        public Calam()
        {
        }

        // Constructor với các tham số
        public Calam(int id, int id_nv, DateTime ngaylamviec, TimeSpan giobatdau, TimeSpan gioketthuc, int trangthai)
        {
            this.ID = id;
            this.NhanVienID = id_nv;
            this.NgayLamViec = ngaylamviec;
            this.GioBatDau = giobatdau;
            this.GioKetThuc = gioketthuc;
            this.TrangThai = trangthai;
        }
    }
}
