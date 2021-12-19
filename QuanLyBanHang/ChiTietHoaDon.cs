using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    internal class ChiTietHoaDon
    {
        private string _mahd;
        private string _mahh;
        private int _sl;
        private int _giaban;

        public ChiTietHoaDon()
        {

        }
        public ChiTietHoaDon(string mahd, string mahh, int sl, int giaban)
        {
            Mahd = mahd;
            Mahh = mahh;
            Sl = sl;
            Giaban = giaban;
        }

        public string Mahd { get => _mahd; set => _mahd = value; }
        public string Mahh { get => _mahh; set => _mahh = value; }
        public int Sl { get => _sl; set => _sl = value; }
        public int Giaban { get => _giaban; set => _giaban = value; }
    }
}
