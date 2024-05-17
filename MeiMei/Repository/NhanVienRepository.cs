using MeiMei.Model;
using MeiMei.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Repository
{
    internal class NhanVienRepository
    {
        string connectString = Config.getConnectString();
        public NhanVien getNhanVien(string username, string password)
        {
            string query = "Select * From NhanVien where tendangnhap = @username and matkhau = @password and trangthai = 1";
            NhanVien nhanVien = null;
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nhanVien = new NhanVien
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                HoTen = reader["hoten"].ToString(),
                                ChucVu = reader["chucvu"].ToString(),
                                TenDangNhap = reader["tendangnhap"].ToString(),
                                MatKhau = reader["matkhau"].ToString(),
                                CCCD = reader["cccd"].ToString(),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                        }
                    }
                }
            }
            return nhanVien;
        }
    }
}
