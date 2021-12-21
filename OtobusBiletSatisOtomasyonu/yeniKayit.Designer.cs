
namespace OtobusBiletSatisOtomasyonu
{
    partial class yeniKayit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ad = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Telefon = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_KayitOl = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_KayitSifre = new System.Windows.Forms.TextBox();
            this.txt_KayitKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txt_EmailAdress = new System.Windows.Forms.TextBox();
            this.txt_Soyad = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad :";
            // 
            // txt_Ad
            // 
            this.txt_Ad.Location = new System.Drawing.Point(80, 43);
            this.txt_Ad.Name = "txt_Ad";
            this.txt_Ad.Size = new System.Drawing.Size(100, 20);
            this.txt_Ad.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.groupBox1.Controls.Add(this.txt_Telefon);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btn_KayitOl);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_KayitSifre);
            this.groupBox1.Controls.Add(this.txt_KayitKullaniciAdi);
            this.groupBox1.Controls.Add(this.txt_EmailAdress);
            this.groupBox1.Controls.Add(this.txt_Soyad);
            this.groupBox1.Controls.Add(this.txt_Ad);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 352);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kayıt Formu";
            // 
            // txt_Telefon
            // 
            this.txt_Telefon.Location = new System.Drawing.Point(80, 153);
            this.txt_Telefon.Mask = "(999) 000-0000";
            this.txt_Telefon.Name = "txt_Telefon";
            this.txt_Telefon.Size = new System.Drawing.Size(100, 20);
            this.txt_Telefon.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OtobusBiletSatisOtomasyonu.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(207, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_KayitOl
            // 
            this.btn_KayitOl.Location = new System.Drawing.Point(80, 279);
            this.btn_KayitOl.Name = "btn_KayitOl";
            this.btn_KayitOl.Size = new System.Drawing.Size(100, 27);
            this.btn_KayitOl.TabIndex = 6;
            this.btn_KayitOl.Text = "Kayıt Ol";
            this.btn_KayitOl.UseVisualStyleBackColor = true;
            this.btn_KayitOl.Click += new System.EventHandler(this.btn_KayitOl_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Şifre :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kullanıcı Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Telefon :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-Mail :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyad :";
            // 
            // txt_KayitSifre
            // 
            this.txt_KayitSifre.Location = new System.Drawing.Point(80, 230);
            this.txt_KayitSifre.Name = "txt_KayitSifre";
            this.txt_KayitSifre.PasswordChar = '*';
            this.txt_KayitSifre.Size = new System.Drawing.Size(100, 20);
            this.txt_KayitSifre.TabIndex = 5;
            // 
            // txt_KayitKullaniciAdi
            // 
            this.txt_KayitKullaniciAdi.Location = new System.Drawing.Point(80, 192);
            this.txt_KayitKullaniciAdi.Name = "txt_KayitKullaniciAdi";
            this.txt_KayitKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.txt_KayitKullaniciAdi.TabIndex = 4;
            // 
            // txt_EmailAdress
            // 
            this.txt_EmailAdress.Location = new System.Drawing.Point(80, 118);
            this.txt_EmailAdress.Name = "txt_EmailAdress";
            this.txt_EmailAdress.Size = new System.Drawing.Size(100, 20);
            this.txt_EmailAdress.TabIndex = 2;
            // 
            // txt_Soyad
            // 
            this.txt_Soyad.Location = new System.Drawing.Point(80, 79);
            this.txt_Soyad.Name = "txt_Soyad";
            this.txt_Soyad.Size = new System.Drawing.Size(100, 20);
            this.txt_Soyad.TabIndex = 1;
            // 
            // yeniKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(291, 392);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "yeniKayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Kullanıcı Kayıt ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Ad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_KayitOl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_KayitSifre;
        private System.Windows.Forms.TextBox txt_KayitKullaniciAdi;
        private System.Windows.Forms.TextBox txt_EmailAdress;
        private System.Windows.Forms.TextBox txt_Soyad;
        private System.Windows.Forms.MaskedTextBox txt_Telefon;
    }
}