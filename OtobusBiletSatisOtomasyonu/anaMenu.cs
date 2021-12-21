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
    public partial class anaMenu : Form
    {
        public anaMenu()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KUVRHML\SQLEXPRESS;Initial Catalog=OtobusBiletSatisOtomasyon;Integrated Security=True");
        private void anaMenu_Load(object sender, EventArgs e)
        {
           

          
            



        }

        private void kullanıcıGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtobusBiletSatis giris = new OtobusBiletSatis();
            giris.Show();
            this.Hide();
        }

        private void adminGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admingirispanel admin = new admingirispanel();
            admin.Show();
            this.Hide();
        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yeniKayit yeniKayitForm = new yeniKayit();
            yeniKayitForm.Show();
            this.Hide();
        }
    }
}
