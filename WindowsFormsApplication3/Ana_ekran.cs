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
    public partial class Ana_ekran : Form
    {
        public Ana_ekran()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otel.accdb");
        void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT*FROM musteri", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void komut(string e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(e, baglanti);
            DataTable dt = new DataTable();
           da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        } 
        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Otopark_ekranı frm3 = new Otopark_ekranı();
        
            frm3.ShowDialog();
            this.Show();


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Personel_ekranı frm4 = new Personel_ekranı();
             frm4.ShowDialog();
            this.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label14.Left > -320)
            {
                label14.Left -= 10;
            }
            else
            {
                label14.Left = 493;
            }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            if (m_tc.TextLength != 11)
            {
                MessageBox.Show("Lütfen Tc Kimlik Numarası Girinizz");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("INSERT INTO musteri(id,m_adi,m_soyadi,m_tc,m_telefonnumarası,m_yasadıgısehir,m_kisisayısı,m_odano,m_giris,m_cıkıs,m_fiyat,m_araba,m_resim)VALUES(@a,@b,@c,@d,@e,@f,@g,@h,@j,@k,@l,@m,@n)", baglanti);
                komut.Parameters.AddWithValue("@a", sırano.Text);
                komut.Parameters.AddWithValue("@b", m_musteriadi.Text);
                komut.Parameters.AddWithValue("@c", m_musterisoyadi.Text);
                komut.Parameters.AddWithValue("@d", m_tc.Text);
                komut.Parameters.AddWithValue("@e", m_telefon.Text);
                komut.Parameters.AddWithValue("@f", m_yasadıgısehir.Text);
                komut.Parameters.AddWithValue("@g", m_kisisayısı.Text);
                komut.Parameters.AddWithValue("@h", m_odano.Text);
                komut.Parameters.AddWithValue("@j", m_giris.Text);
                komut.Parameters.AddWithValue("@k", m_cıkıs.Text);
                komut.Parameters.AddWithValue("@l", m_fiyat.Text);
                komut.Parameters.AddWithValue("@m", m_araba.Text);
                komut.Parameters.AddWithValue("@n", m_resim.Text);
                komut.ExecuteNonQuery();
                listele();
                baglanti.Close();
        }
            }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string m_adi = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string m_soyadi = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string m_tc= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string m_telefonnumarası = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string m_yasadıgısehir = dataGridView1.CurrentRow.Cells[6].Value.ToString();    
            string m_kisisayısı = dataGridView1.CurrentRow.Cells[7].Value.ToString();            
            string m_odano = dataGridView1.CurrentRow.Cells[8].Value.ToString();            
            string m_giris = dataGridView1.CurrentRow.Cells[9].Value.ToString();            
            string m_cıkıs = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            string m_fiyat = dataGridView1.CurrentRow.Cells[11].Value.ToString();            
            string m_araba = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            string m_otopark = dataGridView1.CurrentRow.Cells[13].Value.ToString();


            DialogResult tus = MessageBox.Show("Kayıdı Silmek İstiyor Musunuz?", "Soru Sorma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                OleDbCommand komut2 = new OleDbCommand("INSERT INTO musteri(m_adi,m_soyadi,m_tc,m_telefonnumarası,m_yasadıgısehir,m_kisisayısı,m_odano,m_giris,m_cıkıs,m_fiyat,m_araba,m_otopark)VALUES(@a,@b,@c,@d,@e,@f,@g,@h,@j,@k,@l,@m)", baglanti);
                komut2.Parameters.AddWithValue("@a",m_adi);
                komut2.Parameters.AddWithValue("@b",m_soyadi);
                komut2.Parameters.AddWithValue("@c",m_tc);
                komut2.Parameters.AddWithValue("@d",m_telefonnumarası);
                komut2.Parameters.AddWithValue("@e",m_yasadıgısehir);
                komut2.Parameters.AddWithValue("@f",m_kisisayısı);
                komut2.Parameters.AddWithValue("@g",m_odano);
                komut2.Parameters.AddWithValue("@h",m_giris);
                komut2.Parameters.AddWithValue("@n", m_resim.Text);
                komut2.Parameters.AddWithValue("@j",m_cıkıs);
                komut2.Parameters.AddWithValue("@k",m_fiyat);
                komut2.Parameters.AddWithValue("@l",m_araba);
                komut2.Parameters.AddWithValue("m", m_otopark);
                OleDbCommand komut1 = new OleDbCommand("DELETE FROM musteri WHERE id= @a", baglanti);
                komut1.Parameters.AddWithValue("@a", id);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                listele();
        }
    }
        private void m_musteriadi_TextChanged(object sender, EventArgs e)
        {
        }

        

        private void dataGridView1_CellContectClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("UPDATE musteri SET m_adi=@b,m_soyadi=@c,m_tc=@d,m_telefonnumarası=@e,m_yasadıgısehir=@f,m_kisisayısı=@g,m_odano=@h,m_giris=@j,m_cıkıs=@k,m_fiyat=@l WHERE m_araba=@m ", baglanti);
            komut.Parameters.AddWithValue("@b", m_musteriadi.Text);
            komut.Parameters.AddWithValue("@c", m_musterisoyadi.Text);
            komut.Parameters.AddWithValue("@d", m_tc.Text);
            komut.Parameters.AddWithValue("@e", m_telefon.Text);
            komut.Parameters.AddWithValue("@f", m_yasadıgısehir.Text);
            komut.Parameters.AddWithValue("@g", m_kisisayısı.Text);
            komut.Parameters.AddWithValue("@h", m_odano.Text);
            komut.Parameters.AddWithValue("@j", m_giris.Text);
            komut.Parameters.AddWithValue("@k", m_cıkıs.Text);
            komut.Parameters.AddWithValue("@l", m_fiyat.Text);
            komut.Parameters.AddWithValue("@m", m_araba.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();



        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            komut("SELECT * FROM musteri WHERE m_tc  LIKE'" + toolStripTextBox1.Text + "%'");            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label15.Left > -100)
            {
                label15.Left -= 10;
            }
            else
            {
                label15.Left = 450;
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
            {
               
            }

            private void button1_Click(object sender, EventArgs e)
            {
              
            }

            private void toolStripButton7_Click_1(object sender, EventArgs e)
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Tüm Dosyalar |*.*";
                dosya.ShowDialog();
                string dosyayolu = dosya.FileName;
                m_resim.Text = dosyayolu;
                pictureBox1.ImageLocation = dosyayolu;
                
                
            }

            private void m_otopark_TextChanged(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click_1(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                sırano.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                m_musteriadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                m_musterisoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                m_tc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                m_telefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                m_yasadıgısehir.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                m_kisisayısı.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                m_odano.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                m_giris.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                m_cıkıs.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                m_fiyat.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                m_araba.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                m_resim.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            }
        }
    }

