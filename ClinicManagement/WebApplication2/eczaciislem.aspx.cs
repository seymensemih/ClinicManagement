using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class eczaciislem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["EcGiris"]) != true)
                Response.Redirect("giris.aspx?msg=Oncelikle giris yapmalisiniz");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tcno = Convert.ToInt32(TextBox1.Text);
            string tarih = Calendar1.SelectedDate.ToShortDateString();
            bool kontrol = wbislem.rvarmi(tarih, tcno);

            if (kontrol == true)
            {
            DataSet recete = wbislem.ReceteCek(tcno, tarih);
            GridView1.DataSource = recete.Tables[0];
            GridView1.DataBind();
                Label3.Text = "Goruntulendi";
                TextBox8.Text = "0";

                int a = GridView1.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    GridViewRow satirnesnesi = GridView1.Rows[i];
                    double ilacadet = Convert.ToDouble(((TextBox)satirnesnesi.FindControl("TextBox6")).Text);
                    double fiyat = Convert.ToDouble(((TextBox)satirnesnesi.FindControl("TextBox7")).Text);
                    double toplam = Convert.ToDouble(TextBox8.Text) + (ilacadet * fiyat);
                    TextBox8.Text = Convert.ToString(toplam);
                }

            }
            else
            {
                Label3.Text = "Bu Tarihte ve/veya Bu Hastaya  Ait Recete Bulunamadi";
                TextBox8.Text = "0";
            }
        }



        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}