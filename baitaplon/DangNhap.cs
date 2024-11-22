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
    public partial class DangNhap : Form
    {
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản.");
            }
            else if(textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else if(cbbNguoiDung.Text.Trim() == "Chọn người dùng")
            {
                MessageBox.Show("Vui lòng chọn người dùng.");
            }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan = '" + textBox1.Text.Trim() + "' and MatKhau = '" + textBox2.Text.Trim() + "' and NguoiDung = '" + cbbNguoiDung.Text.Trim() + "' ";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                // Đăng nhập thành công
                                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if(cbbNguoiDung.Text.Trim() == "Học sinh")
                                {
                                    this.Hide();
                                    HomeHocSinh home = new HomeHocSinh();
                                    home.ShowDialog();
                                    this.Close();
                                }
                                else if(cbbNguoiDung.Text.Trim() == "Giáo viên")
                                {
                                    this.Hide();
                                    HomeGiaoVien home = new HomeGiaoVien();
                                    home.ShowDialog();
                                    this.Close();
                                }
                            }
                            else
                            {
                                // Sai tên tài khoản hoặc mật khẩu
                                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu hoặc người dùng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }   
                    }
                    conn.Close();
                }
            }
        }
    }
}
