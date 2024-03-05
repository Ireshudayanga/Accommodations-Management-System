using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class AdminPubisherManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Add botton event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkifaccommodationexist())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User ID Already Exsist')", true);
            }
            else 
            {
                addnewresident();
            }
        }

        //Update botton event
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifaccommodationexist())
                {
                    updateresident();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Resident ID');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }


        }

        //Delete botton event
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        //Search botton event
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        //user define function

        void updateresident()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE accommodation_resident_tbl SET resident_name=@resident_name WHERE accommodation_id='"+TextBox1.Text.Trim()+"'", con);

                cmd.Parameters.AddWithValue("@resident_name", TextBox3.Text.Trim());


                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Resident Update Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void addnewresident() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO accommodation_resident_tbl(accommodation_id,resident_name) VALUES(@accommodation_id,@resident_name)", con);

                cmd.Parameters.AddWithValue("@accommodation_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@resident_name", TextBox3.Text.Trim());
                

                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Resident Added Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        bool checkifaccommodationexist() 
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM accommodation_resident_tbl WHERE accommodation_id = '" + TextBox1.Text.Trim() + "'", conn);

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
    }
}