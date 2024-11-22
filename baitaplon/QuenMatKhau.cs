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
    public partial class QuenMatKhau : Form
    {
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        public QuenMatKhau()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập email đăng kí");
            }
            else
            {
                string query = "Select * from TaiKhoan where Email = '" + textBox1.Text.Trim() + "' ";
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                label2.ForeColor = Color.Blue;
                                label2.Text = "Mật khẩu: " + dt.Rows[0]["MatKhau"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy tài khoản","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                    }
                    conn.Close();   
                }
            }
        }
    }
}
