
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace OrnekWebUygulamasi
{
    public partial class Default : System.Web.UI.Page
    {
        private DataTable dt  = new DataTable();

        protected void btnConnectDB_Click(object sender, EventArgs e)
        {
            
            Create_dt();
            Liste.DataSource = dt;
            Liste.DataBind();
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
              
            Create_dt();
            Write_to_Excel();
        
        }

        private void Write_to_Excel()
        {
           ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = excel.Workbook.Worksheets.Add("Worksheet1");
                worksheet1.Cells["A1"].LoadFromDataTable(dt, true);
                worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();
                        
                DateTime currentDateTime = DateTime.Now;
                string filename = @"C:\Users\"+ Environment.UserName+"\\output" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".xlsx";
                FileInfo excelFile = new FileInfo(filename);
                excel.SaveAs(excelFile);
 
                string message = "Excel file is recorded on " + filename;

                System.Windows.Forms.MessageBox.Show(message, "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                Process.Start(filename);
                
            }
        }

        private void Create_dt()
        {
            string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

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
    }
}
    
