
namespace OtobusBiletSatisOtomasyonu
{
    partial class anaMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kullanıcıGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminGirişToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıGirişiToolStripMenuItem,
            this.adminGirişToolStripMenuItem,
            this.yeniKayıtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Sitka Heading", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bilet Satış Otomasyonu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OtobusBiletSatisOtomasyonu.Properties.Resources.temsa_maraton_coach_bus;
            this.pictureBox1.Location = new System.Drawing.Point(0, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(766, 511);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // kullanıcıGirişiToolStripMenuItem
            // 
            this.kullanıcıGirişiToolStripMenuItem.Image = global::OtobusBiletSatisOtomasyonu.Properties.Resources.admin;
            this.kullanıcıGirişiToolStripMenuItem.Name = "kullanıcıGirişiToolStripMenuItem";
            this.kullanıcıGirişiToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.kullanıcıGirişiToolStripMenuItem.Text = "Kullanıcı Girişi";
            this.kullanıcıGirişiToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıGirişiToolStripMenuItem_Click);
            // 
            // adminGirişToolStripMenuItem
            // 
            this.adminGirişToolStripMenuItem.Image = global::OtobusBiletSatisOtomasyonu.Properties.Resources.user_avatar_with_check_mark;
            this.adminGirişToolStripMenuItem.Name = "adminGirişToolStripMenuItem";
            this.adminGirişToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.adminGirişToolStripMenuItem.Text = "Admin Giriş";
            this.adminGirişToolStripMenuItem.Click += new System.EventHandler(this.adminGirişToolStripMenuItem_Click);
            // 
            // yeniKayıtToolStripMenuItem
            // 
            this.yeniKayıtToolStripMenuItem.Image = global::OtobusBiletSatisOtomasyonu.Properties.Resources.add_new_plus_user_icon__icon_search_engine_32;
            this.yeniKayıtToolStripMenuItem.Name = "yeniKayıtToolStripMenuItem";
            this.yeniKayıtToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.yeniKayıtToolStripMenuItem.Text = "Yeni Kayıt";
            this.yeniKayıtToolStripMenuItem.Click += new System.EventHandler(this.yeniKayıtToolStripMenuItem_Click);
            // 
            // anaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 535);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "anaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilet Satış Otomasyonu";
            this.Load += new System.EventHandler(this.anaMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıGirişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminGirişToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem yeniKayıtToolStripMenuItem;
    }
}