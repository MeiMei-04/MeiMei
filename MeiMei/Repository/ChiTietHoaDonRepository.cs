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
    internal class ChiTietHoaDonRepository
    {
        string connectString = Config.getConnectString();
        public List<ChiTietHoaDon> getChiTietHoaDonById(int idhd)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            string query = "  Select ChiTietHoaDon.id,ChiTietHoaDon.id_hd,ChiTietHoaDon.id_td,ThucDon.tenmon,ChiTietHoaDon.soluong,ChiTietHoaDon.dongia,ChiTietHoaDon.trangthai from ChiTietHoaDon\r\njoin ThucDon\r\non ChiTietHoaDon.id_td = ThucDon.id where ChiTietHoaDon.trangthai = 1 and id_hd = @id_hd";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id_hd", idhd);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietHoaDon hoaDon = new ChiTietHoaDon
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                HoaDonID = Convert.ToInt32(reader["id_hd"]),
                                ThucDonID = Convert.ToInt32(reader["id_td"]),
                                TenMon = reader["tenmon"].ToString(),
                                SoLuong = Convert.ToInt32(reader["soluong"]),
                                DonGia = Convert.ToInt32(reader["dongia"]),
                                TrangThai = Convert.ToInt32(reader["trangthai"])
                            };
                            list.Add(hoaDon);
                        }
                    }
                }
            }
            return list;
        }
        public void updateSoLuong(int idtd,int soluong,int dongia)
        {
            string query = "update ChiTietHoaDon set soluong = @soluong, dongia = @dongia where trangthai = 1 and id_td = @idtd";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idtd", idtd);
                    command.Parameters.AddWithValue("@soluong", soluong);
                    command.Parameters.AddWithValue("@dongia", dongia);
                    int row = command.ExecuteNonQuery();
                    if(row > 0)
                    {
                        Console.WriteLine("Sửa Thành Công");
                    }
                }
            }
        }
    }
}
