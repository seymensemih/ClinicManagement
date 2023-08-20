using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V_ze2
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Lutfen Bos Alan Birakmayiniz");
            }
            else
            {
                int tcNo = Convert.ToInt32(textBox1.Text);
                string sifre = Convert.ToString(textBox2.Text);
                bool dokvarmi = DBislem.YogirisKontrol(tcNo, sifre);
                bool sekvarmi = DBislem.sekgirisKontrol(tcNo, sifre);
                if (dokvarmi == true)
                {
                    Yonetici ac = new Yonetici();
                    ac.Show();
                    this.Hide();
                }
                else if (sekvarmi == true)
                {
                    Sekreter ac = new Sekreter();
                    ac.Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Yanlis T.C. No ve/veya Sifre Girdiniz");
            }

            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:51689/giris.aspx");

            Application.Exit();
           
        }
    }
}
