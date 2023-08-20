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
    public partial class Sekreter : Form
    {
        public Sekreter()
        {
            InitializeComponent();
        }

        private void Sekreter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Sekreter_Load(object sender, EventArgs e)
        {
            DataSet klinikler = new DataSet();
            klinikler = DBislem.klinikCek();
            comboBox2.DisplayMember = "KlinikAdi";
            comboBox2.ValueMember = "KlinikID";
            comboBox2.DataSource = klinikler.Tables[0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenklinikID = (int)comboBox2.SelectedValue;
            DataSet doktorlar = new DataSet();
            doktorlar = DBislem.doktorCek(secilenklinikID);
            comboBox3.DisplayMember = "dadisoyadi";
            comboBox3.ValueMember = "DoktorID";
            comboBox3.DataSource = doktorlar.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randoktorid = (int)comboBox3.SelectedValue;
            string rantarih = dateTimePicker1.Value.ToShortDateString();
            string ransaat = comboBox5.SelectedItem.ToString();
            bool varMi = DBislem.ranKontrol(randoktorid,rantarih,ransaat);
            int tcno1 = Convert.ToInt32(textBox2.Text);
            bool hasvarmi = DBislem.hasKontrol(tcno1);
            if (varMi == false)
            {
                int tcno = Convert.ToInt32(textBox2.Text);
                string adi = textBox3.Text;
                string soyadi = textBox4.Text;
                int doktorid = (int)comboBox3.SelectedValue;
                int klinikid = (int)comboBox2.SelectedValue;
                string tarih = dateTimePicker1.Value.ToShortDateString();
                string saat = comboBox5.SelectedItem.ToString();
                DBislem.randekle(tcno, adi, soyadi, doktorid, klinikid, tarih, saat);
                if (hasvarmi == false)
                {
                    DBislem.randhasekle(adi, soyadi, tcno);
                }

                MessageBox.Show("Eklendi");
            }
            else
            {
                MessageBox.Show("Aldiginiz Randevu Tarihi ve Saati Bos Degil Lutfen Baska Bir Tarih Veya Saat Seciniz");

            }
          
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet bulunanlar = DBislem.randBul(Convert.ToInt32(textBox1.Text));
            dataGridView1.DataSource = bulunanlar.Tables[0];
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                comboBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
            int randid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            int tcno = Convert.ToInt32(textBox2.Text);
            string adi = textBox3.Text;
            string soyadi = textBox4.Text;
            int doktorid = (int)comboBox3.SelectedValue;
            int klinikid = (int)comboBox2.SelectedValue;
            string tarih = dateTimePicker1.Value.ToShortDateString();
            string saat = comboBox5.SelectedItem.ToString();
            DBislem.randGuncel(randid, tcno, adi, soyadi, doktorid, klinikid,tarih, saat);
            DBislem.hastaguncel(adi, soyadi, tcno);
            MessageBox.Show("Güncellendi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Guncellemek Istediginiz Kisiyi Seciniz");
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int tcno= (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                int ranid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                DBislem.randSil(ranid);
                DBislem.hastaSil(tcno);
                MessageBox.Show("silindi");
            }
            else
                MessageBox.Show("Lutfen Ilk Once Secim Yapiniz");
        }
    }
    }

