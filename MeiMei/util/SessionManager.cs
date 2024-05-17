using MeiMei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.util
{
    internal class SessionManager
    {
        private static NhanVien isNhanVien = null;
        public static void setNhanVien(NhanVien nhanVien)
        {
            isNhanVien = nhanVien;
        }
        public static NhanVien getNhanVien()
        {
            return isNhanVien;
        }
        public static void logout()
        {
            isNhanVien = null;
        }
    }
}
