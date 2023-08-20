using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class doktorislem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["DokGiris"]) != true)
                Response.Redirect("giris.aspx?msg=Oncelikle giris yapmalisiniz");
            else
            {
                if (!IsPostBack)
                {
                    DataSet tahlil = wbislem.tahlilCek();
                    DropDownList2.DataTextField = "TahlilAdi";
                    DropDownList2.DataValueField = "TahlilID";
                    DropDownList2.DataSource = tahlil.Tables[0];
                    DropDownList2.DataBind();
                    DataSet hastalik = wbislem.hastalikCek();
                    DropDownList3.DataTextField = "HastalikAdi";
                    DropDownList3.DataValueField = "HastalikID";
                    DropDownList3.DataSource = hastalik.Tables[0];
                    DropDownList3.DataBind();
                    int doktorid = Convert.ToInt32(Session["TcNo"]);
                    DataSet did = wbislem.doktoridal(doktorid);
                    DropDownList5.DataTextField = "dadiSoyadi";
                    DropDownList5.DataValueField = "DoktorID";
                    DropDownList5.DataSource = did.Tables[0];
                    DropDownList5.DataBind();
                    Label12.Text = Convert.ToString(DropDownList5.SelectedItem);
                    
                    
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int dokid =Convert.ToInt32(DropDownList5.SelectedValue);
            string tarih = Calendar1.SelectedDate.ToShortDateString();
           

            bool kontrol = wbislem.randvarmi(dokid, tarih);

            if (kontrol == true)
            {
                DataSet randevular = wbislem.randcek(dokid, tarih);
                GridView1.DataSource = randevular.Tables[0];
                GridView1.DataBind();
                Label10.Text = "Randevular Listelendi";
                

            }
            else
            {
                Label10.Text = "Bugun Randevunuz Bulunmamaktadir";
             
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sec")
            {
                int satirno = Convert.ToInt32(e.CommandArgument);
                GridViewRow satirnesnesi = GridView1.Rows[satirno];
                TextBox7.Text = ((TextBox)satirnesnesi.FindControl("TextBox2")).Text;
                TextBox8.Text = ((TextBox)satirnesnesi.FindControl("TextBox3")).Text;
                TextBox6.Text = ((TextBox)satirnesnesi.FindControl("TextBox4")).Text;




            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            int tcno = Convert.ToInt32(TextBox7.Text);
            int hastalikid = Convert.ToInt32(DropDownList3.SelectedValue);
             bool kontrol = wbislem.hastalikVarmi(tcno, hastalikid);
            if (kontrol == true)
            {
                Label6.Text = "Hastaya Bu Hastaligi Zaten Eklediniz";
            }
            else
            {
                wbislem.hastalikEkle(tcno, hastalikid);
                Label6.Text = "Eklendi";
            }

            int secilenhastalik = Convert.ToInt32(DropDownList3.SelectedValue);
            DataSet ilaclar = new DataSet();
            ilaclar = wbislem.ilacCek(secilenhastalik);
            DropDownList4.DataTextField = "ilacAdi";
            DropDownList4.DataValueField = "ilacID";
            DropDownList4.DataSource = ilaclar.Tables[0];
            DropDownList4.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int tcno = Convert.ToInt32(TextBox7.Text);
            int tahlilid = Convert.ToInt32(DropDownList2.SelectedValue);
            bool kontrol = wbislem.tahlilVarmi(tcno,tahlilid);
            if (kontrol == true)
            {
                Label7.Text = "Hastaya Bu Tahlili Zaten Verdiniz";
            }
            else
            {
                wbislem.tahlilEkle(tcno, tahlilid);
                Label7.Text = "Eklendi";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string tarih = Calendar1.SelectedDate.ToShortDateString();
            int dokid = Convert.ToInt32(DropDownList5.SelectedValue);
            int tcno = Convert.ToInt32(TextBox7.Text);
            int hasid = Convert.ToInt32(DropDownList3.SelectedValue);
            int ilacid = Convert.ToInt32(DropDownList4.SelectedValue);
            int ilacadet = Convert.ToInt32(TextBox9.Text);
            bool kontrol = wbislem.receteVarmi(tarih,tcno, ilacid);
            if (kontrol == true)
            {
                Label8.Text = "Hastaya Bu ilaci Zaten Verdiniz";
            }
            else
            {
                wbislem.receteEkle(tarih, dokid, tcno, hasid, ilacid, ilacadet);
                Label8.Text = "Eklendi";
            }
        }
    }
}