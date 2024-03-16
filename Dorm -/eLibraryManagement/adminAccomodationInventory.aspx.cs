using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class adminAccomodationInventory : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GridView1.DataBind();

        }

        //Add button
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (checkifImageExist())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' Image already exist!! ');", true);
            }
            else
            {
                addImage();
            }

            GridView1.DataBind();

        }

        //Update button
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        //Delete button
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        //User difine functions


   


      

        
        bool checkifImageExist()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM img_upload WHERE img_name = '" + TextBox1.Text.Trim() + "'", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


      

          


        //File Upload Functions

        void addImage() 
        {
            try 
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                // FILE UPLOAD TO DATABASE    FILE UPLOAD TO DATABASE    FILE UPLOAD TO DATABASE

                if (FileUpload1.HasFile)
                {
                    string pathfolder = Server.MapPath("~/Accommodation_Img/");

                    if (!Directory.Exists(pathfolder))
                    {
                        Directory.CreateDirectory(pathfolder);
                    }

                    string getfilename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(pathfolder + getfilename);

                  

                    string imgepath = "~/Accommodation_Img/" + getfilename;

                    SqlCommand cmd = new SqlCommand("INSERT INTO img_upload (img_name,img_id,img_link) VALUES(@img_name,@img_id,@img_link)", conn);

                    cmd.Parameters.AddWithValue("@img_name", "test"); // need to add datasource textboxes
                    cmd.Parameters.AddWithValue("@img_id", "test");  // need to add datasource textboxes
                    cmd.Parameters.AddWithValue("@img_link", imgepath);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Image Added Successful !! ');", true);
                    GridView1.DataBind();
                }
            } 
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}