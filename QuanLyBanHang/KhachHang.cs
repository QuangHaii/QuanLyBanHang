using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    internal class KhachHang
    {
        private string _makh;
        private string _tenkh;
        private string _diachi;
        private string _dt;
        private char _gt;

        public KhachHang()
        {

        }

        public KhachHang(string makh, string tenkh, string diachi, string dt, char gt)
        {
            Makh = makh;
            Tenkh = tenkh;
            Diachi = diachi;
            Dt = dt;
            Gt = gt;
        }

        public string Makh { get => _makh; set => _makh = value; }
        public string Tenkh { get => _tenkh; set => _tenkh = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Dt { get => _dt; set => _dt = value; }
        public char Gt { get => _gt; set => _gt = value; }
    }
}
