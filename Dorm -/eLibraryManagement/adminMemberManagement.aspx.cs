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
    public partial class memberManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e) 
        {
            GridView1.DataBind();
            
        }


        // Search button
        protected void Button1_Click1(object sender, EventArgs e)
        {
            getMemberbyId();
            GridView1.DataBind();
        }


        // Active  button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateStatus("Active");
            clearForm();
            GridView1.DataBind();
            
        }

        // Pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateStatus("Pending");
            GridView1.DataBind();
        }
        // Deactive Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateStatus("Deactive");
            GridView1.DataBind();
        }

        // permenently delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            PermenentlyDelete();
            GridView1.DataBind();
        }

        // User Difine Functions

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
                "SELECT * FROM member_signup WHERE username = '" + TextBox1.Text.Trim() + "'", conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox3.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox2.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox12.Text = dr.GetValue(7).ToString();
                    }
                  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid username')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }


      /*  void UpdateUserStatus( String status ) 
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "UPDATE member_signup SET account_status = '" + status + "' WHERE username = '" + TextBox1.Text.Trim() + "' ", conn);

                cmd.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Member Status Updated ')", true);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        */

        void UpdateStatus(String status) 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_signup SET account_status=@account_status WHERE username='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@account_status", status);


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

        void clearForm() 
        {
            TextBox1.Text = string.Empty;
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

                SqlCommand cmd = new SqlCommand("DELETE FROM member_signup WHERE username ='" + TextBox1.Text.Trim() + "'", con);

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