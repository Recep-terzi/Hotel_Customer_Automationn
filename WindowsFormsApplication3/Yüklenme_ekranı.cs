using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Yüklenme_ekranı : Form
    {
        public Yüklenme_ekranı()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            timer1.Start();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac+=10;
            progressBar1.Value = sayac;
            label3.Text = "Yükleniyor...%" + progressBar1.Value.ToString();
            if (sayac >= 100)
            {
                timer1.Stop();
                Form frm2 = new Ana_ekran();
                this.Hide();
                
                frm2.Show();
            }
        }
    }
}
