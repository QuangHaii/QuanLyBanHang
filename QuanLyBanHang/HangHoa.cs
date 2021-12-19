using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    internal class HangHoa
    {
        private string _mahh;
        private string _tenhh;
        private string _dvt;
        private int _giamua;
        private int _slton;

        public HangHoa()
        {

        }
        public HangHoa(string mahh, string tenhh, string dvt, int giamua, int slton)
        {
            Mahh = mahh;
            Tenhh = tenhh;
            Dvt = dvt;
            Giamua = giamua;
            Slton = slton;
        }

        public string Mahh { get => _mahh; set => _mahh = value; }
        public string Tenhh { get => _tenhh; set => _tenhh = value; }
        public string Dvt { get => _dvt; set => _dvt = value; }
        public int Giamua { get => _giamua; set => _giamua = value; }
        public int Slton { get => _slton; set => _slton = value; }
    }
}
