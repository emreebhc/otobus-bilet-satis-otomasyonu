using System;
using System.Collections;
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
    public partial class koltuksec : Form 
    {
        public koltuksec(int gelensefer)
        {
            InitializeComponent();
           gelenID = gelensefer;
        }
        public koltuksec()
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");
       
        public int gelenID { get; set; }
        public static string koltukNo { get; set; }

        ArrayList koltuklar = new ArrayList();
       
        private void koltuksec_Load(object sender, EventArgs e)
        {
            
            SeferKoltukKontrol();
            koltukolustur(gelenID);
        }

        private void koltukolustur(int seferID)
        {
            
            int koltukno=1;
            for (int i = 0; i <9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button koltuk = new Button();
                    if (koltuklar.Contains(koltukno))
                    {
                        koltuk.BackColor = Color.Red;
                        koltuk.Enabled = false;
                    }
                    if (j == 2)
                        continue;
                    
                    koltuk.Height = koltuk.Width = 40;
                    koltuk.Name = "btn" + koltukno.ToString();
                    koltuk.Top = 30 + (i * 45);
                    koltuk.Left = 5 + (j * 45);
                    koltuk.Text = koltukno.ToString();
                    koltuk.Click += Koltuk_Click;

                    koltukno++;
                    
                    grpbox_Koltuk.Controls.Add(koltuk);
                }
            }
        }

        private void SeferKoltukKontrol()
        {
            baglanti.Open();
            string sql = "select * from koltukBilgi where seferid=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", gelenID);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                koltuklar.Add(dr[2]);
            }


            dr.Close();
            baglanti.Close();
        }


        private void koltuk()
        {

            ArrayList koltuklar = new ArrayList();
            List<koltuksec> koltukla2 = new List<koltuksec>();
            
        }


        private void Koltuk_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            DialogResult res = MessageBox.Show(bt.Text+" Numaralı Koltuğu Seçmek İstediğinize Emin Misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(res==DialogResult.Yes)
            {        
                koltukNo = bt.Text;
                this.Hide();




            }


        }
    }
}
