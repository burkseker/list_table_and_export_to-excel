using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrnekWebUygulamasi
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        private DataTable xx = new DataTable();
        private GridView gridView = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            Newtable();
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

            DetailsView1.DataSource = xx;
            DetailsView1.DataBind();

        }
    }
}