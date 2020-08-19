using Amazon.OpsWorks.Model;
using EO.Internal;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrnekWebUygulamasi
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                   
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("About");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product");
        }
    }
}