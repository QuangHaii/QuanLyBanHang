using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    internal class Modify
    {
        SqlDataAdapter dataAdapter;
        SqlCommand command;
        public Modify()
        {
        }

        public DataTable SearchTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        //------------------------Hàng Hóa---------------------------
        public bool ThemHH(HangHoa hangHoa)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into HANGHOA values (@MAHH,@TENHH,@DVT,@GIAMUA,@SLTON)";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAHH", SqlDbType.VarChar).Value = hangHoa.Mahh;
                command.Parameters.Add("@TENHH", SqlDbType.NVarChar).Value = hangHoa.Tenhh;
                command.Parameters.Add("@DVT", SqlDbType.NVarChar).Value = hangHoa.Dvt;
                command.Parameters.Add("@GIAMUA", SqlDbType.Money).Value = hangHoa.Giamua;
                command.Parameters.Add("@SLTON", SqlDbType.Int).Value = hangHoa.Slton;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool SuaHH(HangHoa hangHoa)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update HANGHOA set MAHH=@MAHH,TENHH=@TENHH,DVT=@DVT,GIAMUA=@GIAMUA,SLTON=@SLTON where MAHH=@MAHH";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAHH", SqlDbType.VarChar).Value = hangHoa.Mahh;
                command.Parameters.Add("@TENHH", SqlDbType.NVarChar).Value = hangHoa.Tenhh;
                command.Parameters.Add("@DVT", SqlDbType.NVarChar).Value = hangHoa.Dvt;
                command.Parameters.Add("@GIAMUA", SqlDbType.Int).Value = hangHoa.Giamua;
                command.Parameters.Add("@SLTON", SqlDbType.Int).Value = hangHoa.Slton;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool XoaHH(string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "delete from HANGHOA where MAHH=@MAHH";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAHH", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //----------------------Khách hàng---------------------
        public bool ThemKH(KhachHang khachHang)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into KHACHHANG values (@MAKH,@TENKH,@DIACHI,@DT,@GIOI)";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = khachHang.Makh;
                command.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = khachHang.Tenkh;
                command.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = khachHang.Diachi;
                command.Parameters.Add("@DT", SqlDbType.VarChar).Value = khachHang.Dt;
                command.Parameters.Add("@GIOI", SqlDbType.Char).Value = khachHang.Gt;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool SuaKH(KhachHang khachHang)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update KHACHHANG set MAKH=@MAKH,TENKH=@TENKH,DIACHI=@DIACHI,DT=@DT,GIOI=@GIOI where MAKH=@MAKH";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = khachHang.Makh;
                command.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = khachHang.Tenkh;
                command.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = khachHang.Diachi;
                command.Parameters.Add("@DT", SqlDbType.VarChar).Value = khachHang.Dt;
                command.Parameters.Add("@GIOI", SqlDbType.Char).Value = khachHang.Gt;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool XoaKH(string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "delete from KHACHHANG where MAKH=@MAKH";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //-----------------Nhân Viên--------------------
        public bool ThemNV(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into NHANVIEN values (@MANV,@TENNV,@NGAYSINH,@GIOI,@LUONG)";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MANV", SqlDbType.VarChar).Value = nhanVien.Manv;
                command.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nhanVien.Tennv;
                command.Parameters.Add("@NGAYSINH", SqlDbType.Date).Value = nhanVien.Ngaysinh;
                command.Parameters.Add("@GIOI", SqlDbType.Char).Value = nhanVien.Gioi;
                command.Parameters.Add("@LUONG", SqlDbType.Int).Value = nhanVien.Luong;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool SuaNV(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update NHANVIEN set MANV=@MANV,TENNV=@TENNV,NGAYSINH=@NGAYSINH,GIOI=@GIOI,LUONG=@LUONG where MANV=@MANV";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MANV", SqlDbType.VarChar).Value = nhanVien.Manv;
                command.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nhanVien.Tennv;
                command.Parameters.Add("@NGAYSINH", SqlDbType.Date).Value = nhanVien.Ngaysinh;
                command.Parameters.Add("@GIOI", SqlDbType.Char).Value = nhanVien.Gioi;
                command.Parameters.Add("@LUONG", SqlDbType.Int).Value = nhanVien.Luong;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool XoaNV(string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "delete from NHANVIEN where MANV=@MANV";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MANV", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //--------------------------Hóa Đơn----------------------------
        public bool ThemHD(HoaDon hoaDon)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into NHANVIEN values (@MAHD,@NGAY,@MAKH,@MANV)";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAHD", SqlDbType.VarChar).Value = hoaDon.Mahd;
                command.Parameters.Add("@NGAY", SqlDbType.Date).Value = hoaDon.Ngay;
                command.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = hoaDon.Makh;
                command.Parameters.Add("@MANV", SqlDbType.VarChar).Value = hoaDon.Manv;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool SuaHD(HoaDon hoaDon)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update HOADON set MAHD=@MAHD,NGAY=@NGAY,MAKH=@MAKH,MANV=@MANV where MAHD=@MAHD";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAHD", SqlDbType.VarChar).Value = hoaDon.Mahd;
                command.Parameters.Add("@NGAY", SqlDbType.Date).Value = hoaDon.Ngay;
                command.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = hoaDon.Makh;
                command.Parameters.Add("@MANV", SqlDbType.VarChar).Value = hoaDon.Manv;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool XoaHD(string id)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "delete from HOADON where MAHD=@MAHD";
            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@MAHD", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
    }
}

