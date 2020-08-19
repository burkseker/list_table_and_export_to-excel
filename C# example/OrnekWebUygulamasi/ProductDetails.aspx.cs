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

namespace OrnekWebUygulamasi
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

        private DataTable dt = new DataTable();
        private DataTable xx = new DataTable();
        
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

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public void Newtable(int x)
        {
            string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";
            DataTable yy = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    GridView grd = new GridView();
                    grd.ID = "GridView" + x.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT  TOP 1 * FROM [selam].[Production].[Product]
                                                                Order by NEWID()", connectionString);
                    da.Fill(yy);

                    grd.DataSource = yy; // some data source
                    grd.DataBind();

                    Panel1.Controls.Add(grd);

                    
                }

                MessageBox.Show("girdi");
                MessageBox.Show(yy.Rows[0].ItemArray[0].ToString());
            }
        }

       
    }
}