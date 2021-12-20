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
    public partial class ThongKeNhanVien : Form
    {
        public ThongKeNhanVien()
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
                query = "select MANV,TENNV,GIOI from NHANVIEN";
                dataGridView1.DataSource = modify.SearchTable(query);
                query = "select count(GIOI) from NHANVIEN where GIOI='M'";
                dataGridView2.DataSource = modify.SearchTable(query);
                query = "select count(GIOI) from NHANVIEN where GIOI='F'";
                dataGridView3.DataSource = modify.SearchTable(query);
                query = "select MANV,TENNV,LUONG from NHANVIEN";
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
                query = "select MANV,TENNV,GIOI from NHANVIEN where GIOI = '" + dieukien + "'";
                dataGridView1.DataSource = modify.SearchTable(query);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        dieukien = "=";
                        break;
                    }
                case 1:
                    {
                        dieukien = ">";
                        break;
                    }
                case 2:
                    {
                        dieukien = ">=";
                        break;
                    }
                case 3:
                    {
                        dieukien = "<";
                        break;
                    }
                case 4:
                    {
                        dieukien = "<=";
                        break;
                    }
                case 5:
                    {
                        dieukien = "!=";
                        break;
                    }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                string query = "Select MANV,TENNV,LUONG from NHANVIEN where LUONG" + dieukien + name;
                dataGridView4.DataSource = modify.SearchTable(query);
            }
        }
    }
}
