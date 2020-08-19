using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using RouteTable = System.Web.Routing.RouteTable;
using FakeItEasy;
using System.Web.Util;
using ServiceStack;

namespace OrnekWebUygulamasi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RoutingData(RouteTable.Routes);
        }

        private void RoutingData(RouteCollection routes)
        {
            routes.MapPageRoute("", "About/", "~/About.aspx");
            routes.MapPageRoute("", "About/", "~/About");
            routes.MapPageRoute("", "Home/", "~/Main.aspx");
            routes.MapPageRoute("", "Product/", "~/Product.aspx");


            routes.MapPageRoute("ProductDetails", "ProductDetails/{UrlName}", "~/ProductDetails.aspx");
            routes.MapPageRoute("", "Login/", "~/Login.aspx");
            routes.MapPageRoute("", "Register/", "~/Register.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}