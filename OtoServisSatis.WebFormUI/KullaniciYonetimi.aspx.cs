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
    public partial class KullaniciYonetimi : System.Web.UI.Page
    {
        KullaniciManager kullaniciManager = new KullaniciManager();
        RoleManager roleManager = new RoleManager();

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
                int islemSonucu = kullaniciManager.Add(
                    new Entities.Kullanici
                    {
                        Adi=txtAdi.Text,
                        Soyadi=txtSoyadi.Text,
                        EklenmeTarihi=DateTime.Now,
                        KullaniciAdi=txtKullaniciAdi.Text,
                        RolId=int.Parse(ddlKullaniciRolu.SelectedValue.ToString()),
                        Sifre=txtSifre.Text,
                        Telefon=txtTelefon.Text,
                        AktifMi=cbAktifMi.Checked,
                    });

                if (islemSonucu>0)
                {
                    Response.Redirect("KullaniciYonetimi.aspx");
                }
            }
            catch (Exception)
            {

                MessageBox("Hata Oluştu");
            }
        }

        protected void btnGucelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text != "0")
                {
                    int kulId = Convert.ToInt32(lblId.Text);
                    
                    int islemSonucu = kullaniciManager.Update(
                    new Kullanici
                    {
                        Id = kulId,
                        Adi = txtAdi.Text,
                        AktifMi = cbAktifMi.Checked,
                        EklenmeTarihi = DateTime.Now,
                        Email = txtEmail.Text,
                        KullaniciAdi = txtKullaniciAdi.Text,
                        RolId = int.Parse(ddlKullaniciRolu.SelectedValue),
                        Sifre = txtSifre.Text,
                        Soyadi = txtSoyadi.Text,
                        Telefon = txtTelefon.Text
                    }
                    );
                    if (islemSonucu > 0)
                    {
                        Response.Redirect("KullaniciYonetimi.aspx");
                    }
                }

            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Güncellenemedi!");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    int kulId = Convert.ToInt32(lblId.Text);
                    var sonuc = kullaniciManager.Delete(kulId);
                    if (sonuc > 0)
                    {
                        Response.Redirect("KullaniciYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        protected void gvKullaniclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvKullaniclar.SelectedRow;
                int kulId = Convert.ToInt32(row.Cells[1].Text);
                if (kulId > 0)
                {
                    var kullanici = kullaniciManager.Find(kulId);
                    txtAdi.Text = kullanici.Adi;
                    txtEmail.Text = kullanici.Email;
                    txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                    txtSifre.Text = kullanici.Sifre;
                    txtSoyadi.Text = kullanici.Soyadi;
                    txtTelefon.Text = kullanici.Telefon;
                    cbAktifMi.Checked = kullanici.AktifMi;
                    ddlKullaniciRolu.SelectedValue = kullanici.RolId.ToString();
                    lblEklenmeTarihi.Text = kullanici.EklenmeTarihi.ToString();
                    lblId.Text = kullanici.Id.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu!");
            }
        }

        private void Yukle()
        {
            var ozelSorgu = (from k in kullaniciManager.GetAllByInclude("Rol")
                             select new
                             {
                                 Id = k.Id,
                                 Adı = k.Adi,
                                 Soyadı = k.Soyadi,
                                 Email = k.Email,
                                 Telefon = k.Telefon,
                                 AktifMi = k.AktifMi,
                                 Kullanici_Adı = k.KullaniciAdi,
                                 Eklenme_Tarihi = k.EklenmeTarihi,
                                 Rolü = k.Rol.Adi
                             }).ToList();




            gvKullaniclar.DataSource = ozelSorgu;
            gvKullaniclar.DataBind();

            ddlKullaniciRolu.DataSource = roleManager.GetAll();
            ddlKullaniciRolu.DataBind();
        }

        //js ile ekrana veri ile ilgili mesaj çıkartır
        private void MessageBox(string mesaj = "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
    }
}