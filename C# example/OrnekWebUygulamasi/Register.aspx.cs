using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.ServiceModel.Channels;
using System.Diagnostics.PerformanceData;
using System.Security.Cryptography;
using System.Text;


namespace OrnekWebUygulamasi
{
    public partial class WebForm1 : System.Web.UI.Page
    {   
        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            Create_users_table();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Create_User();

        }

        private void Create_users_table()
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(@"if not exists (select * from sysobjects where name='users')
                                                                    create table users (
		                                                                User_Id INT IDENTITY(1,1) PRIMARY KEY,
		                                                                Email VARCHAR(50) UNIQUE NOT NULL,
		                                                                Username VARCHAR(50) UNIQUE NOT NULL,
		                                                                Password VARCHAR(100) NOT NULL,
                                                                        IsAuth  BIT NOT NULL DEFAULT (0));
                                                                        ", connection);
                /*SqlCommand comm = new SqlCommand(@"drop table users
                                                                        ", connection);*/

                comm.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void Create_User()
        {
                var foo = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();

                bool bar = foo.IsValid(TextBox1.Text.ToString());

                bool result = TextBox3.Text.ToString().Equals(TextBox4.Text.ToString());

                Int32 check = Check_unique(TextBox1.Text.ToString(), TextBox2.Text.ToString());

                if (!bar)
                {
                    System.Windows.Forms.MessageBox.Show("Email is not valid", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                }
                else if (!result)
                {
                    System.Windows.Forms.MessageBox.Show("Passwords didnt match! Try again.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                }
                else if (check != 0)
                {
                    System.Windows.Forms.MessageBox.Show("Email or Username is taken.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                }
                else
                {
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        connection2.Open();
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO users (Email,Username,Password)
                                                    VALUES(@Email,@Username,@Password)", connection2);

                        SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                        string hash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(TextBox3.Text.ToString())));

                        cmd.Parameters.AddWithValue("@Email", TextBox1.Text.ToString());
                        cmd.Parameters.AddWithValue("@Username", TextBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", hash);
                        cmd.ExecuteNonQuery();
                        connection2.Close();


                    }

                    System.Windows.Forms.MessageBox.Show("User is recorded.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        

        private Int32 Check_unique(string email,string username)
        {
            string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(@"select count(*) from users 
                                                    where email = '" + email +
                                                    "' or username = '" + username+"'" , connection);

                Int32 counted = (Int32) comm.ExecuteScalar();

                connection.Close();

                return counted;
            }
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}