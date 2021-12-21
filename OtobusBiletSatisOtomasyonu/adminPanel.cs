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
using System.Globalization;

namespace OtobusBiletSatisOtomasyonu
{
    public partial class adminPanel : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");

        public adminPanel()
        {
            InitializeComponent();
            kayitliKullanicilariGetir();
            kayitGetir();
            kayitGosterSefer();
            satilanBiletleriGetir();
            rezervasyonGetir();
        }
        #region BiletSatis
        public static string tc{ get; set; }
        public static string isim{ get; set; }
        public static string soyisim{ get; set; }
        public static string cins{ get; set; }
        public static string nereden{ get; set; }
        public static string nereye{ get; set; }
        public static string saat{ get; set; }
        public static string kno{ get; set; }
        public static string fiyat{ get; set; }
        public static string tarih{ get; set; }



        #endregion

        public string secilenKoltukNo { get; set; }
        public  static int seferID { get;  set; }
        public int adminID { get; set; }

        //Anasayfadaki Log Out Resmi
        private void pictureBox1_Click(object sender, EventArgs e)
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


        // Kayıtlı Kullanıcılar Sayfası

        private void btn_AdminEkle_Click(object sender, EventArgs e)
        {
                     
            try
            {

                if (txt_KullaniciAdi.Text == "" || txt_Sifre.Text == "")
                {
                    MessageBox.Show( "Boş Alan Bırakılamaz","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    bool gelendeger = adminDataKontrol();
                    if (gelendeger == false)
                    {
                        baglanti.Open();
                        string sql = "insert into adminGiris (kullaniciAd,kullaniciSifre) values (@kullanici,@sifre)";
                        SqlCommand komut = new SqlCommand(sql, baglanti);
                        komut.Parameters.AddWithValue("@kullanici", txt_KullaniciAdi.Text);
                        komut.Parameters.AddWithValue("@sifre", txt_Sifre.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show($"{txt_KullaniciAdi.Text} Adlı kullanıcı Başarılı Olarak Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_KullaniciAdi.Text = string.Empty;
                        txt_Sifre.Text = string.Empty;
                        kayitliKullanicilariGetir();
                    }


                    else
                    {
                        MessageBox.Show($"{txt_KullaniciAdi.Text} Adlı kullanıcı Zaten Kayıtlı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_KullaniciAdi.Text = string.Empty;
                        txt_Sifre.Text = string.Empty;
                        lbl_AdminID.Text = string.Empty;
                    }
                }
               
            }

            catch (Exception ex2)
            {
                MessageBox.Show("Sistemsel bir hata meydana geldi", "Hata ! ", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }




        }


        //-------------------------------------------------------------------------------------------------------
        #region Yardımcı Metotlar


        
        private bool adminDataKontrol()
        {
            baglanti.Open();
            bool dtkontrol;
            string sql = "select * from adminGiris where kullaniciAd=@kad";
            
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("kad", txt_KullaniciAdi.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                dtkontrol = true;
            }
            else
            {
                dtkontrol = false;
            }
            baglanti.Close();
            return dtkontrol;
        }

        private void rezervasyonGetir()
        {
            baglanti.Open();


            string sql = "select * from rezervasyon";
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(sql, baglanti);
            dta.Fill(dt);
            dtw_rezervasyon.DataSource = dt;


            baglanti.Close();
        }


        private void kayitliKullanicilariGetir()
        {
            baglanti.Open();
            string sql = "select kullaniciAd as [Kullanıcı Adı] , kullaniciSifre as [Şifre] , id as ID from adminGiris";
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(sql, baglanti);
            dta.Fill(dt);
            dtw_KayitliAdmin.DataSource = dt;

            baglanti.Close();
        }

        private void satilanBiletleriGetir()
        {
            baglanti.Open();
            string sql = "select satisid,seferid,biletfiyat,isim,soyisim,tckimlik,yas,telefon,email,cinsiyet from satisBilgi";
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(sql, baglanti);
            dta.Fill(dt);
            dgw_satislar.DataSource = dt;

            baglanti.Close();
        }


        private void kayitGetir()
        {
            baglanti.Open();
            string sql = "select * from giris";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter dta = new SqlDataAdapter(komut);
            dta.Fill(dt);
            dtw_KayitliKullanicilar.DataSource = dt;
            baglanti.Close();
        }

        private void kayitGosterSefer()
        {
            baglanti.Open();
            string kayit = "select nereden +' - '+ nereye as [Nereden - Nereye] , tarih Tarih ,plaka Plaka , otobusadi Firma , sefersaati as[Sefer Saati] , fiyat Fiyat ,seferid from seferBilgi";

            SqlCommand komut = new SqlCommand(kayit, baglanti);


            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }


        private void searchPlaka()
        {

        }


        private string ilkHarfBuyut(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);

        }

        private bool grpKontrolBos()
        {
            bool kontrol = false;
            foreach (var item in gbox_kisiselBilgiler.Controls)
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



        private bool cmbkontrol(string value)
        {
           return  cmb_Nereden.Items.Contains(value);
        }
      
        private void fiyatdoldur()
        {
            txt_Fiyat.Text = string.Empty;
            string year = dtp_tarih.Value.Year.ToString();
            string month = dtp_tarih.Value.Month.ToString();
            string day = dtp_tarih.Value.Day.ToString();
            birlestirilmis = $"{year}-{month}-{day}";

            string gelendegersaat = cmb_SeferSaatleri.Text;
            string sql = "select fiyat from seferBilgi where nereden='" + cmb_Nereden.Text + "' and nereye='" + cmb_Nereye.Text + "' and tarih='" + birlestirilmis + "' and sefersaati='" + cmb_SeferSaatleri.Text + "'";
            baglanti.Open();

            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txt_Fiyat.Text = dr[0].ToString();
            }




            baglanti.Close();

        }

        #endregion

        //-----------------------------------------------------------------------------------------------------------




        //-------------------------------------------------------------------------------------------------------

        #region Propertyler


        public string birlestirilmis { get; set; }



        #endregion
        //-----------------------------------------------------------------------------------------------------------















        private void chk_GosterGizle_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_GosterGizle.CheckState==CheckState.Checked)
            {
                txt_Sifre.UseSystemPasswordChar = true;
                chk_GosterGizle.Text = "Göster";
            }
            else if(chk_GosterGizle.CheckState==CheckState.Unchecked)
            {
                txt_Sifre.UseSystemPasswordChar = false;
                chk_GosterGizle.Text = "Gizle";
            }
        }

        private void dtw_KayitliAdmin_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_KullaniciAdi.Text = dtw_KayitliAdmin.CurrentRow.Cells[0].Value.ToString();
            txt_Sifre.Text = dtw_KayitliAdmin.CurrentRow.Cells[1].Value.ToString();
            lbl_AdminID.Text = dtw_KayitliAdmin.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_AdminSil_Click(object sender, EventArgs e)
        {
           DialogResult res = MessageBox.Show($"{txt_KullaniciAdi.Text} Adlı Kullanıcıyı Silmek İstediğinizden Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                baglanti.Open();
                string sql = "delete from adminGiris where kullaniciAd=@kAdi";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@kAdi", txt_KullaniciAdi.Text);
                komut.ExecuteNonQuery();           
                baglanti.Close();
                kayitliKullanicilariGetir();
            }

        }

        private void btn_AdminGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"{txt_KullaniciAdi.Text} Adlı Kullanıcının Bilgilerini Güncellemek İstediğinize Emin Misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res==DialogResult.Yes)
            {
                baglanti.Open();

                string sql = "update adminGiris set kullaniciAd=@kAd ,kullaniciSifre=@kSifre where id=@id";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@kAd", txt_KullaniciAdi.Text);
                komut.Parameters.AddWithValue("@kSifre", txt_Sifre.Text);
                komut.Parameters.AddWithValue("@id", lbl_AdminID.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                kayitliKullanicilariGetir();
            }
        }

        private void btn_KullaniciSil_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Kullanıcıyı Silmek İstediğinize Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res==DialogResult.Yes)
            {
                baglanti.Open();

                string sql = "delete from giris where id=@id";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@id", dtw_KayitliKullanicilar.CurrentRow.Cells[0].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                kayitGetir();
            }





        }

        private void btn_KoltukSec_Click(object sender, EventArgs e)
        {
            koltuksec sec = new koltuksec(seferID);
            sec.ShowDialog();
            secilenKoltukNo = koltuksec.koltukNo;
            txt_KoltukNo.Text = secilenKoltukNo;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    
        private void btn_OtobusEkle_Click(object sender, EventArgs e)
        {
            string nereden1 = txt_neredenEkle.Text.ToLower();
            string neredenprm = ilkHarfBuyut(nereden1);

            string nereye2 = txt_NereyeEkle.Text.ToLower();
            string nereyeprm = ilkHarfBuyut(nereye2);




            DialogResult res = MessageBox.Show("Yeni Bir Sefer Eklemek İstediğinize Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
            {
                try
                {
                    bool kontrol =cmbkontrol(neredenprm);
                    if(kontrol==false)
                    {
                        cmb_Nereden.Items.Add(neredenprm);
                    }
                    baglanti.Open();

                    string sql = "insert into seferBilgi (nereden,nereye,tarih,plaka,otobusadi,sefersaati,fiyat) values (@nereden,@nereye,@tarih,@plaka,@otobusadi,@sefersaati,@fiyat)";
                    SqlCommand komut = new SqlCommand(sql, baglanti);


                    komut.Parameters.AddWithValue("@nereden", neredenprm);
                    komut.Parameters.AddWithValue("@nereye", nereyeprm);
                    komut.Parameters.AddWithValue("@tarih", dtp_tarihEkle.Value);
                    komut.Parameters.AddWithValue("plaka", txt_plakaEkle.Text);
                    komut.Parameters.AddWithValue("@otobusadi", txt_OtobusAdi.Text);
                    komut.Parameters.AddWithValue("@sefersaati", txt_saatEkle.Text);
                    komut.Parameters.AddWithValue("@fiyat", nud_fiyatEkle.Value);
                    komut.ExecuteNonQuery();

                    baglanti.Close();


                    MessageBox.Show($"Sefer Başarılı Olarak Eklendi ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kayitGosterSefer();

                }
                catch (Exception ex4)
                {

                    MessageBox.Show("Sistemsel bir hata meydana geldi", "Hata ! ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        #region Anasayfa ComboBox Değerleri Getirme

        private void cmb_SeferSaatleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cmb_Nereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gelendeger = cmb_Nereden.Text;
            cmb_Nereye.Items.Clear();
            string sql = "select distinct nereye from seferBilgi where nereden='" + gelendeger+"'";
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

        private void adminPanel_Load(object sender, EventArgs e)
        {

        }

        private void dtp_tarih_ValueChanged(object sender, EventArgs e)
        {
            dtp_tarih.CustomFormat = "yyyy-MM-d";
            string year = dtp_tarih.Value.Year.ToString();
            string month= dtp_tarih.Value.Month.ToString();
            string day = dtp_tarih.Value.Day.ToString();
            birlestirilmis = $"{year}-{month}-{day}";

            string gelendeger2 = cmb_Nereye.Text;
            baglanti.Open();
            string sql = "select sefersaati,tarih from seferBilgi where nereden='" + cmb_Nereden.Text + "' and nereye='" + gelendeger2 + "' and tarih='"+ birlestirilmis + "'";





            baglanti.Close();
        }


        #endregion

        private void btn_TarihSorgula_Click(object sender, EventArgs e)
        {

            if (cmb_Nereden.Text != "" || cmb_Nereye.Text != "" || cmb_SeferSaatleri.Text != "")
            {
                bool dtkontrol;
                baglanti.Open();
                string gelendeger2 = cmb_Nereye.Text;
                string sql = "select tarih,seferid from seferBilgi where nereden='" + cmb_Nereden.Text + "' and nereye='" + gelendeger2 + "' and tarih='" + birlestirilmis + "' and sefersaati='" + cmb_SeferSaatleri.Text + "'";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                SqlDataReader oku;
                oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    dtkontrol = true;
                    seferID = oku[1].GetHashCode();
                    
                }
                else
                {
                    dtkontrol = false;
                }
                baglanti.Close();

                if (dtkontrol == false)
                {
                    MessageBox.Show("Seçtiğiniz Tarihe Ait Sefer Bulunmamaktadır !", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Fiyat.Text = string.Empty;
                }
                if (dtkontrol == true)
                {
                    MessageBox.Show("Sefer Mevcut", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    fiyatdoldur();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Önce Seçim Yapınız", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (rdb_FirmaSearch.Checked)
            {
                lbl_ornekTarih.Text = string.Empty;
                baglanti.Open();
              
                string sql= "select nereden +' - '+ nereye as [Nereden - Nereye] , tarih Tarih ,plaka Plaka , otobusadi Firma , sefersaati as[Sefer Saati] , fiyat Fiyat from seferBilgi where otobusadi like '" + txt_search.Text+"%'";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(komut);
                dta.Fill(dt);
                SqlDataReader dr;
                dr = komut.ExecuteReader();
                while(dr.Read())
                {
                    dataGridView1.DataSource = dt;
                }
                baglanti.Close();
            }
            else if (rdb_plakaSearch.Checked)
            {
                lbl_ornekTarih.Text = string.Empty;
                baglanti.Open();
                string sql = "select nereden +' - '+ nereye as [Nereden - Nereye] , tarih Tarih ,plaka Plaka , otobusadi Firma , sefersaati as[Sefer Saati] , fiyat Fiyat from seferBilgi where plaka like '" + txt_search.Text + "%'";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(komut);
                dta.Fill(dt);
                SqlDataReader dr;
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.DataSource = dt;
                }



                baglanti.Close();

            }
            else if(rdb_tarihSearch.Checked)
            {
                lbl_ornekTarih.Text = "Yıl-Ay-Gün";
                baglanti.Open();
                string sql = "select nereden +' - '+ nereye as [Nereden - Nereye] , tarih Tarih ,plaka Plaka , otobusadi Firma , sefersaati as[Sefer Saati] , fiyat Fiyat from seferBilgi where tarih like '" + txt_search.Text + "%'";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                DataTable dt = new DataTable();
                SqlDataAdapter dta = new SqlDataAdapter(komut);
                dta.Fill(dt);
                SqlDataReader dr;
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.DataSource = dt;
                }



                baglanti.Close();

            }
        }

        private void btn_SeferSil_Click(object sender, EventArgs e)
        {
            
            DialogResult res = MessageBox.Show("Kayıtlı Seferi Silmek İstediğinize Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                baglanti.Open();

                string sql = "delete from seferBilgi where seferid=@id";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[6].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                kayitGosterSefer();
            }
        }

        private void btn_satisYap_Click(object sender, EventArgs e)
        {
            bool gelendeger = grpKontrolBos();
            if (gelendeger == true)
            {

            }
            // Alanlar Doluysa Yapılacak İşlemler
            else
            {
                DialogResult res = MessageBox.Show("Satış Gerçekleştirmek istediğinize emin misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    baglanti.Open();
                    string sql = "insert into koltukBilgi (seferid,koltukno) values(@sfID,@secilenkoltuk)";
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.Parameters.AddWithValue("@sfID", seferID);
                    komut.Parameters.AddWithValue("@secilenkoltuk", secilenKoltukNo);
                    komut.ExecuteNonQuery();

                    //--------------------------------------

                    string sql2 = "insert into satisBilgi (seferid,biletfiyat,isim,soyisim,tckimlik,yas,telefon,email,cinsiyet) values (@sfID,@fiyat,@name,@surname,@tc,@yas,@tel,@mail,@cins)";
                    SqlCommand komut2 = new SqlCommand(sql2, baglanti);
                    komut2.Parameters.AddWithValue("@sfID", seferID);
                    komut2.Parameters.AddWithValue("@fiyat", txt_Fiyat.Text.Replace("0",""));
                    komut2.Parameters.AddWithValue("@name", txt_Satisİsim.Text);
                    komut2.Parameters.AddWithValue("@surname", txt_SatisSoyİsim.Text);
                    komut2.Parameters.AddWithValue("@tc", txt_TcKimlik.Text);
                    komut2.Parameters.AddWithValue("@yas", txt_SatisYas.Text);
                    komut2.Parameters.AddWithValue("@tel", txt_SatisTelefon.Text);
                    komut2.Parameters.AddWithValue("@mail", txt_SatisEmail.Text);
                    if (rbtn_Bay.Checked == true)
                        komut2.Parameters.AddWithValue("@cins", rbtn_Bay.Text);
                    if (rbtn_Bayan.Checked == true)
                        komut2.Parameters.AddWithValue("@cins", rbtn_Bayan.Text);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    DialogResult res2=  MessageBox.Show("Bilet Kayıt Edildi Çıktı Almak İstiyor Musunuz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    satilanBiletleriGetir();

                    if (res2==DialogResult.Yes)
                    {
                        tc = txt_TcKimlik.Text;
                        isim = txt_Satisİsim.Text;
                        soyisim = txt_SatisSoyİsim.Text;
                        if (rbtn_Bay.Checked == true)
                            cins = rbtn_Bay.Text;
                        if (rbtn_Bayan.Checked == true)
                            cins = rbtn_Bayan.Text;
                        nereden = cmb_Nereden.Text;
                        nereye = cmb_Nereye.Text;
                        saat = cmb_SeferSaatleri.Text;
                        kno = txt_KoltukNo.Text;
                        fiyat = txt_Fiyat.Text;
                        tarih = dtp_tarih.Text;
                        biletcikti bilet = new biletcikti();
                        bilet.Show();
                    }

                }



                

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            
        }

        private void btn_rezerveIptal_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Rezervasyonu Silmek İstediğinize Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                baglanti.Open();

                string sql = "delete from rezervasyon where rezerveid=@id";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@id", dtw_rezervasyon.CurrentRow.Cells[0].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                rezervasyonGetir();
            }
        }

        //Satış İptal Butonu
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Satışı Silmek İstediğinize Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                baglanti.Open();

                string sql = "delete from satisBilgi where satisid=@id";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@id", dgw_satislar.CurrentRow.Cells[0].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                satilanBiletleriGetir();
            }
        }
    }
}
