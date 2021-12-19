using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    internal class NhanVien
    {
        private string _manv;
        private string _tennv;
        private DateTime _ngaysinh;
        private char _gioi;
        private int _luong;
        public NhanVien()
        {

        }
        public NhanVien(string manv, string tennv, DateTime ngaysinh, char gioi, int luong)
        {
            _manv = manv;
            _tennv = tennv;
            _ngaysinh = ngaysinh;
            _gioi = gioi;
            _luong = luong;
        }
        public string Manv { get => _manv; set => _manv = value; }
        public string Tennv { get => _tennv; set => _tennv = value; }
        public DateTime Ngaysinh { get => _ngaysinh; set => _ngaysinh = value; }
        public char Gioi { get => _gioi; set => _gioi = value; }
        public int Luong { get => _luong; set => _luong = value; }
    }
}
