using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Personel_Kayıt_Ekleme : Form
    {
        public Personel_Kayıt_Ekleme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otel.accdb");
        void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT*FROM otopark", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO personel(m_personeladi,m_personelsoyadi,m_tc,m_telefonnumarası,m_maaş,m_isebaslamatarihi)VALUES(@a,@b,@c,@d,@e,@f)", baglanti);
            komut.Parameters.AddWithValue("@a", textBox1.Text);
            komut.Parameters.AddWithValue("@b", textBox3.Text);
            komut.Parameters.AddWithValue("@c", textBox4.Text);
            komut.Parameters.AddWithValue("@d", textBox4.Text);
            komut.Parameters.AddWithValue("@e", textBox5.Text);
            komut.Parameters.AddWithValue("@f", textBox6.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("UPDATE personel SET m_personeladi=@b,m_personelsoyadi=@c,m_tc=@d,m_telefonnumarası=@e,m_maaş=@f WHERE m_isebaslamatarihi=@g ", baglanti);
            komut.Parameters.AddWithValue("@b", textBox1.Text);
            komut.Parameters.AddWithValue("@c", textBox2.Text);
            komut.Parameters.AddWithValue("@d", textBox3.Text);
            komut.Parameters.AddWithValue("@e", textBox4.Text);
            komut.Parameters.AddWithValue("@f", textBox5.Text);
            komut.Parameters.AddWithValue("@g", textBox6.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();    
            listele();        
            this.Close();                

         
            
            
            
          
        }
    }
}
