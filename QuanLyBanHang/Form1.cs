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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Modify modify;
        HangHoa hangHoa;
        KhachHang khachHang;
        NhanVien nhanVien;
        private void Form1_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.SearchTable("select * from HANGHOA");
                dataGridView3.DataSource = modify.SearchTable("select * from KHACHHANG");
                dataGridView2.DataSource = modify.SearchTable("select * from NHANVIEN");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XoaText();
        }

        private void XoaText()
        {
            textBox_mahh.Text = "";
            textBox_tenhh.Text = "";
            textBox_dvt.Text = "";
            textBox_giamua.Text = "";
            textBox_slton.Text = "";
            textBox_makh.Text = "";
            textBox_tenkh.Text = "";
            textBox_diachi.Text = "";
            textBox_dt.Text = "";
            radioButton1.Checked = true;
            textBox_manv.Text = "";
            textBox_tennv.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            radioButton3.Checked = true;
            textBox_luong.Text = "";
        }
        //--------------------------Hàng Hóa---------------------------------
        private bool checkboxHH()
        {
            if (textBox_mahh.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hàng hóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_tenhh.Text == "")
            {
                MessageBox.Show("Mời bạn nhập tên hàng hóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_dvt.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_giamua.Text == "")
            {
                MessageBox.Show("Mời bạn nhập giá mua hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_slton.Text == "")
            {
                MessageBox.Show("Mời bạn nhập số lượng tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkboxHH())
            {
                try
                {
                    string mahh = this.textBox_mahh.Text;
                    string tenhh = this.textBox_tenhh.Text;
                    string dvt = this.textBox_dvt.Text;
                    int giamua = int.Parse(this.textBox_giamua.Text);
                    int slton = int.Parse(this.textBox_slton.Text);
                    hangHoa = new HangHoa(mahh, tenhh, dvt, giamua, slton);
                    if (modify.ThemHH(hangHoa))
                    {
                        if (MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from HANGHOA";
                            dataGridView1.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            Form1_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (checkboxHH())
            {
                try
                {
                    string mahh = this.textBox_mahh.Text;
                    string tenhh = this.textBox_tenhh.Text;
                    string dvt = this.textBox_dvt.Text;
                    int giamua = int.Parse(this.textBox_giamua.Text);
                    int slton = int.Parse(this.textBox_slton.Text);
                    hangHoa = new HangHoa(mahh, tenhh, dvt, giamua, slton);
                    if (modify.SuaHH(hangHoa))
                    {
                        if (MessageBox.Show("Bạn có muốn sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from HANGHOA";
                            dataGridView1.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            Form1_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không Sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.XoaHH(id))
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "select * from HANGHOA";
                    dataGridView1.DataSource = modify.SearchTable(query);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    Form1_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_mahh.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox_tenhh.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox_dvt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox_giamua.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox_slton.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void textBox6_timkiem_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timhh.Text.Trim();
            if (name == "")
            {
                Form1_Load(sender, e);
            }
            else
            {
                string query = "Select * from HANGHOA where TENHH like '%" + name + "%'";
                dataGridView1.DataSource = modify.SearchTable(query);
            }
        }
        //-------------------------Khách Hàng--------------------------
        private bool checkboxKH()
        {
            if (textBox_makh.Text == "")
            {
                MessageBox.Show("Mời bạn nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_tenkh.Text == "")
            {
                MessageBox.Show("Mời bạn nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_diachi.Text == "")
            {
                MessageBox.Show("Mời bạn nhập địa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_dt.Text == "")
            {
                MessageBox.Show("Mời bạn nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (checkboxKH())
            {
                try
                {
                    string makh = this.textBox_makh.Text;
                    string tenkh = this.textBox_tenkh.Text;
                    string diachi = this.textBox_diachi.Text;
                    string dt = this.textBox_dt.Text;
                    char gioi = (radioButton1.Checked ? 'M' : 'F');
                    khachHang = new KhachHang(makh, tenkh, diachi, dt, gioi);
                    if (modify.ThemKH(khachHang))
                    {
                        if (MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from KHACHHANG";
                            dataGridView2.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            Form1_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkboxKH())
            {
                try
                {
                    string makh = this.textBox_makh.Text;
                    string tenkh = this.textBox_tenkh.Text;
                    string diachi = this.textBox_diachi.Text;
                    string dt = this.textBox_dt.Text;
                    char gioi = (radioButton1.Checked ? 'M' : 'F');
                    khachHang = new KhachHang(makh, tenkh, diachi, dt, gioi);
                    if (modify.SuaKH(khachHang))
                    {
                        if (MessageBox.Show("Bạn có muốn sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from KHACHHANG";
                            dataGridView2.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            Form1_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không Sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.XoaKH(id))
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "select * from KHACHHANG";
                    dataGridView2.DataSource = modify.SearchTable(query);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    Form1_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox6_timkh_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timkh.Text.Trim();
            if (name == "")
            {
                Form1_Load(sender, e);
            }
            else
            {
                string query = "Select * from KHACHHANG where TENKH like '%" + name + "%'";
                dataGridView2.DataSource = modify.SearchTable(query);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_makh.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox_tenkh.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox_diachi.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBox_dt.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            if (dataGridView2.SelectedRows[0].Cells[4].Value.ToString() == "M")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }
        //--------------------Nhân Viên-----------------------
        private bool checkboxNV()
        {
            if (textBox_manv.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_tennv.Text == "")
            {
                MessageBox.Show("Mời bạn nhập tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePicker1.Value == DateTime.Now)
            {
                MessageBox.Show("Mời bạn nhập ngày sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_luong.Text == "")
            {
                MessageBox.Show("Mời bạn nhập lương nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (checkboxNV())
            {
                try
                {
                    string manv = this.textBox_manv.Text;
                    string tennv = this.textBox_tennv.Text;
                    DateTime ngaysinh = this.dateTimePicker1.Value;
                    char gt = (radioButton1.Checked ? 'M' : 'F');
                    int luong = int.Parse(this.textBox_luong.Text);
                    nhanVien = new NhanVien(manv, tennv, ngaysinh, gt, luong);
                    if (modify.ThemNV(nhanVien))
                    {
                        if (MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from NHANVIEN";
                            dataGridView3.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            Form1_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkboxNV())
            {
                try
                {
                    string manv = this.textBox_manv.Text;
                    string tennv = this.textBox_tennv.Text;
                    DateTime ngaysinh = this.dateTimePicker1.Value;
                    char gt = (radioButton1.Checked ? 'M' : 'F');
                    int luong = int.Parse(this.textBox_luong.Text);
                    nhanVien = new NhanVien(manv, tennv, ngaysinh, gt, luong);
                    if (modify.SuaNV(nhanVien))
                    {
                        if (MessageBox.Show("Bạn có muốn sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from NHANVIEN";
                            dataGridView3.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            Form1_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không Sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.XoaNV(id))
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "select * from NHANVIEN";
                    dataGridView3.DataSource = modify.SearchTable(query);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    Form1_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_manv.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox_tennv.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            textBox_luong.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
            if (dataGridView3.SelectedRows[0].Cells[3].Value.ToString() == "M")
                radioButton3.Checked = true;
            else
                radioButton4.Checked = true;
        }

        private void textBox6_timkiemnv_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timnv.Text.Trim();
            if (name == "")
            {
                Form1_Load(sender, e);
            }
            else
            {
                string query = "Select * from NHANVIEN where TENNV like '%" + name + "%'";
                dataGridView3.DataSource = modify.SearchTable(query);
            }
        }
    }
}
