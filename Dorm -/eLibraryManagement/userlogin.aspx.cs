using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //Landloard Login
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM landload_tbl WHERE landload_id = '" + TextBox3.Text.Trim() + "' AND password = '" + TextBox4.Text.Trim() + "'", conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Session["username"] = dr.GetValue(1).ToString();
                        Session["full_name"] = dr.GetValue(1).ToString();
                        Session["role"] = "landloard";

                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login Successful');window.location ='home.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid username or password')", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                
                if(conn.State == System.Data.ConnectionState.Closed ) 
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM member_signup WHERE username = '"+ TextBox1.Text.Trim()+"' AND password = '"+ TextBox2.Text.Trim() + "'",conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows) 
                {
                    while(dr.Read()) 
                    {
                        
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["full_name"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login Successful. Welcome, " + Session["username"].ToString() + "'); window.location ='home.aspx';", true);
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid username or password')", true);
                }
            }
            catch (Exception ex) 
            { 
            
            } 
            
        }

       

        // User Difined Function
    }
}