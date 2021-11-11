using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal_Apogee
{
    public partial class Upload : System.Web.UI.Page
    {
        AccessCode ac = new AccessCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                System.Web.HttpPostedFile file = Request.Files["FileUpload"];

                //CHECK IF A FILE HAS BEEN SELECTED.
                if ((FileUpload.HasFile))
                {
                    if (!Convert.IsDBNull(FileUpload.PostedFile) &
                            FileUpload.PostedFile.ContentLength > 0)
                    {
                        //SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                        FileUpload.SaveAs(Server.MapPath(".") + "\\" + FileUpload.FileName);

                        // SET A CONNECTION WITH THE EXCEL FILE.
                        OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + FileUpload.FileName +
                        ";Extended Properties=Excel 12.0;");
                        try
                        {
                            myExcelConn.Open();

                            // GET DATA FROM EXCEL SHEET.
                            OleDbCommand objOleDB =
                                new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                            // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                            OleDbDataReader objBulkReader = null;
                            objBulkReader = objOleDB.ExecuteReader();

                            DataTable dt = new DataTable();
                            dt.Load(objBulkReader);

                            // FINALLY, BIND THE EXTRACTED DATA TO THE GRIDVIEW.
                            dv_Accesscode.DataSource = dt;
                            dv_Accesscode.DataBind();

                        }
                        catch (Exception ex)
                        {
                            // SHOW ERROR MESSAGE, IF ANY.
                        }
                        finally
                        {
                            // CLEAR.
                            myExcelConn.Close(); myExcelConn = null;
                        }
                    }
                }

            }
        }


        protected void FileUpload_Init(object sender, EventArgs e)
        {



        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {

            bool ValidateAC = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("ac", typeof(string));

            foreach (GridViewRow gvrow in dv_Accesscode.Rows)
            {
                string acs = gvrow.Cells[0].Text;

                if (!ac.Existe("select count(*) from accesscode where ac = '" + acs.Trim() + "'"))
                {
                    dt.Rows.Add(acs);

                }
                else
                {
                    ValidateAC = true;
                    break;

                }

            }

            if (ValidateAC == false)
            {
                ExistAccessCode(dt);

            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Access Codes already upload!\nPlease check the file!');", true);

            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "Access Codes already upload!/nPlease check the file!", true);



        }

        private bool ExistAccessCode(DataTable dt)
        {
            bool exist = false;


            using (SqlConnection con = new SqlConnection(ac.Con1.ConnectionString))
            {


                con.Open();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(ac.Con1.ConnectionString);
                //Give your Destination table name
                sqlBulk.DestinationTableName = "accesscode";
                sqlBulk.ColumnMappings.Add("ac", "ac");
                sqlBulk.WriteToServer(dt);
                con.Close();
            }

            return exist;
        }

        protected void btn_Upload_Click1(object sender, EventArgs e)
        {

        }
    }

}