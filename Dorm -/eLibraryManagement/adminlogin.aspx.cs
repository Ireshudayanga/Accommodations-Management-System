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
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM admin_tbl WHERE username = '" + TextBox1.Text.Trim() + "' AND password = '" + TextBox2.Text.Trim() + "'", conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["full_name"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+ex.Message+"')", true);
            }

        }
    }
}