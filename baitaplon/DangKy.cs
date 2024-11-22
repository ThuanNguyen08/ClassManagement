using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace baitaplon
{

    public partial class DangKy : Form
    {
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        SqlDataAdapter da;
        public DangKy()
        {
            InitializeComponent();
        }
        public bool checkTaiKhoan(string tk) //check ten tai khoan va mat khau
        {
            return Regex.IsMatch(tk,@"^[a-z A-Z 0-9]{5,24}$");
        }

        public bool checkEmail(string em) //check email 
        {
            return Regex.IsMatch(em, @"^[a-z A-Z 0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkTaiKhoan(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản dài 6 - 24 kí tự, chỉ với kí tự chữ và số, chữ hoa và chữ thường","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!checkTaiKhoan(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài 6 - 24 kí tự, chỉ với kí tự chữ và số, chữ hoa và chữ thường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!checkEmail(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập email đúng cú pháp, dài 3 - 20 kí tự, chỉ với kí tự chữ và số, chữ hoa và chữ thường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(cbbNguoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string checkQuery = "select count(*) from TaiKhoan where TenTaiKhoan like '" + textBox1.Text.Trim() + "'";
            string query = "Insert into TaiKhoan values('" + textBox1.Text.Trim() + "' , '" + textBox2.Text.Trim() + "' , '" + textBox4.Text.Trim() + "', '"+cbbNguoiDung.Text.Trim()+"')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    int kiemTra = (int)cmd.ExecuteScalar();
                    if (kiemTra > 0)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại!! Vui lòng nhập tên khác","Lỗi trùng tên",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
                conn.Close();
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", textBox1.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@NguoiDung", cbbNguoiDung.Text.Trim());
                    int kiemTra = cmd.ExecuteNonQuery();
                    if (kiemTra > 0)
                    {
                        DialogResult kq = MessageBox.Show("Đăng ký thành công. Bạn có muốn quay lại trang đăng nhập không?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                        if(kq == DialogResult.Yes)
                        {
                            this.Hide();
                            DangNhap dn = new DangNhap();
                            dn.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký không thành công");
                    }
                }
                conn.Close();
            }
        }
    }
}
