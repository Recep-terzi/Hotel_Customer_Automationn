using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Otopark_Kayıt_Ekleme : Form
    {
        public Otopark_Kayıt_Ekleme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otel.accdb");
        private void Form5_Load(object sender, EventArgs e)
        {

        }
        void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT*FROM otopark", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("INSERT INTO otopark(m_plaka,m_musteriadı,m_kaldıgıoda,m_telefonnumarası)VALUES(@a,@b,@c,@d)", baglanti);
                komut.Parameters.AddWithValue("@a", textBox1.Text);
                komut.Parameters.AddWithValue("@b", textBox2.Text);
                komut.Parameters.AddWithValue("@c", textBox3.Text);
                komut.Parameters.AddWithValue("@d", textBox4.Text);  
                komut.ExecuteNonQuery();
                baglanti.Close();
                Otopark_ekranı frm = new Otopark_ekranı();
           
                frm.ShowDialog();
                listele();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("UPDATE otopark SET m_plaka=@b,m_musteriadı=@c,m_kaldıgıoda=@d WHERE m_telefonnumarası=@e ", baglanti);
            komut.Parameters.AddWithValue("@b", textBox1.Text);
            komut.Parameters.AddWithValue("@c", textBox2.Text);
            komut.Parameters.AddWithValue("@d", textBox3.Text);
            komut.Parameters.AddWithValue("@e", textBox4.Text);          
            komut.ExecuteNonQuery();
            baglanti.Close();
            Otopark_ekranı frm = new Otopark_ekranı();           
            frm.ShowDialog();
            listele();
        }
    }
}
