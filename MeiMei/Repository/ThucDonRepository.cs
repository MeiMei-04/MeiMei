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
    }
}
