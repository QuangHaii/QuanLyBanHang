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
            showdata();
        }

        Modify modify;
        HangHoa hangHoa;
        KhachHang khachHang;
        NhanVien nhanVien;
        HoaDon hoaDon;
        ChiTietHoaDon chiTietHoaDon;
        private void showdata()
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.SearchTable("select * from HANGHOA");
                dataGridView2.DataSource = modify.SearchTable("select * from KHACHHANG");
                dataGridView3.DataSource = modify.SearchTable("select * from NHANVIEN");
                dataGridView4.DataSource = modify.SearchTable("select * from HOADON");
                dataGridView5.DataSource = modify.SearchTable("select * from CTHD");
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
            textBox_searchhd.Text = "";
            textBox_searchkh.Text = "";
            textBox_searchnv.Text = "";
            textBox_mahd.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            textBox_makh2.Text = "";
            textBox_manv2.Text = "";
            textBox_macthd.Text = "";
            textBox_macthh.Text = "";
            textBox_sl.Text = "";
            textBox_giaban.Text = "";
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
                            showdata();
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
                            showdata();
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
                    showdata();
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

        private void textBox_timhh_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timhh.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                string query = "Select * from HANGHOA where TENHH like N'%" + name + "%'";
                dataGridView1.DataSource = modify.SearchTable(query);
            }
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
                            showdata();
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
                            showdata();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.XoaNV(id))
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "select * from NHANVIEN";
                    dataGridView3.DataSource = modify.SearchTable(query);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    showdata();
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

        private void textBox_timnv_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timnv.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                string query = "Select * from NHANVIEN where TENNV like N'%" + name + "%'";
                dataGridView3.DataSource = modify.SearchTable(query);
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
                            showdata();
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
                            showdata();
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
                    showdata();
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_timkh_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timkh.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                string query = "Select * from KHACHHANG where TENKH like N'%" + name + "%'";
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
        //----------------------------Hóa Đơn----------------------------------
        private bool checkboxHD()
        {
            if (textBox_mahd.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_makh2.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePicker2.Value == DateTime.Now)
            {
                MessageBox.Show("Mời bạn nhập ngày !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_manv2.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button_them_Click(object sender, EventArgs e)
        {
            if (checkboxHD())
            {
                try
                {
                    string mahd = this.textBox_mahd.Text;
                    DateTime ngay = this.dateTimePicker2.Value;
                    string makh = this.textBox_makh2.Text;
                    string manv = this.textBox_manv2.Text;
                    hoaDon = new HoaDon(manv, ngay, makh, manv);
                    if (modify.ThemHD(hoaDon))
                    {
                        if (MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from HOADON";
                            dataGridView4.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            showdata();
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

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (checkboxHD())
            {
                try
                {
                    string mahd = this.textBox_mahd.Text;
                    DateTime ngay = this.dateTimePicker2.Value;
                    string makh = this.textBox_makh2.Text;
                    string manv = this.textBox_manv2.Text;
                    hoaDon = new HoaDon(manv, ngay, makh, manv);
                    if (modify.SuaHD(hoaDon))
                    {
                        if (MessageBox.Show("Bạn có muốn sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from HOADON";
                            dataGridView4.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            showdata();
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

        private void button_sua_Click(object sender, EventArgs e)
        {
            string id = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.XoaHD(id))
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "select * from HOADON";
                    dataGridView4.DataSource = modify.SearchTable(query);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    showdata();
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_mahd.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            dateTimePicker2.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
            textBox_makh2.Text = dataGridView4.SelectedRows[0].Cells[3].Value.ToString();
            textBox_manv2.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void textBox_searchhd_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_searchhd.Text.Trim();
            string query;
            if (name == "")
            {
                showdata();
            }
            else
            {
                query = "Select * from HOADON where MAHD like '%" + name + "%'";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
        }

        private void textBox_searchkh_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_searchkh.Text.Trim();
            string name1 = textBox_searchnv.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else if(name1 == "")
            {
                string query = "Select * from HOADON where MAKH like '%" + name + "%'";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
            else if(name != "")
            {
                string query = "Select * from HOADON where MAKH like '%" + name + "%' and MANV like '%"+name1+"%'";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
        }

        private void textBox_searchnv_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_searchnv.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                string query = "Select * from HOADON where MANV like '%" + name + "%'";
                dataGridView4.DataSource = modify.SearchTable(query);
            }
        }
        //------------------------Chi Tiet Hoa Don---------------------------------
        private bool checkboxCTHD()
        {
            if (textBox_macthd.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_macthh.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hàng hóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_sl.Text == "")
            {
                MessageBox.Show("Mời bạn nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_giaban.Text == "")
            {
                MessageBox.Show("Mời bạn nhập giá bán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (checkboxCTHD())
            {
                try
                {
                    string mahd = this.textBox_macthd.Text;
                    string mahh = this.textBox_macthh.Text;
                    int sl = int.Parse(this.textBox_sl.Text);
                    int giaban = int.Parse(this.textBox_giaban.Text);
                    chiTietHoaDon = new ChiTietHoaDon(mahd, mahh, sl, giaban);
                    if (modify.ThemCTHD(chiTietHoaDon))
                    {
                        if (MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from CTHD";
                            dataGridView5.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            showdata();
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (checkboxCTHD())
            {
                try
                {
                    string mahd = this.textBox_macthd.Text;
                    string mahh = this.textBox_macthh.Text;
                    int sl = int.Parse(this.textBox_sl.Text);
                    int giaban = int.Parse(this.textBox_giaban.Text);
                    chiTietHoaDon = new ChiTietHoaDon(mahd, mahh, sl, giaban);
                    if (modify.SuaCTHD(chiTietHoaDon))
                    {
                        if (MessageBox.Show("Bạn có muốn sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string query = "select * from CTHD";
                            dataGridView5.DataSource = modify.SearchTable(query);
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            showdata();
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

        private void button10_Click(object sender, EventArgs e)
        {
            string id = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.XoaCTHD(id))
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string query = "select * from CTHD";
                    dataGridView5.DataSource = modify.SearchTable(query);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    showdata();
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_macthd.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            textBox_macthh.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
            textBox_sl.Text = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
            textBox_giaban.Text = dataGridView5.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void textBox_timcthd_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_timcthd.Text.Trim();
            if (name == "")
            {
                showdata();
            }
            else
            {
                string query = "Select * from CTHD where MAHD like N'%" + name + "%'";
                dataGridView5.DataSource = modify.SearchTable(query);
            }
        }
    }
}
