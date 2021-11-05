using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Otopark_ekranı : Form
    {
        public Otopark_ekranı()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otel.accdb");
        void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT*FROM otopark", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            listele();
            timer1.Start();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Otopark_Kayıt_Ekleme frm = new Otopark_Kayıt_Ekleme();
            frm.button2.Visible = false;
            this.Hide();
            frm.ShowDialog();
            this.Show();
            listele();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
 
            DialogResult tus = MessageBox.Show("Kayıdı Silmek İstiyor Musunuz?", "Soru Sorma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {             
                OleDbCommand komut3 = new OleDbCommand("DELETE FROM otopark WHERE id= @a", baglanti);
                komut3.Parameters.AddWithValue("@a", id);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Otopark_Kayıt_Ekleme frm = new Otopark_Kayıt_Ekleme();
            frm.button1.Visible = false;          
            frm.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            listele();

            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Left > -500)
            {
                label1.Left -= 10;
            }
            else
            {
                label1.Left = 600;
            }
        }
    }
}
