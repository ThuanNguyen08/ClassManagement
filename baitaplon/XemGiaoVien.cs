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
    
    public partial class XemGiaoVien : Form
    {
        string connectionString = "Data Source=MSI\\RIN;Initial Catalog=BaiTapLon;Integrated Security=True";
        SqlDataAdapter da;
        public XemGiaoVien()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select *from ThongTinGiaoVien where MaGV like N'%" + txtMaGV.Text.Trim() + "%'  and ViTriCongViec like N'%" + cbbViTriCongViec.Text.Trim() + "%'";
            da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                cbbViTriCongViec.Text = row.Cells["ViTriCongViec"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_GRID()
        {
            string sqlGiaoVien = "select * from ThongTinGiaoVien";
            da = new SqlDataAdapter(sqlGiaoVien, connectionString);
            DataTable gv = new DataTable();
            da.Fill(gv);
            dataGridView1.DataSource = gv;
        }

        private void XemGiaoVien_Load(object sender, EventArgs e)
        {
            Load_GRID();
        }
    }
}
