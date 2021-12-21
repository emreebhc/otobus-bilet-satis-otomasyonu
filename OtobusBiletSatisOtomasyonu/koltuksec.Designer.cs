
namespace OtobusBiletSatisOtomasyonu
{
    partial class koltuksec
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
            this.grpbox_Koltuk = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.grpbox_Koltuk.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbox_Koltuk
            // 
            this.grpbox_Koltuk.Controls.Add(this.label2);
            this.grpbox_Koltuk.Controls.Add(this.label1);
            this.grpbox_Koltuk.Controls.Add(this.button2);
            this.grpbox_Koltuk.Controls.Add(this.button1);
            this.grpbox_Koltuk.Location = new System.Drawing.Point(13, 12);
            this.grpbox_Koltuk.Name = "grpbox_Koltuk";
            this.grpbox_Koltuk.Size = new System.Drawing.Size(397, 548);
            this.grpbox_Koltuk.TabIndex = 0;
            this.grpbox_Koltuk.TabStop = false;
            this.grpbox_Koltuk.Text = "Koltuk Seç";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(275, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 38);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Boş";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dolu";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Enabled = false;
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(275, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 41);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // koltuksec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 572);
            this.Controls.Add(this.grpbox_Koltuk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "koltuksec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lütfen Koltuk Seçimi Yapınız";
            this.Load += new System.EventHandler(this.koltuksec_Load);
            this.grpbox_Koltuk.ResumeLayout(false);
            this.grpbox_Koltuk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbox_Koltuk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}