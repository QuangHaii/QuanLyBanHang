using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    internal class Connection
    { 
        private static string stringConnection= @"Data Source=DESKTOP-J0NI0G7\SQLEXPRESS;Initial Catalog=QLBANHANG;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
