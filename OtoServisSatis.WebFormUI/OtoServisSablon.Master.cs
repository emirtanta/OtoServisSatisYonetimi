﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtoServisSatis.WebFormUI
{
    public partial class OtoServisSablon : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //kullanıcı adı admin olmayanları login sayfasına yönlendirir
            if (Session["admin"]==null)
            {
                Response.Redirect("Login.aspx"); 
            }
        }
    }
}