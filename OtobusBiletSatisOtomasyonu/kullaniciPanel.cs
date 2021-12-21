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
    public partial class kullaniciPanel : Form
    {
        public kullaniciPanel()
        {
            InitializeComponent();
            bilgileriDoldur();
            hesapBilgileriDoldur();
            kullaniciIDBul();

        }
        public static int kullaniciID { get; set; }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");
        string a = OtobusBiletSatis.kullaniciAdi;
        private void kullaniciPanel_Load(object sender, EventArgs e)
        {


            lbl_kullanici.Text = "Hoşgeldin  " + a;
        }



        #region Yardımcı Metotlar

        private void bilgileriDoldur()
        {
            baglanti.Open();
            string sql = "select * from giris where kullaniciAdi='" + a + "'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader rd;
            string c;
            rd = komut.ExecuteReader();
            while (rd.Read())
            {
                txtkb_ad.Text = rd["ad"].ToString();
                txtkb_soyad.Text = rd["soyad"].ToString();
                txtkb_tc.Text = rd["tckimlik"].ToString();
                txtkb_Yas.Text = rd["yas"].ToString();
                mtx_telKB.Text = rd["telefon"].ToString();
                c = rd["cinsiyet"].ToString();

                if (c.ToLower().Trim() == "erkek" || c.ToLower().Trim() == "bay")
                {
                    rdb_erkekKB.Checked = true;
                }
                if (c.ToLower().Trim() == "kadın" || c.ToLower().Trim() == "bayan")
                {
                    rdb_kadinKB.Checked = true;
                }

            }



            baglanti.Close();
        }

        private void hesapBilgileriDoldur()
        {
            baglanti.Open();
            string sql = "select * from giris where kullaniciAdi='" + a + "'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader rd;
            rd = komut.ExecuteReader();

            while (rd.Read())
            {

                txt_kullaniciAdi.Text = rd["kullaniciAdi"].ToString();
                txt_Sifre.Text = rd["sifre"].ToString();
                txt_email.Text = rd["email"].ToString();

            }

            baglanti.Close();
        }

        private bool grpKontrolBos()
        {
            bool kontrol = false;
            foreach (var item in gbox_kBilgi.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    if (tbox.Text == "")
                    {
                        MessageBox.Show("Boş Alan Bırakılamaz", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = true;

                        break;
                    }
                }
            }
            return kontrol;
        }


        #endregion






        private void chk_Doldur_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Doldur.Checked)
            {
                baglanti.Open();

                string sql = "select * from giris where kullaniciAdi='" + a + "'";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                SqlDataReader rd;
                rd = komut.ExecuteReader();
                string c;
                while (rd.Read())
                {
                    txt_TcKimlik.Text = rd[7].ToString();
                    txt_Satisİsim.Text = rd[3].ToString();
                    txt_SatisSoyİsim.Text = rd[4].ToString();
                    txt_SatisYas.Text = rd[8].ToString();
                    txt_SatisTelefon.Text = rd[6].ToString();
                    txt_SatisEmail.Text = rd[5].ToString();
                    c = rd["cinsiyet"].ToString();

                    if (c.ToLower().Trim() == "erkek" || c.ToLower().Trim() == "bay")
                    {
                        rbtn_Bay.Checked = true;
                    }
                    if (c.ToLower().Trim() == "kadın" || c.ToLower().Trim() == "bayan")
                    {
                        rbtn_Bayan.Checked = true;
                    }


                }
            }

            if (chk_Doldur.Checked == false)
            {
                txt_Satisİsim.Text = string.Empty;
                txt_TcKimlik.Text = string.Empty;
                txt_SatisSoyİsim.Text = string.Empty;
                txt_SatisYas.Text = string.Empty;
                txt_SatisTelefon.Text = string.Empty;
                txt_SatisEmail.Text = string.Empty;
                rbtn_Bay.Checked = false;
                rbtn_Bayan.Checked = false;
            }
            baglanti.Close();
        }

        private void cmb_Nereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gelendeger = cmb_Nereden.Text;
            cmb_Nereye.Items.Clear();
            string sql = "select distinct nereye from seferBilgi where nereden='" + gelendeger + "'";
            baglanti.Open();

            SqlDataReader rd;
            SqlCommand komut = new SqlCommand(sql, baglanti);
            rd = komut.ExecuteReader();
            while (rd.Read())
            {
                cmb_Nereye.Items.Add(rd[0].ToString());
            }



            baglanti.Close();
        }

        private void cmb_Nereye_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gelendeger2 = cmb_Nereye.Text;

            cmb_SeferSaatleri.Items.Clear();
            string sql = "select sefersaati from seferBilgi where nereden='" + cmb_Nereden.Text + "' and nereye='" + gelendeger2 + "'";
            baglanti.Open();

            SqlDataReader rd;
            SqlCommand komut = new SqlCommand(sql, baglanti);
            rd = komut.ExecuteReader();
            while (rd.Read())
            {
                cmb_SeferSaatleri.Items.Add(rd[0].ToString());
            }
            baglanti.Close();
        }


        //Çıkış yapma butonu
        private void button4_Click(object sender, EventArgs e)
        {
            anaMenu cikis = new anaMenu();
            DialogResult res2 = MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res2 == DialogResult.Yes)
            {
                cikis.Show();
                this.Hide();
            }
            else { }
        }


        //Bilgileri Güncelleme
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"{a} bilgilerini güncellemek istediğine emin misin ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
            {
                baglanti.Open();
                string sql = "update giris set sifre=@pasw , email=@mail  where id='" + kullaniciID + "'";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@pasw", txt_Sifre.Text);
                komut.Parameters.AddWithValue("@mail", txt_email.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                hesapBilgileriDoldur();
                MessageBox.Show("Bilgileriniz Güncellenmiştir ", "Tebrikler", MessageBoxButtons.OK);
            }
        }


        private void kullaniciIDBul()
        {
            baglanti.Open();
            string sql = "select id from giris where kullaniciAdi='" + a + "'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader rd;
            rd = komut.ExecuteReader();
            string c;
            while (rd.Read())
            {

                kullaniciID = rd["id"].GetHashCode();


            }
            baglanti.Close();
        }

        //bilgileri kaydet tc - yas
        private void btn_bilgiKaydet_Click(object sender, EventArgs e)
        {


            baglanti.Open();

            string sql = "update giris set tckimlik=@tc ,yas=@yas,cinsiyet=@cns where id=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@tc", txtkb_tc.Text);
            komut.Parameters.AddWithValue("@yas", txtkb_Yas.Text);
            if (rdb_erkekKB.Checked == true)
                komut.Parameters.AddWithValue("@cns", rdb_erkekKB.Text);
            if (rdb_kadinKB.Checked == true)
                komut.Parameters.AddWithValue("@cns", rdb_kadinKB.Text);
                komut.Parameters.AddWithValue("@id", kullaniciID);

            komut.ExecuteNonQuery();
            baglanti.Close();
            bilgileriDoldur();
            MessageBox.Show("Bilgiler Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if(txtkb_tc.Text!="")
            {
                txtkb_tc.Enabled = false;
            }
            if (txtkb_Yas.Text != "")
            {
                txtkb_Yas.Enabled = false;
            }
            





        }
        public string cinsiyet { get; set; }


        private void btn_rezervasyon_Click(object sender, EventArgs e)
        {
            bool gelendeger = grpKontrolBos();
            if (gelendeger == true)
            {

            }
            else if (gelendeger == false && !string.IsNullOrEmpty(txt_SatisTelefon.Text) && rbtn_Bay.Checked == true || rbtn_Bayan.Checked == true)
            {

                baglanti.Open();

                string sql = "insert into rezervasyon (kullaniciid,tckimlik,isim,soyisim,yas,telefon,email,cinsiyet,nereden,nereye,sefersaati,tarih) " +
                    "" +
                    "values (@id,@tckimlik,@isim,@soyisim,@yas,@tel,@mail,@cins,@nereden,@nereye,@sefersaati,@tarih)";

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@id", kullaniciID);
                komut.Parameters.AddWithValue("@tckimlik", txt_TcKimlik.Text);
                komut.Parameters.AddWithValue("@isim", txt_Satisİsim.Text);
                komut.Parameters.AddWithValue("@soyisim", txt_SatisSoyİsim.Text);
                komut.Parameters.AddWithValue("@yas", txt_SatisYas.Text);
                komut.Parameters.AddWithValue("@tel", txt_SatisTelefon.Text);
                komut.Parameters.AddWithValue("@mail", txt_SatisEmail.Text);

                if (rbtn_Bay.Checked == true)
                { cinsiyet = "bay"; }
                if (rbtn_Bayan.Checked == true)
                    cinsiyet = "bayan";

                komut.Parameters.AddWithValue("@cins", cinsiyet);
                komut.Parameters.AddWithValue("@nereden", cmb_Nereden.SelectedItem);
                komut.Parameters.AddWithValue("@nereye", cmb_Nereye.SelectedItem);
                komut.Parameters.AddWithValue("@sefersaati", cmb_SeferSaatleri.SelectedItem);
                komut.Parameters.AddWithValue("@tarih", dtp_tarih.Value);
                komut.ExecuteNonQuery();


                baglanti.Close();
                MessageBox.Show("Rezervasyon Oluşturuldu", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                MessageBox.Show("Boş Alan Bırakılamaz Rezervasyon Oluşturulmadı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }


    }
}

