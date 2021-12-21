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
    public partial class yeniKayit : Form
    {
        public yeniKayit()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool deger = txt_Kontrol();
            if (deger == true)
            {
                anaMenu menu = new anaMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                DialogResult res = MessageBox.Show("Çıkmak istediğinize emin misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    anaMenu menu = new anaMenu();
                    menu.Show();
                    this.Hide();
                }
            }
        }


        private bool txt_Kontrol()
        {
            bool kontrol = false;
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == string.Empty)
                    {
                        kontrol = true;
                    }
                    else { kontrol = false; }
                }
            }
            return kontrol;
        }

        private void btn_KayitOl_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_Ad.Text == "" || txt_EmailAdress.Text == "" || txt_KayitKullaniciAdi.Text == "" || txt_KayitSifre.Text == ""||txt_Soyad.Text==""||txt_Telefon.Text=="")
                {
                    MessageBox.Show("Boş Alan Bırakılamaz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bool gelendeger = kayitKontrol();
                    if(gelendeger==false)
                    {
                        baglanti.Open();

                        string sql = "insert into giris (kullaniciAdi,sifre,ad,soyad,email,telefon) values (@kad,@sifre,@ad,@soyad,@email,@telefon)";
                        SqlCommand komut = new SqlCommand(sql, baglanti);
                        komut.Parameters.AddWithValue("@kad", txt_KayitKullaniciAdi.Text);
                        komut.Parameters.AddWithValue("@sifre", txt_KayitSifre.Text);
                        komut.Parameters.AddWithValue("@ad", txt_Ad.Text);
                        komut.Parameters.AddWithValue("@soyad", txt_Soyad.Text);
                        komut.Parameters.AddWithValue("@email", txt_EmailAdress.Text);
                        komut.Parameters.AddWithValue("@telefon", txt_Telefon.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        

                        MessageBox.Show($"{txt_KayitKullaniciAdi.Text} Adlı kullanıcı Başarılı Olarak Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temizle();
                        txt_Telefon.Text = string.Empty;


                    }
                    else
                    {
                        MessageBox.Show($"{txt_KayitKullaniciAdi.Text} Adlı kullanıcı Zaten Kayıtlı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_KayitKullaniciAdi.Text = string.Empty;
                    }

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("Sistemsel bir hata meydana geldi", "Hata ! ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



        private bool kayitKontrol()
        {
            bool kontrol = false;

            baglanti.Open();
            string sql = "select * from giris where kullaniciAdi=@kadi";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("kadi", txt_KayitKullaniciAdi.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                kontrol = true;
            }
            else
            {
                kontrol = false;
            }
            baglanti.Close();
            return kontrol;
        }


        private void temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }

        }


    }
}
