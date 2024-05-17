using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Model
{
    internal class ThucDon
    {
        public int ID { get; set; }
        public string TenMon { get; set; }
        public string DanhMuc { get; set; }
        public int Gia { get; set; }
        public int TrangThai { get; set; }

        // Constructor mặc định
        public ThucDon()
        {
        }

        // Constructor với các tham số
        public ThucDon(int id, string tenmon, string danhmuc, int gia, int trangthai)
        {
            this.ID = id;
            this.TenMon = tenmon;
            this.DanhMuc = danhmuc;
            this.Gia = gia;
            this.TrangThai = trangthai;
        }
    }
}
