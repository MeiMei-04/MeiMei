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
        public List<NhanVien> getListNhanVien()
        {
            string query = "Select * From NhanVien where trangthai = 1";
            List <NhanVien> lst = new List<NhanVien> ();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhanVien nhanVien = new NhanVien
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                HoTen = reader["hoten"].ToString(),
                                ChucVu = reader["chucvu"].ToString(),
                                TenDangNhap = reader["tendangnhap"].ToString(),
                                MatKhau = reader["matkhau"].ToString(),
                                CCCD = reader["cccd"].ToString(),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                            lst.Add(nhanVien);
                        }
                    }
                }
            }
            return lst;
        }
        public void create(NhanVien nhanVien)
        {
            string query = "INSERT INTO NhanVien (hoten, chucvu, tendangnhap, matkhau, cccd, trangthai)\r\nVALUES \r\n    (@hoten, @chucvu, @user, '1', @cancuoc, 1)";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@hoten", nhanVien.HoTen);
                    command.Parameters.AddWithValue("@chucvu", nhanVien.ChucVu);
                    command.Parameters.AddWithValue("@user", nhanVien.TenDangNhap);
                    command.Parameters.AddWithValue("@cancuoc", nhanVien.CCCD);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Thêm Thành Công");
                    }
                }
            }
        }
        public void update(NhanVien nhanVien)
        {
            string query = "UPDATE NhanVien set hoten = @hoten, chucvu = @chucvu, tendangnhap = @user, cccd = @cancuoc where id = @id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@hoten", nhanVien.HoTen);
                    command.Parameters.AddWithValue("@chucvu", nhanVien.ChucVu);
                    command.Parameters.AddWithValue("@user", nhanVien.TenDangNhap);
                    command.Parameters.AddWithValue("@cancuoc", nhanVien.CCCD);
                    command.Parameters.AddWithValue("@id", nhanVien.ID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Sửa Thành Công");
                    }
                }
            }
        }
        public void delete(NhanVien nhanVien)
        {
            string query = "UPDATE NhanVien set trangthai = 2 where id = @id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", nhanVien.ID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Xoá Thành Công");
                    }
                }
            }
        }
        public void changePass(int idnv,String pass)
        {
            string query = "UPDATE NhanVien set matkhau = @matkhau where id = @id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", idnv);
                    command.Parameters.AddWithValue("@matkhau", pass);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Đổi Mật Khẩu Thành Công");
                    }
                }
            }
        }
    }
}
