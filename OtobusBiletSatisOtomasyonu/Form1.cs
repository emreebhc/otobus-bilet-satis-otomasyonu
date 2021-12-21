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
    public partial class OtobusBiletSatis : Form
    {
        public static string kullaniciAdi { get; set; }
       
        public OtobusBiletSatis()
        {
            InitializeComponent();
            
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_kullaniciAdi.Text == "" || txt_sifre.Text == "")
                {
                    MessageBox.Show("Boş bırakmayınız");
                }

                baglanti.Open();
                string sql = "select * from giris where kullaniciAdi=@kAdi and sifre=@pasw ";


                SqlParameter prm1 = new SqlParameter("@kAdi", txt_kullaniciAdi.Text.Trim());
                SqlParameter prm2 = new SqlParameter("@pasw", txt_sifre.Text.Trim());
                kullaniciAdi = prm1.Value.ToString();

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(komut);
                dta.Fill(dt);

             
                if (dt.Rows.Count > 0)
                {
                    
                    kullaniciPanel menu = new kullaniciPanel();
                    menu.Show();  
                    this.Hide();
                   
                }
             

            }

            catch (Exception ex)
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
