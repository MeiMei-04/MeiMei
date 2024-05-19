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
    internal class ThucDonRepository
    {
        string connectString = Config.getConnectString();
        public List<ThucDon> getByType(string type)
        {
            List<ThucDon> lst = new List<ThucDon> ();
            string query = "Select * from ThucDon where trangthai = 1 and danhmuc = @type";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("type", type);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThucDon thucDon = new ThucDon
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                TenMon = reader["tenmon"].ToString(),
                                DanhMuc = reader["danhmuc"].ToString(),
                                Gia = Convert.ToInt32(reader["gia"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                            lst.Add(thucDon);
                        }
                    }
                }
            }
            return lst;
        }
        public List<ThucDon> getListThucDon()
        {
            List<ThucDon> lst = new List<ThucDon>();
            string query = "Select * from ThucDon where trangthai = 1";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThucDon thucDon = new ThucDon
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                TenMon = reader["tenmon"].ToString(),
                                DanhMuc = reader["danhmuc"].ToString(),
                                Gia = Convert.ToInt32(reader["gia"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                            lst.Add(thucDon);
                        }
                    }
                }
            }
            return lst;
        }
        public void create(ThucDon thucDon)
        {
            string query = "INSERT INTO ThucDon (tenmon, danhmuc, gia, trangthai)\r\nVALUES \r\n    (@tenmon, @danhmuc, @gia, 1)";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@tenmon", thucDon.TenMon);
                    command.Parameters.AddWithValue("@danhmuc", thucDon.DanhMuc);
                    command.Parameters.AddWithValue("@gia", thucDon.Gia);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Thêm Thành Công");
                    }
                }
            }
        }
        public void update(ThucDon thucDon)
        {
            string query = "UPDATE ThucDon set tenmon = @tenmon, danhmuc = @danhmuc, gia = @gia where id =@id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@tenmon", thucDon.TenMon);
                    command.Parameters.AddWithValue("@danhmuc", thucDon.DanhMuc);
                    command.Parameters.AddWithValue("@gia", thucDon.Gia);
                    command.Parameters.AddWithValue("@id", thucDon.ID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Sửa Thành Công");
                    }
                }
            }
        }
        public void delete(ThucDon thucDon)
        {
            string query = "UPDATE ThucDon set trangthai = 2 where id =@id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", thucDon.ID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Xoá Thành Công");
                    }
                }
            }
        }
    }
}
