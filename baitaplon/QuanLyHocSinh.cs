using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace baitaplon
{
    public partial class QuanLyHocSinh : Form
    {
        //string conn = "Server=MSI\\RIN; Database=BaiTapLon; Trusted_Connection=true";
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        SqlDataAdapter da;
        public QuanLyHocSinh()
        {
            InitializeComponent();
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            Load_GRID1();
            Load_GRID2();
        }

        private void Load_GRID1()
        {
            string sqlThongTin = "select * from ThongTinHocSinh";
            da = new SqlDataAdapter(sqlThongTin, connectionString);
            DataTable dtThongTin = new DataTable();
            da.Fill(dtThongTin);
            gridDanhSach1.DataSource = dtThongTin;
        }
        
        private void Load_GRID2()
        {
            string sqlDiem = "select * from DiemHocSinh";
            da = new SqlDataAdapter(sqlDiem, connectionString);
            DataTable dtDiem = new DataTable();
            da.Fill(dtDiem);
            gridDanhSach2.DataSource = dtDiem;
        }

        

        private void gridDanhSach1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            { 
                DataGridViewRow row = gridDanhSach1.Rows[e.RowIndex];
                txtMaHS.Text = row.Cells["MaHS"].Value.ToString();
                txtHoVaTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                cbbGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cbbLop.Text = row.Cells["Lop"].Value.ToString();
            }
        }

        private void gridDanhSach2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach2.Rows[e.RowIndex];
                txtMaHS2.Text = row.Cells["MaHs"].Value.ToString();
                txtHoVaTen2.Text = row.Cells["HoTen"].Value.ToString();
                cbbLop2.Text = row.Cells["Lop"].Value.ToString();
                cbbHocKy.Text = row.Cells["HocKy"].Value.ToString();
                cbbHanhKiem.Text = row.Cells["HanhKiem"].Value.ToString();
                txtDiemToan.Text = row.Cells["Toan"].Value.ToString();
                txtDiemVan.Text = row.Cells["Van"].Value.ToString();
                txtDiemAnh.Text = row.Cells["TiengAnh"].Value.ToString();
                txtDiemHoa.Text = row.Cells["HoaHoc"].Value.ToString();
                txtDiemSinh.Text = row.Cells["SinhHoc"].Value.ToString();
                txtDiemGDCD.Text = row.Cells["GDCD"].Value.ToString();
                txtDiemTheDuc.Text = row.Cells["TheDuc"].Value.ToString();
                txtDiemLy.Text = row.Cells["VatLy"].Value.ToString();
                txtDiemQP.Text = row.Cells["QuocPhong"].Value.ToString();
                txtDiemTin.Text = row.Cells["Tin"].Value.ToString();
            }
        }
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            string query = "select * from ThongTinHocSinh where MaHS like N'%" + txtMaHS.Text.Trim() + "%' and HoTen like N'%" + txtHoVaTen.Text.Trim() + "%' and GioiTinh like N'%"+cbbGioiTinh.Text.Trim()+"%' and DiaChi like N'%"+txtDiaChi.Text.Trim()+"%' and Lop like N'%"+cbbLop.Text.Trim()+"%' ";
            da = new SqlDataAdapter(query, connectionString);
            DataTable dtTim = new DataTable();
            da.Fill(dtTim);
            gridDanhSach1.DataSource = dtTim;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaHS.Text.Trim() == "" || txtHoVaTen.Text.Trim() == "" || dtpNgaySinh.Text.Trim() == "" || cbbGioiTinh.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || cbbLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into ThongTinHocSinh (MaHS, HoTen, NgaySinh, GioiTinh, DiaChi, Lop) values (@MaHS, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @Lop)";
            string checkquery = "select count(*) from ThongTinHocSinh where MaHS = @MaHS";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand checkcmd = new SqlCommand(checkquery, conn))
                {
                    checkcmd.Parameters.AddWithValue("@MaHS", txtMaHS.Text);
                    int count = (int)checkcmd.ExecuteScalar();
                    if(count > 0)   
                    {
                        MessageBox.Show("Mã học sinh đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                };
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", txtMaHS.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoVaTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString());
                    cmd.Parameters.AddWithValue("@GioiTinh", cbbGioiTinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@Lop", cbbLop.SelectedItem.ToString());
                    int Kiemtra = cmd.ExecuteNonQuery();
                    if(Kiemtra > 0)
                    {
                        MessageBox.Show("Thêm học sinh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm học sinh thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Load_GRID1();
                }
                conn.Close();
            }
            
        }
 
        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "update ThongTinHocSinh set MaHs = @MaHS, HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, Lop = @Lop where MaHS = @MaHS" ;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", txtMaHS.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoVaTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString());
                    cmd.Parameters.AddWithValue("@GioiTinh", cbbGioiTinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@Lop", cbbLop.SelectedItem.ToString());

                    int KiemTra = cmd.ExecuteNonQuery();
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Sửa thông tin thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                conn.Close();
            }
            Load_GRID1();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "delete from ThongTinHocSinh where MaHS = @MaHS";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", txtMaHS.Text);

                    int KiemTra = cmd.ExecuteNonQuery();
                    if (KiemTra > 0)
                    {
                        MessageBox.Show("Xóa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                conn.Close();
            }
            Load_GRID1();
        }

        private void btnTim2_Click(object sender, EventArgs e)
        {
            string query = "select * from DiemHocSinh where MaHS like N'%" + txtMaHS2.Text.Trim() + "%' and HoTen like N'%" + txtHoVaTen2.Text.Trim() + "%' and Lop like N'%" + cbbLop2.Text.Trim() + "%' and HocKy like N'%" + cbbHocKy.Text.Trim() + "%' and HanhKiem like N'%" + cbbHanhKiem.Text.Trim() + "%' and Toan like N'%" + txtDiemToan.Text.Trim() + "%' and Van like N'%" + txtDiemVan.Text.Trim() + "%' and TiengAnh like N'%" + txtDiemAnh.Text.Trim() + "%' and HoaHoc like N'%" + txtDiemHoa.Text.Trim() + "%' and SinhHoc like N'%" + txtDiemSinh.Text.Trim() + "%' and GDCD like N'%" + txtDiemGDCD.Text.Trim() + "%' and TheDuc like N'%" + txtDiemTheDuc.Text.Trim() + "%' and VatLy like N'%" + txtDiemLy.Text.Trim() + "%' and QuocPhong like N'%" + txtDiemQP.Text.Trim() + "%' and Tin like N'%" + txtDiemTin.Text.Trim() + "%' ";
            da = new SqlDataAdapter(query, connectionString);
            DataTable dtTim2 = new DataTable();
            da.Fill(dtTim2);
            gridDanhSach2.DataSource = dtTim2;
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            if(txtMaHS2.Text.Trim() == "" || txtHoVaTen2.Text.Trim() == "" || cbbLop2.Text.Trim() == "" || cbbHocKy.Text.Trim() == "" || cbbHanhKiem.Text.Trim() == "" || txtDiemToan.Text.Trim() == "" || txtDiemToan.Text.Trim() == "" || txtDiemVan.Text.Trim() == "" || txtDiemAnh.Text.Trim() == "" || txtDiemHoa.Text.Trim() == "" || txtDiemSinh.Text.Trim() == "" || txtDiemGDCD.Text.Trim() == "" || txtDiemTheDuc.Text.Trim() =="" || txtDiemLy.Text.Trim() == "" || txtDiemQP.Text.Trim() == "" || txtDiemTin.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into DiemHocSinh (MaHS ,HoTen, Lop, HocKy, HanhKiem, Toan, Van, TiengAnh, HoaHoc, SinhHoc, GDCD, TheDuc, VatLy, QuocPhong, Tin) values (@MaHS ,@HoTen, @Lop, @HocKy, @HanhKiem, @Toan, @Van, @TiengAnh, @HoaHoc, @SinhHoc, @GDCD, @TheDuc, @VatLy, @QuocPhong, @Tin)";
            string checkQuery = "select count(*) from DiemHocSinh where MaHS = @MaHS";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaHS", txtMaHS2.Text);
                    int KiemTra = (int)checkCmd.ExecuteScalar();
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Mã học sinh đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
                conn.Close();
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", txtMaHS2.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoVaTen2.Text);
                    cmd.Parameters.AddWithValue("@Lop", cbbLop2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@HocKy", cbbHocKy.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@HanhKiem", cbbHanhKiem.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Toan", txtDiemToan.Text);
                    cmd.Parameters.AddWithValue("@Van", txtDiemVan.Text);
                    cmd.Parameters.AddWithValue("@TiengAnh", txtDiemAnh.Text);
                    cmd.Parameters.AddWithValue("@HoaHoc", txtDiemHoa.Text);
                    cmd.Parameters.AddWithValue("@SinhHoc", txtDiemSinh.Text);
                    cmd.Parameters.AddWithValue("@GDCD", txtDiemGDCD.Text);
                    cmd.Parameters.AddWithValue("@TheDuc", txtDiemTheDuc.Text);
                    cmd.Parameters.AddWithValue("@VatLy", txtDiemLy.Text);
                    cmd.Parameters.AddWithValue("@QuocPhong", txtDiemQP.Text);
                    cmd.Parameters.AddWithValue("@Tin", txtDiemTin.Text);

                    int KiemTra =  cmd.ExecuteNonQuery();
                    if (KiemTra > 0)
                    {
                        MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Load_GRID2();
                }
                conn.Close();
            }
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            string query = "update DiemHocSinh set MaHS = @MaHs, Hoten = @HoTen, Lop = @Lop, HocKy = @HocKy, HanhKiem = @HanhKiem, Toan = @Toan, Van = @Van, TiengAnh = @TiengAnh, HoaHoc = @HoaHoc, SinhHoc = @SinhHoc, GDCD = @GDCD, TheDuc = @TheDuc, VatLy = @VatLy, QuocPhong = @QuocPhong, Tin = @Tin where MaHS = @MaHS";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", txtMaHS2.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoVaTen2.Text);
                    cmd.Parameters.AddWithValue("@Lop", cbbLop2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@HocKy", cbbHocKy.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@HanhKiem", cbbHanhKiem.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Toan", txtDiemToan.Text);
                    cmd.Parameters.AddWithValue("@Van", txtDiemVan.Text);
                    cmd.Parameters.AddWithValue("@TiengAnh", txtDiemAnh.Text);
                    cmd.Parameters.AddWithValue("@HoaHoc", txtDiemHoa.Text);
                    cmd.Parameters.AddWithValue("@SinhHoc", txtDiemSinh.Text);
                    cmd.Parameters.AddWithValue("@GDCD", txtDiemGDCD.Text);
                    cmd.Parameters.AddWithValue("@TheDuc", txtDiemTheDuc.Text);
                    cmd.Parameters.AddWithValue("@VatLy", txtDiemLy.Text);
                    cmd.Parameters.AddWithValue("@QuocPhong", txtDiemQP.Text);
                    cmd.Parameters.AddWithValue("@Tin", txtDiemTin.Text);
                    int KiemTra = cmd.ExecuteNonQuery();
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin thất bại","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Load_GRID2();
                }
                conn.Close();
            }

        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            string query = "delete from DiemHocSinh where MaHS = @MaHS";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", txtMaHS2.Text);
                    int KiemTra = cmd.ExecuteNonQuery();
                    if(KiemTra > 0)
                    {
                        MessageBox.Show("Xóa thông tin thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin thất bại","Thông tin",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    Load_GRID2();
                }
                conn.Close();
            }
        }

        private void btnTinhDTB_Click(object sender, EventArgs e)
        {
            if (txtDiemToan.Text.Trim() == "" || txtDiemVan.Text.Trim() == "" || txtDiemAnh.Text.Trim() == "" || txtDiemHoa.Text.Trim() == "" || txtDiemSinh.Text.Trim() == "" || txtDiemGDCD.Text.Trim() == "" || txtDiemTheDuc.Text.Trim() == "" || txtDiemLy.Text.Trim() == "" || txtDiemQP.Text.Trim() == "" || txtDiemTin.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double diemToan = Convert.ToDouble(txtDiemToan.Text);
            double diemVan = Convert.ToDouble(txtDiemVan.Text);
            double diemAnh = Convert.ToDouble(txtDiemAnh.Text);
            double diemHoa = Convert.ToDouble(txtDiemHoa.Text);
            double diemSinh = Convert.ToDouble(txtDiemSinh.Text);
            double diemGDCD = Convert.ToDouble(txtDiemGDCD.Text);
            double diemTheDuc = Convert.ToDouble(txtDiemTheDuc.Text);
            double diemLy = Convert.ToDouble(txtDiemLy.Text);
            double diemQP = Convert.ToDouble(txtDiemQP.Text);
            double diemTin = Convert.ToDouble(txtDiemTin.Text);
            double diemTrungBinh = (diemToan + diemVan + diemAnh + diemHoa + diemSinh + diemGDCD + diemTheDuc + diemLy + diemQP + diemTin) / 10;

            MessageBox.Show("Điểm trung bình: " + diemTrungBinh.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

