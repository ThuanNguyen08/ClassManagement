namespace baitaplon
{
    partial class HomeHocSinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xemThongTinHocSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemThôngTinGiáoViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemThongTinHocSinhToolStripMenuItem,
            this.xemThôngTinGiáoViênToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xemThongTinHocSinhToolStripMenuItem
            // 
            this.xemThongTinHocSinhToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xemThongTinHocSinhToolStripMenuItem.Name = "xemThongTinHocSinhToolStripMenuItem";
            this.xemThongTinHocSinhToolStripMenuItem.Size = new System.Drawing.Size(294, 35);
            this.xemThongTinHocSinhToolStripMenuItem.Text = "Xem Thông Tin Học Sinh";
            this.xemThongTinHocSinhToolStripMenuItem.Click += new System.EventHandler(this.xemThongTinHocSinhToolStripMenuItem_Click);
            // 
            // xemThôngTinGiáoViênToolStripMenuItem
            // 
            this.xemThôngTinGiáoViênToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xemThôngTinGiáoViênToolStripMenuItem.Name = "xemThôngTinGiáoViênToolStripMenuItem";
            this.xemThôngTinGiáoViênToolStripMenuItem.Size = new System.Drawing.Size(300, 35);
            this.xemThôngTinGiáoViênToolStripMenuItem.Text = "Xem Thông Tin Giáo Viên";
            this.xemThôngTinGiáoViênToolStripMenuItem.Click += new System.EventHandler(this.xemThôngTinGiáoViênToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(90, 35);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::baitaplon.Properties.Resources.a1_6263;
            this.pictureBox1.Location = new System.Drawing.Point(12, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1500, 1008);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // HomeHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 676);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeHocSinh";
            this.Text = "Trang chủ học sinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemThongTinHocSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemThôngTinGiáoViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}