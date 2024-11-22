using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class XemHocSinh : Form
    {
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        SqlDataAdapter da;
        public XemHocSinh()
        {
            InitializeComponent();
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
        private void XemHocSinh_Load(object sender, EventArgs e)
        {
            Load_GRID1();
            Load_GRID2();
        }
        private void gridDanhSach1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach1.Rows[e.RowIndex];
                txtMaHS.Text = row.Cells["MaHS"].Value.ToString();         
                cbbLop.Text = row.Cells["Lop"].Value.ToString();
            }
        }

        private void gridDanhSach2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach2.Rows[e.RowIndex];
                txtMaHS2.Text = row.Cells["MaHs"].Value.ToString();
                cbbLop2.Text = row.Cells["Lop"].Value.ToString();
            }
        }

        private void btnTim1_Click(object sender, EventArgs e)
        {
            string query = "select * from ThongTinHocSinh where MaHS like N'%" + txtMaHS.Text.Trim() + "%' and Lop like N'%" + cbbLop.Text.Trim() +"%' ";
            da = new SqlDataAdapter(query, connectionString);
            DataTable dtTim = new DataTable();
            da.Fill(dtTim);
            gridDanhSach1.DataSource = dtTim;
        }

        private void btnTim2_Click(object sender, EventArgs e)
        {
            string query = "select * from DiemHocSinh where MaHS like N'%" + txtMaHS2.Text.Trim() + "%' and Lop like N'%" + cbbLop2.Text.Trim() +"%'  ";
            da = new SqlDataAdapter(query, connectionString);
            DataTable dtTim2 = new DataTable();
            da.Fill(dtTim2);
            gridDanhSach2.DataSource = dtTim2;
        }
        private void btnThoat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTinhDTB_Click(object sender, EventArgs e)
        {
            string query = "select Toan, Van, TiengAnh, HoaHoc, SinhHoc, GDCD, TheDuc, VatLy, QuocPhong, Tin from DiemHocSinh where MaHS = @MaHS";

            string maHS = txtMaHS2.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHS", maHS);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        double diemToan = Convert.ToDouble(reader["Toan"]);
                        double diemVan = Convert.ToDouble(reader["Van"]);
                        double diemAnh = Convert.ToDouble(reader["TiengAnh"]);
                        double diemHoa = Convert.ToDouble(reader["HoaHoc"]);
                        double diemSinh = Convert.ToDouble(reader["SinhHoc"]);
                        double diemGDCD = Convert.ToDouble(reader["GDCD"]);
                        double diemTheDuc = Convert.ToDouble(reader["TheDuc"]);
                        double diemLy = Convert.ToDouble(reader["VatLy"]);
                        double diemQP = Convert.ToDouble(reader["QuocPhong"]);
                        double diemTin = Convert.ToDouble(reader["Tin"]);

                        double diemTrungBinh = (diemToan + diemVan + diemAnh + diemHoa + diemSinh + diemGDCD + diemTheDuc + diemLy + diemQP + diemTin) / 10;

                        MessageBox.Show("Điểm trung bình: " + diemTrungBinh.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }

                conn.Close();
            }
        }
    }
}
