using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace baitaplon
{
    public partial class QuanLyGiaoVien : Form
    {
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        SqlDataAdapter da;

        public QuanLyGiaoVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyGiaoVien_Load(object sender, EventArgs e)
        {
            Load_GRID();
        }

        private void Load_GRID()
        {
            string sqlGiaoVien = "select * from ThongTinGiaoVien";
            da = new SqlDataAdapter(sqlGiaoVien, connectionString);
            DataTable gv = new DataTable();
            da.Fill(gv);
            dataGridView1.DataSource = gv; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                txtHoVaTenGV.Text = row.Cells["HoTen"].Value.ToString();
                dtpGV.Text = row.Cells["NgaySinh"].Value.ToString();
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                cbbGioiTinhGV.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChiGV.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                cbbViTriCongViec.Text = row.Cells["ViTriCongViec"].Value.ToString();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select * from ThongTinGiaoVien where MaGV like N'%" + txtMaGV.Text.Trim() + "%' and HoTen like N'%" + txtHoVaTenGV.Text.Trim() + "%' and SoDienThoai like N'%" + txtSDT.Text.Trim() + "%' and CMND like N'%" + txtCMND.Text.Trim() + "%' and GioiTinh like N'%" + cbbGioiTinhGV.Text.Trim() + "%' and DiaChi like N'%" + txtDiaChiGV.Text.Trim() + "%' and ViTriCongViec like N'%" + cbbViTriCongViec.Text.Trim() + "%' ";
            da = new SqlDataAdapter(query, connectionString);
            DataTable dtTimGV = new DataTable();
            da.Fill(dtTimGV);
            dataGridView1.DataSource = dtTimGV;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text.Trim() == "" || txtHoVaTenGV.Text.Trim() == "" || txtSDT.Text.Trim() == "" || txtCMND.Text.Trim() == "" || dtpGV.Text.Trim() == "" || cbbGioiTinhGV.Text.Trim() == "" || txtDiaChiGV.Text.Trim() == "" || cbbViTriCongViec.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into ThongTinGiaoVien (MaGV, HoTen, SoDienThoai, CMND, NgaySinh, GioiTinh, DiaChi, ViTriCongViec) values (@MaGV, @HoTen, @SoDienThoai, @CMND, @NgaySinh, @GioiTinh, @DiaChi, @ViTriCongViec)";
            string checkQuery = "select count(*) from ThongTinGiaoVien where MaGV = @MaGV";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand checkcmd = new SqlCommand(checkQuery, conn))
                {
                    checkcmd.Parameters.AddWithValue("@MaGV", txtMaGV.Text);
                    int KiemTra = (int)checkcmd.ExecuteScalar(); 
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Mã giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                conn.Close();
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", txtMaGV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoVaTenGV.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpGV.Value.ToString());
                    cmd.Parameters.AddWithValue("@GioiTinh", cbbGioiTinhGV.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Diachi", txtDiaChiGV.Text);
                    cmd.Parameters.AddWithValue("@ViTriCongViec", cbbViTriCongViec.SelectedItem.ToString());
                    int KiemTra = cmd.ExecuteNonQuery();//
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Load_GRID();
                }
                conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "update ThongTinGiaoVien set MaGV = @MaGV, HoTen = @HoTen, SoDienThoai = @SoDienThoai, CMND = @CMND, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, ViTriCongViec = @ViTriCongViec where MaGV = @MaGV";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", txtMaGV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoVaTenGV.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpGV.Value.ToString());
                    cmd.Parameters.AddWithValue("@GioiTinh", cbbGioiTinhGV.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Diachi", txtDiaChiGV.Text);
                    cmd.Parameters.AddWithValue("@ViTriCongViec", cbbViTriCongViec.SelectedItem.ToString());
                    int KiemTra = cmd.ExecuteNonQuery();
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Load_GRID();
                }
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "delete from ThongTinGiaoVien where MaGV = @MaGV";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", txtMaGV.Text);
                    int KiemTra = cmd.ExecuteNonQuery();
                    if (KiemTra > 0)
                    {
                        MessageBox.Show("Xóa thông tin thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Load_GRID();
                }
                conn.Close();
            }
        }
    }
}
