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
    public partial class ThongKeCTHD: Form
    {
        public ThongKeCTHD()
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
                query = "select MAHD,MAHH,(GIABAN*SL) as 'TRI GIA' from CTHD";
                dataGridView1.DataSource = modify.SearchTable(query);
                query = "select sum(GIABAN*SL) from CTHD";
                dataGridView2.DataSource = modify.SearchTable(query);
                query = "select MAHD,MAHH,GIABAN from CTHD";
                dataGridView3.DataSource = modify.SearchTable(query);
                query = "select MAHD,MAHH,SL from CTHD";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                showdata();
            }
            else
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
                    query = "Select MAHD,MAHH,GIABAN from CTHD where GIABAN" + dieukien + name;
                    dataGridView3.DataSource = modify.SearchTable(query);
                    query = "Select count(GIABAN) from CTHD where GIABAN" + dieukien + name;
                    dataGridView5.DataSource = modify.SearchTable(query);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                showdata();
            }
            else
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
                query = "Select MAHD,MAHH,SL from CTHD where SL " +dieukien+ name;
                dataGridView3.DataSource = modify.SearchTable(query);
                query = "Select count(SL) from CTHD where SL " + dieukien + name;
                dataGridView5.DataSource = modify.SearchTable(query);
            }
        }
    }
}
