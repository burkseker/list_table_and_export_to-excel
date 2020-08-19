
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime;
using System.ServiceModel.Security;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace OrnekWebUygulamasi
{
    public partial class Default : System.Web.UI.Page
    {
        private DataTable dt  = new DataTable();
        private DataTable xx = new DataTable();

        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int check = Check_is_login();
                if (check == 0)
                {
                    Response.Redirect("Login");
                }
            }
            
            
        }
        protected void btnConnectDB_Click(object sender, EventArgs e)
        {
            
            
            Create_dt();
            Liste.DataSource = dt;
            Liste.DataBind();
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
              
            Create_dt();

            Write_to_Excel(Get_file_name());
        
        }

        private string Get_file_name()
        {
            string selectedPath = "";

            Thread t = new Thread((ThreadStart)(() => {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return selectedPath;

        }
        private void Write_to_Excel(string path)
        {
           ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = excel.Workbook.Worksheets.Add("Worksheet1");
                worksheet1.Cells["A1"].LoadFromDataTable(dt, true);
                worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();

                string filename = path;

                Session["filename"] = filename;

                FileInfo excelFile = new FileInfo(filename);
                excel.SaveAs(excelFile);
 
                string message = "Excel file is recorded on " + filename;

                System.Windows.Forms.MessageBox.Show(message, "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                Process.Start(filename);
                
            }
        }

        private void Create_dt()
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                using (SqlCommand cmd = new SqlCommand())
                {

                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT *
                        FROM [selam].[Sales].[SalesOrderDetail]", connectionString);
                    da.Fill(dt);
                }
            }
        }
        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Gridview'in PageIndexChanging Eventında grid'in PageIndex'ine seçilen
            // sayfanın numarası atanır.
            Liste.PageIndex = e.NewPageIndex;

            // Tekrar kayıtların gridview'e aktarılması sağlanır.
            Create_dt();
            Liste.DataSource = dt;
            Liste.DataBind();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Disable_Auth();
            Response.Redirect("Login");
        }

        private void Disable_Auth()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string user__name = Session["Send"].ToString();

                SqlDataAdapter da = new SqlDataAdapter(@"Update users Set IsAuth = 0
                                                    where IsAuth = 1 and Username = '" + user__name + "'", connection);

                da.Fill(dt);

            }
        }

        private int Check_is_login()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string user__name = Session["Send"].ToString();
                Label1.Text = user__name;

                SqlDataAdapter da = new SqlDataAdapter(@"Select * from users
                                                    where IsAuth = 1 and Username = '" + user__name + "'" , connection);

                da.Fill(xx);

                return xx.Rows.Count;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("brkskr04@gmail.com");
                mail.To.Add(TextBox3.Text.ToString());
                mail.Subject = "Table";
                mail.IsBodyHtml = true;
                mail.Body = ExportDatatableToHtml(dt);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("brkskr04@gmail.com", "brk1993bybrt");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Email Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string ExportDatatableToHtml(DataTable dt)
        {
            System.Text.StringBuilder strHTMLBuilder = new System.Text.StringBuilder();
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightgreen' style='font-family:Garamond; font-size:bigger'>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("About");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product");
        }
    }
}
    
