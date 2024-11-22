using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class HomeGiaoVien : Form
    {
        public HomeGiaoVien()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKy dangky = new DangKy();
            dangky.ShowDialog();
        }


        private void quảnLýĐiểmHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHocSinh qlhs = new QuanLyHocSinh();
            qlhs.ShowDialog();
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyGiaoVien qlgv = new QuanLyGiaoVien();
            qlgv.ShowDialog();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangnhap = new DangNhap();
            dangnhap.ShowDialog();
        }
    }
}
