using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace OrnekWebUygulamasi
{
    public partial class WebForm2 : System.Web.UI.Page
    {   
        private DataTable dt = new DataTable();
        
        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Send"] = TextBox1.Text.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Int32 check = Check_username(TextBox1.Text.ToString());
            
            if (check==0)
            {
                System.Windows.Forms.MessageBox.Show("Username is not registered!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if (check == 1)
            {
                string password = Get_hashed_password(TextBox1.Text.ToString());


                System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                string hash = Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(TextBox2.Text.ToString())));

                bool result = hash.Equals(password);

                if (!result)
                {

                    System.Windows.Forms.MessageBox.Show("Password is wrong!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                }
                else
                {
                    Set_auth(TextBox1.Text.ToString());
                    Response.Redirect("ShowTableExportExcel.aspx");
                }
            }
        }

        private string Get_hashed_password(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlDataAdapter da = new SqlDataAdapter(@"select password from users 
                                                    where username = '" + username + "'", connection);

                da.Fill(dt);

                return dt.Rows[0].ItemArray[0].ToString();
            }
        }

        private Int32 Check_username(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand comm = new SqlCommand(@"select count(*) from users 
                                                    where username = '" + username + "'", connection);

                Int32 counted = (Int32)comm.ExecuteScalar();
        
                connection.Close();

                return counted;
            }
        }
        private void Set_auth(string username)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                

                SqlDataAdapter da = new SqlDataAdapter(@"Update users Set IsAuth = 1
                                                    where username = '" + username + "'", connection);

                da.Fill(dt);

                

            }
        }

        
    }
}