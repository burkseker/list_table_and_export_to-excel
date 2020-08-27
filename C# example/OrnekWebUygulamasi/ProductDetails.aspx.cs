using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;
using System.Security.Policy;
using DocumentFormat.OpenXml.Bibliography;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using Microsoft.Office.Core;
using Microsoft.Vbe.Interop;
using ScrollBars = System.Web.UI.WebControls.ScrollBars;

namespace OrnekWebUygulamasi
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

        private DataTable dt = new DataTable();
        private DataTable xx = new DataTable();
        private GridView gridView = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            int check = 0;

            if (check == 0)
            {
                Create_dt();
                check++;
            }

        }

        private void Create_dt()
        {   
            string url = HttpContext.Current.Request.Path.ToString();
            if(url != "/ProductDetails.aspx")
            {
            string[] elements  = url.Split('/');
            HttpContext.Current.Server.UrlDecode(url);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {

                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT *
                        FROM [selam].[Production].[Product] WHERE UrlName = '" + elements[2] + "'" , connectionString);
                    da.Fill(dt);
                }
            }
            
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            }

        }

        public void Newtable()
        {
            string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT  TOP 1 * FROM [selam].[Production].[Product]
                                                                Order by NEWID()", connectionString);
                    da.Fill(xx);

                }
               

            }
            gridView.DataSource = xx;
            gridView.DataBind();

            Panel1.Controls.Add(gridView);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Newtable(); 
        }
    }
}