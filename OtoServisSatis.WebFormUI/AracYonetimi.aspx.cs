using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtoServisSatis.WebFormUI
{
    public partial class AracYonetimi : System.Web.UI.Page
    {
        MarkaManager markaManager = new MarkaManager();
        AracManager aracManager = new AracManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();

        }

        void Yukle()
        {
            gvAraclar.DataSource = aracManager.GetAll();
            gvAraclar.DataBind();

            //ddlMarkalar
            ddlMarkalar.DataSource = markaManager.GetAll();
            ddlMarkalar.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = aracManager.Add(
                    new Arac
                    {
                        Fiyati=Convert.ToDecimal(txtFiyati.Text),
                        KasaTipi=txtKasaTipi.Text,
                        MarkaId=Convert.ToInt32(ddlMarkalar.SelectedValue),
                        Modeli=txtModeli.Text,
                        ModelYili=int.Parse(txtModelYili.Text),
                        Notlar=txtNotlar.Text,
                        Renk=txtRenk.Text,
                        SatistaMi=cbSatistaMi.Checked
                    });

                if (sonuc>0)
                {
                    Response.Redirect("AracYonetimi.aspx");
                }
            }

            catch (Exception)
            {

                MessageBox("Kayıt ekleme başarızı oldu");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text=="0")
                {
                    MessageBox("Listeden güncelecek kaydı seçiniz");

                }

                else
                {
                    var sonuc = aracManager.Update(new Arac 
                    {
                        Id=Convert.ToInt32(lblId.Text),
                        Fiyati=Convert.ToDecimal(txtFiyati.Text),
                        KasaTipi=txtKasaTipi.Text,
                        MarkaId=Convert.ToInt32(ddlMarkalar.SelectedValue),
                        Modeli=txtModeli.Text,
                        ModelYili=int.Parse(txtModelYili.Text),
                        Notlar=txtNotlar.Text,
                        Renk=txtRenk.Text,
                        SatistaMi=cbSatistaMi.Checked
                    });

                    if (sonuc>0)
                    {
                        Response.Redirect("AracYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox("Güncelleme başarız oldu");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text=="0")
                {
                    MessageBox("Listeden silinecek kaydı seçiniz");
                }

                else
                {
                    var sonuc = aracManager.Delete(Convert.ToInt32(lblId.Text));

                    if (sonuc>0)
                    {
                        Response.Redirect("AracYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox("Hata oluştu");
            }
        }

        //js ile ekrana veri ile ilgili mesaj çıkartır
        void MessageBox(string mesaj="")
        {
            ClientScript.RegisterStartupScript(Page.GetType(),"Uyarı",$"<script>alert('{mesaj}')</script>");
        }

        protected void gvAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAraclar.SelectedRow;

            
            try
            {
                //1=> değeri gridview içerisindeki Id kolonun numarasıdır
                lblId.Text = row.Cells[1].Text;
                int aracId = Convert.ToInt32(lblId.Text);
                var arac = aracManager.Find(aracId);

                txtFiyati.Text = arac.Fiyati.ToString();
                txtKasaTipi.Text = arac.KasaTipi;
                txtModeli.Text=arac.Modeli;
                txtModelYili.Text= arac.ModelYili.ToString();
                txtNotlar.Text = arac.Notlar;
                txtRenk.Text = arac.Renk;
                cbSatistaMi.Checked = arac.SatistaMi;
                ddlMarkalar.SelectedValue = arac.MarkaId.ToString();
            }
            catch (Exception)
            {

                MessageBox("Hata oluştu.");
            }


        }
    }
}