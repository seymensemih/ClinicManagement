using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace V_ze2
{
    class DBislem
    {
        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\username\Desktop\ClinicManagement\ClinicManagement.mdf;Integrated Security=True;Connect Timeout=30";
        public static bool YogirisKontrol(int tcno, string yosifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand("select * from Yonetici where TcNo=@tcno and yoSifre=@yosifre",baglanti);
            komut.Parameters.AddWithValue("@tcno", tcno);
            komut.Parameters.AddWithValue("@yosifre",yosifre);
            DataSet sonucDS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }
         public static DataSet DokBul(string isim)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand("select * from Doktorlar where DokAdi like @padi+'%'", baglanti);
            komut.Parameters.AddWithValue("@padi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;
        }
        public static void dokekle(int dokid, int klinikid, string ad, string soyad, int tcno, string sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand("insert into Doktorlar values(@pdokid,@pklinikid,@pad,@psoyad,@ptcno,@psifre)", baglanti);
            komut.Parameters.AddWithValue("@pdokid", dokid);
            komut.Parameters.AddWithValue("@pklinikid", klinikid);
            komut.Parameters.AddWithValue("@pad", ad);
            komut.Parameters.AddWithValue("@psoyad", soyad);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@psifre", sifre);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
          }
        public static void dokguncel(int dokid, int klinikid, string ad, string soyad, int tcno, string sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand("update Doktorlar set DokSifre=@psifre,KlinikID=@pklinikid,DokAdi=@pad,DoktorSoyadi=@psoyad,TcNo=@ptcno where DoktorID=@pdokid", baglanti);
            komut.Parameters.AddWithValue("@pdokid", dokid);
            komut.Parameters.AddWithValue("@pklinikid", klinikid);
            komut.Parameters.AddWithValue("@pad", ad);
            komut.Parameters.AddWithValue("@psoyad", soyad);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@psifre", sifre);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
         }
        public static void ilacSil(int ilacid)
        {   SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand("delete from ilaclar where ilacID=@pilacid", baglanti);
            komut.Parameters.AddWithValue("@pilacid", ilacid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }



        public static bool sekgirisKontrol(int tcno, string seksifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Sekreter where TcNo=@tcno and SekSifre=@seksifre";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@tcno", tcno);
            komut.Parameters.AddWithValue("@seksifre", seksifre);
            DataSet sonucDS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }
        

        public static DataSet Doklist()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Doktorlar";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static DataSet KilBul(string isim)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Klinikler where KlinikAdi like @padi+'%'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@padi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static DataSet ilacBul(string isim)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from ilaclar where ilacAdi like @padi+'%'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@padi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static DataSet HasBul(string isim)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Hastalik where HastalikAdi like @padi+'%'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@padi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }
        public static DataSet TahBul(string isim)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Tahlil where TahlilAdi like @padi+'%'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@padi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }


        public static void DokSil(int dokid)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Doktorlar where DoktorID=@pdokid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pdokid", dokid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }


        public static void kilekle(int klinikid, string klinikadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "insert into Klinikler values(@pklinikid,@pklinikadi)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pklinikid",klinikid);
            komut.Parameters.AddWithValue("@pklinikadi", klinikadi);
            
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public static void kilguncel(int klinikid, string klinikadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "update Klinikler set KlinikAdi=@pkiladi where KlinikID=@pklinikid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pkiladi",klinikadi );
            komut.Parameters.AddWithValue("@pklinikid", klinikid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static void KilSil(int kilid)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Klinikler where KlinikID=@pkilid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pkilid", kilid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void ilacekle(int ilacid, int hastalikid, string ilacadi,double fiyat)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "insert into ilaclar values(@pilacid,@phastalikid,@pilacadi,@pfiyat)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pilacid", ilacid);
            komut.Parameters.AddWithValue("@phastalikid", hastalikid);
            komut.Parameters.AddWithValue("@pilacadi", ilacadi);
            komut.Parameters.AddWithValue("@pfiyat", fiyat);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static void ilacguncel(int ilacid, int hastalikid, string ilacadi, double fiyat)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "update ilaclar set HastalikID=@phasid,ilacAdi=@pilacadi,BirimF=@pfiyat where ilacID=@pilacid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@phasid", hastalikid);
            komut.Parameters.AddWithValue("@pilacadi",ilacadi );
            komut.Parameters.AddWithValue("@pfiyat", fiyat);
            komut.Parameters.AddWithValue("@pilacid", ilacid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }


        public static void hasekle(int hastalikid, string hastalikadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "insert into Hastalik values(@phastalikid,@phastalikadi)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@phastalikid", hastalikid);
            komut.Parameters.AddWithValue("@phastalikadi", hastalikadi);
        

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public static void hasguncel(int hasid, string hasadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "update Hastalik set HastalikAdi=@phasadi where HastalikID=@phasid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@phasadi", hasadi);
            komut.Parameters.AddWithValue("@phasid", hasid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static void hasSil(int hasid)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Hastalik where HastalikID=@phasid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@phasid", hasid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void tahekle(int tahid, string tahadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "insert into Tahlil values(@ptahid,@ptahadi)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptahid", tahid);
            komut.Parameters.AddWithValue("@ptahadi", tahadi);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static void tahguncel(int tahid, string tahadi)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "update Tahlil set TahlilAdi=@ptahadi where TahlilID=@ptahid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptahadi", tahadi);
            komut.Parameters.AddWithValue("@ptahid", tahid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public static void tahSil(int tahid)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Tahlil where TahlilID=@ptahid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptahid", tahid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static DataSet klinikCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Klinikler";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
             SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            return sonucDS;

        }

        public static DataSet doktorCek(int doktorid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select DoktorID, DokAdi+' '+DoktorSoyadi dadisoyadi from Doktorlar where KlinikID=" + doktorid;
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonuc = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuc);
            baglanti.Close();

            return sonuc;

        }
        public static void randekle(int tcno, string adi, string soyadi, int doktorid, int klinikid, string rantarih, string ransaat)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into Randevular values(@stcno,@padi,@ssoyadi,@sdoktorid,@sklinikid,@ptarih,@ssaat)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@stcno", tcno);
            komut.Parameters.AddWithValue("@padi", adi);
            komut.Parameters.AddWithValue("@ssoyadi", soyadi);
            komut.Parameters.AddWithValue("@sdoktorid", doktorid);
            komut.Parameters.AddWithValue("@sklinikid", klinikid);
            komut.Parameters.AddWithValue("@ptarih", rantarih);
            komut.Parameters.AddWithValue("@ssaat", ransaat);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static void randhasekle(string adi, string hastasoyadi, int tcno)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into Hasta values(@phastadi,@hassoyadi,@stcno)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@phastadi", adi);
            komut.Parameters.AddWithValue("@hassoyadi", hastasoyadi);
            komut.Parameters.AddWithValue("@stcno", tcno);
          
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static bool ranKontrol(int doktorid, string tarih, string saat)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Randevular where DoktorID=@rdoktorid and RandTarih=@rtarih and RandSaati=@rsaat";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@rdoktorid", doktorid);
            komut.Parameters.AddWithValue("@rtarih", tarih);
            komut.Parameters.AddWithValue("@rsaat", saat);
            DataSet sonucDS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;




        }

        public static DataSet randBul(int tcno)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Randevular where TcNo like @ptcno";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static void randGuncel(int randid, int tcno, string adi,string soyadi,int doktorid,int klinikid, string tarih, string saat)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "update Randevular set TcNo=@ptcno,Adi=@padi,Soyadi=@psoyad,DoktorID=@pdokid,KlinikID=@pklinikid,RandTarih=@randtarih,RandSaati=@randsaat where RandevuID=@prandid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@padi", adi);
            komut.Parameters.AddWithValue("@psoyad", soyadi);
            komut.Parameters.AddWithValue("@pdokid", doktorid);
            komut.Parameters.AddWithValue("@pklinikid", klinikid);
            komut.Parameters.AddWithValue("@randtarih", tarih);
            komut.Parameters.AddWithValue("@randsaat", saat);
            komut.Parameters.AddWithValue("@prandid", randid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public static void randSil(int randid)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Randevular where RandevuID=@ranid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ranid", randid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static DataSet killist()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Klinikler";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }
        public static DataSet ilaclist()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from ilaclar";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static DataSet haslist()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Hastalik";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static DataSet tahlist()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Tahlil";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;

        }

        public static bool hasKontrol(int tcno)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Hasta where TcNo=@tcno";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@tcno",tcno);
            DataSet sonucDS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
             }

        public static void hastaguncel(string adi, string soyadi,int tcno2)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);


            string sql = "update Hasta set HastaAdi=@hadi,HastaSoyadi=@hasadi where TcNo=@tcno";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@hadi", adi);
            komut.Parameters.AddWithValue("@hasadi", soyadi);
             komut.Parameters.AddWithValue("@tcno", tcno2);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }


        public static void hastaSil(int tcno)
        {

            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Hasta where TcNo=@tcno";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@tcno", tcno);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

    }
}
