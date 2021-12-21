using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusBiletSatisOtomasyonu
{
    public partial class biletcikti : Form
    {
        public biletcikti()
        {
            
            InitializeComponent();
        }

        private void biletcikti_Load(object sender, EventArgs e)
        {
            txt_TcKimlik.Text = adminPanel.tc;
            txt_Satisİsim.Text = adminPanel.isim;
            txt_SatisSoyİsim.Text = adminPanel.soyisim;
            txt_cinsiyet.Text = adminPanel.cins;
            txt_nereden.Text = adminPanel.nereden;
            txt_nereye.Text = adminPanel.nereye;
            txt_seferSaati.Text = adminPanel.saat;
            txt_koltukno.Text = adminPanel.kno;
            textBox6.Text = adminPanel.fiyat;
            lbl_tarih.Text = adminPanel.tarih;

            this.reportViewer1.RefreshReport();
        }
    }
}
