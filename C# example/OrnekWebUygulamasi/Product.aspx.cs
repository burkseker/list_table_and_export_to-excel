using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;

namespace OrnekWebUygulamasi
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

        private DataTable dt = new DataTable();
        private DataTable xx = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            int check = Check_is_login();
            if (check == 0)
            {
                Response.Redirect("Login");
            }
            else
            {
                Create_dt();
            }
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

        private void Create_dt()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {

                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT *
                        FROM [selam].[Production].[Product]", connectionString);
                    da.Fill(dt);
                }
            }



            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        private int Check_is_login()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string user__name = Session["Send"].ToString();

                SqlDataAdapter da = new SqlDataAdapter(@"Select * from users
                                                where IsAuth = 1 and Username = '" + user__name + "'", connection);

                da.Fill(xx);

                return xx.Rows.Count;
            }
        }
    }
}