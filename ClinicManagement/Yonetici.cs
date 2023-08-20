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
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
            DataSet bulunanlar1 = DBislem.Doklist();
            dataGridView1.DataSource = bulunanlar1.Tables[0];

            DataSet bulunanlar2 = DBislem.killist();
            dataGridView2.DataSource = bulunanlar2.Tables[0];

            DataSet bulunanlar3 = DBislem.ilaclist();
            dataGridView3.DataSource = bulunanlar3.Tables[0];

            DataSet bulunanlar4 = DBislem.haslist();
            dataGridView4.DataSource = bulunanlar4.Tables[0];

            DataSet bulunanlar5 = DBislem.tahlist();
            dataGridView5.DataSource = bulunanlar5.Tables[0];
        }

        private void Yonetici_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = DBislem.DokBul(textBox1.Text);
            dataGridView1.DataSource = bulunanlar.Tables[0];
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = DBislem.KilBul(textBox8.Text);
            dataGridView2.DataSource = bulunanlar.Tables[0];

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = DBislem.ilacBul(textBox11.Text);
            dataGridView3.DataSource = bulunanlar.Tables[0];
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = DBislem.HasBul(textBox16.Text);
            dataGridView4.DataSource = bulunanlar.Tables[0];
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = DBislem.TahBul(textBox19.Text);
            dataGridView5.DataSource = bulunanlar.Tables[0];
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox20.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                textBox9.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox10.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                textBox12.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                textBox21.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                textBox14.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
                textBox15.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            }

        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                textBox17.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                textBox18.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
              
            }
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                textBox13.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                textBox3.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int tahid = Convert.ToInt32(textBox13.Text);
            string tahadi = textBox3.Text;
            DBislem.tahekle(tahid, tahadi);
            MessageBox.Show("Eklendi");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dokid = Convert.ToInt32(textBox2.Text);
            int klinikid = Convert.ToInt32(textBox20.Text);
            string adi = textBox4.Text;
            string soyadi = textBox5.Text;
            int tcno = Convert.ToInt32(textBox6.Text);
            string sifre = textBox7.Text;
            DBislem.dokekle(dokid, klinikid, adi, soyadi, tcno, sifre);
            MessageBox.Show("Eklendi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int klinikid = Convert.ToInt32(textBox9.Text);
            string klinikadi = textBox10.Text;
           
            DBislem.kilekle(klinikid,klinikadi);
            MessageBox.Show("Eklendi");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int ilacid = Convert.ToInt32(textBox12.Text);
            int hastalikid = Convert.ToInt32(textBox21.Text);
            string ilacadi = textBox14.Text;
            double fiyat = Convert.ToDouble(textBox15.Text);
            DBislem.ilacekle(ilacid, hastalikid,ilacadi,fiyat);
            MessageBox.Show("Eklendi");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int hastalikid = Convert.ToInt32(textBox17.Text);
            string hastalikadi =textBox18.Text;
            DBislem.hasekle(hastalikid, hastalikadi);
            MessageBox.Show("Eklendi");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int dokid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                int kilid = Convert.ToInt32(textBox20.Text);
                string adi = textBox4.Text;
                string soyadi = textBox5.Text;
                int tcno = Convert.ToInt32(textBox6.Text);
                string sifre = textBox7.Text;
                DBislem.dokguncel(dokid, kilid, adi, soyadi, tcno, sifre);
                MessageBox.Show("Güncellendi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Guncellemek Istediginiz Kisiyi Seciniz");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
            int kilid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            string kiladi = textBox10.Text;
            DBislem.kilguncel(kilid, kiladi);
            MessageBox.Show("Güncellendi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Guncellemek Istediginiz Kisiyi Seciniz");
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
             if (dataGridView1.SelectedRows.Count > 0)
            {
            int ilacid = (int)dataGridView3.SelectedRows[0].Cells[0].Value;
            int hastalikid = Convert.ToInt32(textBox21.Text);
            string ilacadi = textBox14.Text;
            double fiyat = Convert.ToDouble(textBox15.Text);
            DBislem.ilacguncel(ilacid, hastalikid, ilacadi,fiyat);
            MessageBox.Show("Güncellendi");

            }
            else
                MessageBox.Show("Lutfen Ilk Once Guncellemek Istediginiz Kisiyi Seciniz");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
            int hasid = (int)dataGridView4.SelectedRows[0].Cells[0].Value;
            string hasadi = textBox18.Text;
            DBislem.hasguncel(hasid, hasadi);
            MessageBox.Show("Güncellendi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Guncellemek Istediginiz Kisiyi Seciniz");

        

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                     int tahid = (int)dataGridView5.SelectedRows[0].Cells[0].Value;
                     string tahadi = textBox3.Text;
                    DBislem.hasguncel(tahid, tahadi);
            MessageBox.Show("Güncellendi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Guncellemek Istediginiz Kisiyi Seciniz");

     
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                int dokid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                DBislem.DokSil(dokid);
                MessageBox.Show("silindi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Secim Yapiniz");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                int kilid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                DBislem.KilSil(kilid);
                MessageBox.Show("silindi");

            }
            else
                MessageBox.Show("Lutfen Ilk Once Secim Yapiniz");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {


            if (dataGridView3.SelectedRows.Count > 0)
            {
                int ilacid = (int)dataGridView3.SelectedRows[0].Cells[0].Value;
                DBislem.ilacSil(ilacid);
                MessageBox.Show("silindi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Secim Yapiniz");
        }

        private void button10_Click(object sender, EventArgs e)
        {


            if (dataGridView4.SelectedRows.Count > 0)
            {
                int hasid = (int)dataGridView4.SelectedRows[0].Cells[0].Value;
                DBislem.hasSil(hasid);
                MessageBox.Show("silindi");

            }
            else
                MessageBox.Show("Lutfen Ilk Once Secim Yapiniz");
        }

        private void button13_Click(object sender, EventArgs e)
        {


            if (dataGridView5.SelectedRows.Count > 0)
            {
                int tahid = (int)dataGridView5.SelectedRows[0].Cells[0].Value;
                DBislem.tahSil(tahid);
                MessageBox.Show("silindi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Secim Yapiniz");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
