using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace eLibraryManagement
{
    public partial class landloadPublisher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfLandloadExist())
            {
                Response.Write("<script>alert('This Landloard has Published Addvertisement');</scrpit>");
            }
            else
            {
                publishPost();
            }

        }


        // User difine functions

        bool checkIfLandloadExist() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM accomodation_publish WHERE publisher_id = '" + TextBox1.Text.Trim() + "';", con);

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

        void publishPost() 
        {

            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                string latitude = Latitude.Value;
                string longitude = Longitude.Value;

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

                    SqlCommand cmd = new SqlCommand("INSERT INTO accomodation_publish(publisher_id,contact,email,city,full_address,latitude,longitude,img_link) VALUES(@publisher_id,@contact,@email,@city,@full_address,@latitude,@longitude,@img_link)", con);

                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@latitude", latitude);
                    cmd.Parameters.AddWithValue("@longitude", longitude);
                    cmd.Parameters.AddWithValue("@img_link", imgepath);

                    //Execute the querry 

                    cmd.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Addvertisement added Successful');", true);

                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

    }
}