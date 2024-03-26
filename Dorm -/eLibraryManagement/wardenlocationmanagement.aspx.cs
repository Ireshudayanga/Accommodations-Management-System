using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class wardenlocationmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            getMemberbyId();
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateStatus("active");
            

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateStatus("pending");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PermenentlyDelete();
        }

        //user difine functions 

        void getMemberbyId()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM accomodation_publish WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                   
                        TextBox7.Text = dr.GetValue(8).ToString();
                    
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox8.Text = dr.GetValue(2).ToString();
                      
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid username')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void UpdateStatus(String status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE accomodation_publish SET status=@status WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@status", status);


                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Status Update Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        void PermenentlyDelete()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM accomodation_publish WHERE publisher_id ='" + TextBox1.Text.Trim() + "'", con);

                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' Delete Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

       
    }
}