using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class ThongKeKhachHang : Form
    {
        public ThongKeKhachHang()
        {
            InitializeComponent();
            showdata();
        }
        Modify modify;
        string query;
        string dieukien;
        public void showdata()
        {
            modify = new Modify();
            try
            {
                query = "select MAKH,TENKH,GIOI from KHACHHANG";
                dataGridView1.DataSource = modify.SearchTable(query);
                query = "select count(GIOI) from KHACHHANG where GIOI='M'";
                dataGridView2.DataSource = modify.SearchTable(query);
                query = "select count(GIOI) from KHACHHANG where GIOI='F'";
                dataGridView3.DataSource = modify.SearchTable(query);
                query = "select MAKH,TENKH,DIACHI from KHACHHANG";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                showdata();
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            dieukien = "M";
                            break;
                        }
                    case 1:
                        {
                            dieukien = "F";
                            break;
                        }
                }
                query = "select MAKH,TENKH,GIOI from KHACHHANG where GIOI = '" + dieukien + "'";
                dataGridView1.DataSource = modify.SearchTable(query);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                showdata();
            else
            {
                dieukien = comboBox2.Text;
                query = "select MAKH,TENKH,DIACHI from KHACHHANG where DIACHI LIKE N'" + dieukien + "'";
                dataGridView4.DataSource = modify.SearchTable(query);
                query = "select count(DIACHI) from KHACHHANG where DIACHI LIKE N'" + dieukien + "'";
                dataGridView5.DataSource = modify.SearchTable(query);
            }
        }
    }
}
