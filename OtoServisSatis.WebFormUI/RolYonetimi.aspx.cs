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
    public partial class RolYonetimi : System.Web.UI.Page
    {
        RoleManager roleManager = new RoleManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            
                Yukle();
            
        }

        

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = roleManager.Add(new Entities.Rol
                {
                    Adi=txtRolAdi.Text
                });

                if (sonuc>0)
                {
                    Response.Redirect("RolYonetimi.aspx");
                }
            }
            catch (Exception)
            {

                MessageBox("Hata oluştu!");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox("Listeden güncellenecek kaydı seçiniz!");
                }
                else
                {
                    int rolId = Convert.ToInt32(lblId.Text);
                    var sonuc = roleManager.Update(
                        new Rol
                        {
                            Id = rolId,
                            Adi = txtRolAdi.Text
                        }
                        );
                    if (sonuc > 0)
                    {
                        Response.Redirect("RolYonetimi.aspx");
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
                    var sonuc = roleManager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Response.Redirect("RolYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        protected void dgvRoller_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvRoller.SelectedRow;

                lblId.Text = row.Cells[1].Text;
                txtRolAdi.Text = row.Cells[2].Text;
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Atanamadı!");
            }
        }

        private void Yukle()
        {
            dgvRoller.DataSource = roleManager.GetAll();
            dgvRoller.DataBind();
        }

        void MessageBox(string mesaj = "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
    }
}