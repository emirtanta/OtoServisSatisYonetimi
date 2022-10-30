using OtoServisSatis.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtoServisSatis.WebFormUI
{
    public partial class MusteriYonetimi : System.Web.UI.Page
    {
        MusteriManager musteriManager = new MusteriManager();
        AracManager aracManager = new AracManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Yukle();
            }
        }

        

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = musteriManager.Add(new Entities.Musteri
                {
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Adres = txtAdres.Text,
                    AracId = Convert.ToInt32(cbAracId.SelectedValue),
                    Email = txtEmail.Text,
                    Notlar = txtNotlar.Text,
                    TcNo = txtTcNo.Text,
                    Telefon = txtTelefon.Text
                });

                if (sonuc>0)
                {
                    Response.Redirect("MusteriYonetimi.aspx");
                }
            }
            catch (Exception)
            {

                MessageBox("Hata oluştu");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text!="0")
                {

                    var sonuc = musteriManager.Update(new Entities.Musteri
                    {
                        Id = Convert.ToInt32(lblId.Text),
                        Adi = txtAdi.Text,
                        Soyadi = txtSoyadi.Text,
                        Adres = txtAdres.Text,
                        AracId = Convert.ToInt32(cbAracId.SelectedValue),
                        Email = txtEmail.Text,
                        Notlar = txtNotlar.Text,
                        TcNo = txtTcNo.Text,
                        Telefon = txtTelefon.Text
                    });

                    if (sonuc>0)
                    {
                        Response.Redirect("MusteriYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox("Hata oluştu");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text!="0")
                {
                    var sonuc = musteriManager.Delete(Convert.ToInt32(lblId.Text));

                    if (sonuc>0)
                    {
                        Response.Redirect("MusteriYonetimi.aspx");
                    }
                }

                else
                {
                    MessageBox("Listeden silinecek kaydı seçiniz");
                }
            }
            catch (Exception)
            {

                MessageBox("Kayıt silindi");
            }
        }

        protected void dgvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvMusteriler.SelectedRow;

                var musteri = musteriManager.Find(Convert.ToInt32(row.Cells[1].Text));

                if (musteri!=null)
                {
                    txtAdi.Text = musteri.Adi;
                    txtSoyadi.Text= musteri.Soyadi;
                    txtEmail.Text = musteri.Email;
                    txtNotlar.Text = musteri.Notlar;
                    txtTcNo.Text = musteri.TcNo;
                    txtTelefon.Text = musteri.Telefon;
                    cbAracId.SelectedValue = musteri.AracId.ToString();

                    lblId.Text = musteri.Id.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox("Hata oluştu");
            }
        }

        private void Yukle()
        {
            dgvMusteriler.DataSource = musteriManager.GetAll();
            dgvMusteriler.DataBind();

            //model dropdownlisti
            cbAracId.DataSource = aracManager.GetAll();
            cbAracId.DataTextField = "Modeli";
            cbAracId.DataValueField = "Id";
            cbAracId.DataBind();
        }

        void MessageBox(string mesaj = "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
    }
}