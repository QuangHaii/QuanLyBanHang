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
    public partial class ThongKeHoaDon : Form
    {
        public ThongKeHoaDon()
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
                query = "select * from HOADON";
                dataGridView3.DataSource = modify.SearchTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string name = dateTimePicker1.Value.ToString("MM-dd-yyyy").Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                try
                {
                    query = "Select * from HOADON where NGAY" + dieukien + "'" + name + "'";
                    dataGridView3.DataSource = modify.SearchTable(query);
                    query = "Select count(MAHD) from HOADON where NGAY" + dieukien + "'" + name + "'";
                    dataGridView5.DataSource = modify.SearchTable(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
