namespace baitaplon
{
    partial class HomeGiaoVien
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐiểmHọcSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýGiáoViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.exitToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.thoátToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýToolStripMenuItem});
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 35);
            this.exitToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đăngKýToolStripMenuItem
            // 
            this.đăngKýToolStripMenuItem.Name = "đăngKýToolStripMenuItem";
            this.đăngKýToolStripMenuItem.Size = new System.Drawing.Size(191, 36);
            this.đăngKýToolStripMenuItem.Text = "Đăng Ký";
            this.đăngKýToolStripMenuItem.Click += new System.EventHandler(this.đăngKýToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýĐiểmHọcSinhToolStripMenuItem,
            this.quảnLýGiáoViênToolStripMenuItem});
            this.quảnLýToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(114, 35);
            this.quảnLýToolStripMenuItem.Text = "Quản Lý";
            // 
            // quảnLýĐiểmHọcSinhToolStripMenuItem
            // 
            this.quảnLýĐiểmHọcSinhToolStripMenuItem.Name = "quảnLýĐiểmHọcSinhToolStripMenuItem";
            this.quảnLýĐiểmHọcSinhToolStripMenuItem.Size = new System.Drawing.Size(288, 36);
            this.quảnLýĐiểmHọcSinhToolStripMenuItem.Text = "Quản lý học sinh";
            this.quảnLýĐiểmHọcSinhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐiểmHọcSinhToolStripMenuItem_Click);
            // 
            // quảnLýGiáoViênToolStripMenuItem
            // 
            this.quảnLýGiáoViênToolStripMenuItem.Name = "quảnLýGiáoViênToolStripMenuItem";
            this.quảnLýGiáoViênToolStripMenuItem.Size = new System.Drawing.Size(288, 36);
            this.quảnLýGiáoViênToolStripMenuItem.Text = "Quản lý giáo viên";
            this.quảnLýGiáoViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýGiáoViênToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem1
            // 
            this.thoátToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thoátToolStripMenuItem1.Name = "thoátToolStripMenuItem1";
            this.thoátToolStripMenuItem1.Size = new System.Drawing.Size(90, 35);
            this.thoátToolStripMenuItem1.Text = "Thoát";
            this.thoátToolStripMenuItem1.Click += new System.EventHandler(this.thoátToolStripMenuItem1_Click);
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
            // HomeGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 669);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeGiaoVien";
            this.Text = "Trang chủ giáo viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐiểmHọcSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýGiáoViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}