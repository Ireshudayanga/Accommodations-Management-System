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
    public partial class signup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //signup button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Do you want Submit?');</scrpit>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_signup(full_name,date_of_birth,contact,email,state,city,Postal_code,full_address,username,password,account_status) VALUES(@full_name,@date_of_birth,@contact,@email,@state,@city,@Postal_code,@full_address,@username,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Postal_code", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@username", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Signup Successful');</scrpit>");
             }

            catch (Exception ex)
            {
                Response.Write("<script>aleart('" + ex.Message + "');</script>");
            }
        }
    }
}