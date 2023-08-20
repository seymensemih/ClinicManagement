using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class wbislem
    {

        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\username\Desktop\ClinicManagement\ClinicManagement.mdf;Integrated Security=True;Connect Timeout=30";

        public static bool dokVarmi(int tcNo, string sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Doktorlar where TcNo=@ptcno and DokSifre=@ps";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcNo);
            komut.Parameters.AddWithValue("@ps", sifre);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }

        public static bool eczVarmi(int tcNo, string sifre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Eczane where TcNo=@ptcno and EcSifre=@ps";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcNo);
            komut.Parameters.AddWithValue("@ps", sifre);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }

        public static DataSet randcek(int dokid, string tarih)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Randevular where DoktorID=@dokid and RandTarih=@tarih";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@dokid", dokid);
            komut.Parameters.AddWithValue("@tarih", tarih);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet randds = new DataSet();
            baglanti.Open();
            adaptor.Fill(randds);
            baglanti.Close();
            return randds;

        }

        public static DataSet doktoridal(int tcno)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select DoktorID,DokAdi+' '+DoktorSoyadi as dadiSoyadi from Doktorlar where TcNo=@ptcno";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet randds = new DataSet();
            baglanti.Open();
            adaptor.Fill(randds);
            baglanti.Close();
            return randds;

        }
        public static DataSet randList()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Randevular";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet randds = new DataSet();
            baglanti.Open();
            adaptor.Fill(randds);
            baglanti.Close();
            return randds;

        }

        public static DataSet DoktorCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select DoktorID, DokAdi+' '+DoktorSoyadi as doktoradSoyadi from Doktorlar";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet doktords = new DataSet();
            baglanti.Open();
            adaptor.Fill(doktords);
            baglanti.Close();
            return doktords;

        }

        public static DataSet tahlilCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Tahlil";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            baglanti.Open();
            adaptor.Fill(ds);
            baglanti.Close();
            return ds;

        }

        public static DataSet hastalikCek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Hastalik";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            baglanti.Open();
            adaptor.Fill(ds);
            baglanti.Close();
            return ds;

        }

        public static DataSet ilacCek(int ilacid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from ilaclar where HastalikID=" + ilacid;
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

        public static void hastalikEkle(int tcno, int hastalikid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into Muayene(TcNo,HastalikID) values(@ptcno,@phastalikid)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@phastalikid", hastalikid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void tahlilEkle(int tcno, int tahlilid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into HastaTahlil(TcNo,TahlilID) values(@ptcno,@ptahlilid)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@ptahlilid", tahlilid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void receteEkle(string tarih,int dokid,int tcno,int hasid,int ilacid,int ilacad)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into Recete(ReceteTarih,DoktorID,TcNo,HastalikID,ilacID,ilacAdet) values(@rtarih,@pdokid,@ptcno,@phasid,@pilacid,@pilacad)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@rtarih", tarih);
            komut.Parameters.AddWithValue("@pdokid", dokid);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@phasid", hasid);
            komut.Parameters.AddWithValue("@pilacid", ilacid);
            komut.Parameters.AddWithValue("@pilacad", ilacad);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static bool tahlilVarmi(int tcNo,int tahid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from HastaTahlil where TcNo=@ptcno and TahlilID=@tahid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcNo);
            komut.Parameters.AddWithValue("@tahid", tahid);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }

        public static bool hastalikVarmi(int tcNo, int hasid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Muayene where TcNo=@ptcno and HastalikID=@hasid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcNo);
            komut.Parameters.AddWithValue("@hasid", hasid);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }

        public static bool receteVarmi(string tarih,int tcNo, int ilacid)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Recete where ReceteTarih=@rtarih and TcNo=@ptcno and ilacID=@ilacid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@rtarih", tarih);
            komut.Parameters.AddWithValue("@ptcno", tcNo);
            komut.Parameters.AddWithValue("@ilacid", ilacid);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }

        public static DataSet ReceteCek(int tcno, string tarih)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select DokAdi+' '+DoktorSoyadi as dadisoyadi,HastaAdi+' '+HastaSoyadi as hadisoyadi,HastalikAdi,ilacAdi,ilacAdet,BirimF from Recete";
            sql += " inner join Doktorlar on Doktorlar.DoktorID=Recete.DoktorID inner join Hasta on Hasta.TcNo=Recete.TcNo";
            sql += " inner join Hastalik on Hastalik.HastalikID=Recete.HastalikID inner join ilaclar on ilaclar.ilacID=Recete.ilacID";
            sql += " where Recete.TcNo=@ptcno and ReceteTarih=@ptarih";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ptcno", tcno);
            komut.Parameters.AddWithValue("@ptarih", tarih);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            baglanti.Open();
            adaptor.Fill(ds);
            baglanti.Close();
            return ds;

        }

        public static bool rvarmi(string tarih, int tcNo)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Recete where ReceteTarih=@rtarih and TcNo=@ptcno";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@rtarih", tarih);
            komut.Parameters.AddWithValue("@ptcno", tcNo);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();

            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }

        public static bool randvarmi(int dokid, string tarih)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Randevular where DoktorID=@dokid and RandTarih=@rtarih";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@dokid", dokid);
            komut.Parameters.AddWithValue("@rtarih", tarih);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;

            return sonuc;


        }
    }
}