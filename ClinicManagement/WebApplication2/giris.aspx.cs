using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text) || String.IsNullOrEmpty(TextBox2.Text))
            {
                Label4.Text=("Lutfen Bos Alan Birakmayiniz");
            }
            else
            {

                int tcNo = Convert.ToInt32(TextBox1.Text);
                string sifre = TextBox2.Text;
                bool kontrol = wbislem.dokVarmi(tcNo, sifre);
                if (kontrol == false)
                    Label4.Text = ("Yanlis T.C. No ve/veya Sifre");
                else
                {

                    Session["DokGiris"] = true;
                    Session["TcNo"] = tcNo;
                    Response.Redirect("doktorislem.aspx");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text) || String.IsNullOrEmpty(TextBox2.Text))
            {
                Label4.Text = ("Lutfen Bos Alan Birakmayiniz");
            }
            else
            {
                int tcNo = Convert.ToInt32(TextBox1.Text);
                string sifre = TextBox2.Text;
                bool kontrol = wbislem.eczVarmi(tcNo, sifre);
                if (kontrol == false)
                    Label4.Text = ("Yanlis T.C. No ve/veya Sifre");
                else
                {

                    Session["EcGiris"] = true;
                    Response.Redirect("eczaciislem.aspx");
                }
            }

        }
    }
}