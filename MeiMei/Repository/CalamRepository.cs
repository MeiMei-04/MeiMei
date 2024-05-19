using MeiMei.Model;
using MeiMei.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Repository
{
    internal class CalamRepository
    {
        string connectString = Config.getConnectString();
        public List<Calam> getListCaLam()
        {
            string query = "Select Calam.id,Calam.id_nv,NhanVien.hoten,Calam.ngaylamviec,Calam.giobatdau,Calam.gioketthuc,Calam.trangthai from Calam\r\njoin NhanVien\r\non Calam.id_nv = NhanVien.id";
            List<Calam> lst = new List<Calam>();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Calam calam = new Calam
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                NhanVienID = Convert.ToInt32(reader["id_nv"]),
                                HoTen = reader["hoten"].ToString(),
                                NgayLamViec = ((DateTime)reader["ngaylamviec"]).Date,
                                GioBatDau = ((TimeSpan)reader["giobatdau"]),
                                GioKetThuc = ((TimeSpan)reader["gioketthuc"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"].ToString())
                            };
                            lst.Add(calam);
                        }
                    }
                }
            }
            return lst;
        }
        public void create(Calam calam)
        {
            string query = "INSERT INTO Calam (id_nv, ngaylamviec, giobatdau, gioketthuc, trangthai)\r\nVALUES \r\n    (@idnv, @ngaylamviec, @giolamviec, @gioketthuc, 1)";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idnv", calam.NhanVienID);
                    command.Parameters.AddWithValue("@ngaylamviec", calam.NgayLamViec);
                    command.Parameters.AddWithValue("@giolamviec", calam.GioBatDau);
                    command.Parameters.AddWithValue("@gioketthuc", calam.GioKetThuc);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Thêm Thành Công");
                    }
                }
            }
        }
        public void update(Calam calam)
        {
            string query = "UPDATE Calam set id_nv = @idnv, ngaylamviec = @ngaylamviec, giobatdau = @giobatdau, gioketthuc = @gioketthuc where id = @id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idnv", calam.NhanVienID);
                    command.Parameters.AddWithValue("@ngaylamviec", calam.NgayLamViec);
                    command.Parameters.AddWithValue("@giobatdau", calam.GioBatDau);
                    command.Parameters.AddWithValue("@gioketthuc", calam.GioKetThuc);
                    command.Parameters.AddWithValue("@id", calam.ID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Sửa Thành Công");
                    }
                }
            }
        }
        public void delete(Calam calam)
        {
            string query = "UPDATE Calam set trangthai = 2 where id = @id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", calam.ID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Xoá Thành Công");
                    }
                }
            }
        }
        public Calam getCalamByIdNv(int idnv)
        {
            Calam calam = new Calam();
            string query = "select * from Calam where id_nv = @idnv and ngaylamviec = @ngaylamviec and trangthai != 2";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idnv", idnv);
                    command.Parameters.AddWithValue("@ngaylamviec", DateTime.Now.Date);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            calam = new Calam
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                NhanVienID = Convert.ToInt32(reader["id_nv"]),
                                NgayLamViec = ((DateTime)reader["ngaylamviec"]).Date,
                                GioBatDau = ((TimeSpan)reader["giobatdau"]),
                                GioKetThuc = ((TimeSpan)reader["gioketthuc"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"].ToString())
                            };
                        }
                    }
                }
            }
            return calam;
        }
        public void checkin(int idnv)
        {
            string query = "UPDATE Calam set trangthai = 3 where id_nv = @idnv and trangthai = 1";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idnv", idnv);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Checkin Thành Công");
                    }
                }
            }
        }
    }
}
