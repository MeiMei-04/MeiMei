using MeiMei.Model;
using MeiMei.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.Repository
{
    internal class HoaDonRepository
    {

        string connectString = Config.getConnectString();

        public int CreateHoaDon(string tenban, int id_nv)
        {
            string query = "INSERT INTO HoaDon (tenban, id_nv, tongtien, trangthai) VALUES (@tenban, @idnv, 0, 1)";
            string query1 = "SELECT * FROM HoaDon WHERE tenban = @tenban AND trangthai = 1";
            int id = -1;

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command1 = new SqlCommand(query1, conn))
                {
                    command1.Parameters.AddWithValue("@tenban", tenban);

                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["id"]);
                        }
                        else
                        {
                            reader.Close();

                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("@tenban", tenban);
                                command.Parameters.AddWithValue("@idnv", id_nv);

                                int row = command.ExecuteNonQuery();
                                if (row > 0)
                                {
                                    command1.Parameters.Clear();
                                    command1.CommandText = "SELECT @@IDENTITY"; // trả về giá trị cuối cùng đc thêm
                                    id = Convert.ToInt32(command1.ExecuteScalar());// trả về cột đầu tiên, hàng đầu tiên
                                }
                            }
                        }
                    }
                }
            }

            return id;
        }
        public List<HoaDon> GetHoaDonList()
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = "  select * from HoaDon where trangthai = 1 ";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDon hoaDon = new HoaDon
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                TenBan = reader["tenban"].ToString(),
                                NhanVienID = Convert.ToInt32(reader["id_nv"]),
                                //NgayTao = Convert.ToDateTime("ngaytao"),
                                //NgayThanhToan = Convert.ToDateTime("ngaythanhtoan"),
                                NgayTao = ((DateTime)reader["ngaytao"]).Date,
                                NgayThanhToan = reader["ngaythanhtoan"] != DBNull.Value ? ((DateTime)reader["ngaythanhtoan"]).Date : (DateTime?)null,
                                TongTien = Convert.ToInt32(reader["tongtien"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                            list.Add(hoaDon);
                        }
                    }
                }
            }
            return list;
        }
        public void thanhtoan(int idhd,int tongtien)
        {
            string query = "UPDATE HoaDon set trangthai = 2, tongtien = @tongtien,ngaythanhtoan = @ngaythanhtoan where id = @idhd";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idhd", idhd);
                    command.Parameters.AddWithValue("@tongtien", tongtien);
                    command.Parameters.AddWithValue("@ngaythanhtoan", DateTime.Now);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Thanh Toán Thành Công");
                    }
                }
            }
        }
        public List<HoaDon> GetHoaDonListAll()
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = "Select HoaDon.id,HoaDon.id_nv,NhanVien.hoten,HoaDon.tenban,HoaDon.ngaytao,HoaDon.ngaythanhtoan,HoaDon.tongtien,HoaDon.trangthai From HoaDon\r\njoin NhanVien\r\non HoaDon.id_nv = NhanVien.id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDon hoaDon = new HoaDon
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                TenBan = reader["tenban"].ToString(),
                                NhanVienID = Convert.ToInt32(reader["id_nv"]),
                                HoTen = reader["hoten"].ToString(),
                                NgayTao = ((DateTime)reader["ngaytao"]).Date,
                                NgayThanhToan = reader["ngaythanhtoan"] != DBNull.Value ? ((DateTime)reader["ngaythanhtoan"]).Date : (DateTime?)null,
                                TongTien = Convert.ToInt32(reader["tongtien"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                            list.Add(hoaDon);
                        }
                    }
                }
            }
            return list;
        }
    }

}

