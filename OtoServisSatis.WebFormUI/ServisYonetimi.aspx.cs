using OtoServisSatis.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtoServisSatis.WebFormUI
{
    public partial class ServisYonetimi : System.Web.UI.Page
    {
        ServisManager servisManager = new ServisManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Yukle();
            }
            
        }

        

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = servisManager.Add(new Entities.Servis
                {
                    AracPlaka=txtAracPlaka.Text,
                    AracSorunu=txtAracSorunu.Text,
                    GarantiKapsamindaMi=cbGaranti.Checked,
                    KasaTipi=txtKasaTipi.Text,
                    Marka=txtMarka.Text,
                    Model=txtModel.Text,
                    Notlar=txtNotlar.Text,
                    SaseNo=txtSaseNo.Text,
                    ServiseGelisTarihi=dtpServiseGelisTarihi.SelectedDate+DateTime.Now.TimeOfDay,
                    ServistenCikisTarihi=dtpServiseGelisTarihi.SelectedDate+DateTime.Now.TimeOfDay,
                    ServisUcreti=Convert.ToDecimal(txtServisUcreti.Text),
                    YapilanIslemler=txtYapilanIslemler.Text
                });

                if (sonuc>0)
                {
                    Response.Redirect("ServisYonetimi.aspx");
                }
            }
            catch (Exception)
            {

                MessageBox("Hata Oluştu!");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text!="0")
                {
                    var sonuc = servisManager.Update(new Entities.Servis
                    {
                        Id=Convert.ToInt32(lblId.Text),
                        AracPlaka=txtAracPlaka.Text,
                        AracSorunu=txtAracSorunu.Text,
                        GarantiKapsamindaMi=cbGaranti.Checked,
                        KasaTipi=txtKasaTipi.Text,
                        Marka=txtMarka.Text,
                        Model=txtModel.Text,
                        Notlar=txtNotlar.Text,
                        SaseNo=txtSaseNo.Text,
                        ServiseGelisTarihi=dtpServiseGelisTarihi.SelectedDate+DateTime.Now.TimeOfDay,
                        ServistenCikisTarihi=dtpServiseGelisTarihi.SelectedDate+DateTime.Now.TimeOfDay,
                        YapilanIslemler=txtYapilanIslemler.Text,
                    });

                    if (sonuc>0)
                    {
                        Response.Redirect("ServisYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox("Hata Oluştu");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text!="0")
                {
                    var sonuc = servisManager.Delete(Convert.ToInt32(lblId.Text));

                    if (sonuc>0)
                    {
                        Response.Redirect("ServisYonetimi.aspx");
                    }
                }

                else
                {
                    Tools.Araclar.MessageBox(this, "Listeden silinecek yadı seçiniz!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvServisler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var servis = servisManager.Find(Convert.ToInt32(dgvServisler.SelectedRow.Cells[1].Text));

                if (servis!=null)
                {
                    txtAracPlaka.Text = servis.AracPlaka;
                    txtAracSorunu.Text = servis.AracSorunu;
                    txtKasaTipi.Text = servis.KasaTipi;
                    txtMarka.Text = servis.Marka;
                    txtModel.Text = servis.Model;
                    txtNotlar.Text = servis.Notlar;
                    txtSaseNo.Text = servis.SaseNo;
                    txtServisUcreti.Text = servis.ServisUcreti.ToString();
                    txtYapilanIslemler.Text = servis.YapilanIslemler;
                    dtpServiseGelisTarihi.SelectedDate = servis.ServiseGelisTarihi;
                    dtpServistenCikisTarihi.SelectedDate = servis.ServistenCikisTarihi;
                    cbGaranti.Checked = servis.GarantiKapsamindaMi;

                    lblId.Text = servis.Id.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox("Hata Oluştu!");
            }
        }

        private void Yukle()
        {
            dgvServisler.DataSource = servisManager.GetAll();
            dgvServisler.DataBind();
        }

        void MessageBox(string mesaj = "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"alert('{mesaj}')", true);
        }
    }
}