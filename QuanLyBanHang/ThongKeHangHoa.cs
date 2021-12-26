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
    public partial class ThongKeHangHoa : Form
    {
        public ThongKeHangHoa()
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
                query = "select MAHH,TENHH,(GIAMUA*SLTON) as 'TRI GIA' from HANGHOA";
                dataGridView1.DataSource = modify.SearchTable(query);
                query = "select sum(GIAMUA*SLTON) from HANGHOA";
                dataGridView2.DataSource = modify.SearchTable(query);
                query = "select MAHH,TENHH,GIAMUA from HANGHOA";
                dataGridView3.DataSource = modify.SearchTable(query);
                query = "select MAHH,TENHH,SLTON from HANGHOA";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                switch (comboBox1.SelectedIndex)
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
                try
                {
                    query = "Select MAHH,TENHH,GIAMUA from HANGHOA where GIAMUA" + dieukien + name;
                    dataGridView3.DataSource = modify.SearchTable(query);
                    query = "Select count(GIAMUA) from HANGHOA where GIAMUA" + dieukien + name;
                    dataGridView5.DataSource = modify.SearchTable(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                try
                {
                    query = "Select MAHH,TENHH,SLTON from HANGHOA where SLTON" + dieukien + name;
                    dataGridView4.DataSource = modify.SearchTable(query);
                    query = "Select count(SLTON) from HANGHOA where SLTON" + dieukien + name;
                    dataGridView6.DataSource = modify.SearchTable(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
