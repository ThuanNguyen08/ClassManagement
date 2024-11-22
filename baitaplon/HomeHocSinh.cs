using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class HomeHocSinh : Form
    {
        public HomeHocSinh()
        {
            InitializeComponent();
        }

        private void xemThongTinHocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemHocSinh xemHocSinh = new XemHocSinh();
            xemHocSinh.ShowDialog();
        }

        private void xemThôngTinGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemGiaoVien xemGiaoVien = new XemGiaoVien();
            xemGiaoVien.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }
    }
}
