using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtobusBiletSatisOtomasyonu
{
    public partial class admingirispanel : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");

       

        public admingirispanel()
        {
            InitializeComponent();
            
        }
      
        
       

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_kullaniciAdi.Text == "" || txt_sifre.Text == "")
                {
                    MessageBox.Show("Boş bırakmayınız");
                }


                baglanti.Open();
                string sql = "select * from adminGiris where kullaniciAd=@kullaniciAD and kullaniciSifre=@sifre ";
                SqlParameter prm1 = new SqlParameter("@kullaniciAD", txt_kullaniciAdi.Text.Trim());
                SqlParameter prm2 = new SqlParameter("@sifre", txt_sifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);



                if (dt.Rows.Count > 0)
                {
                    adminPanel menu = new adminPanel();
                    menu.Show();
                    this.Hide();
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı ", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            anaMenu menu = new anaMenu();
            menu.Show();
            this.Hide();

        }


        


    }
}
