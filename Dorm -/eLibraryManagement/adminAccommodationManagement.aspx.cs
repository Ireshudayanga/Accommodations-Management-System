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
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
        }

        // User Add botton event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkifaccommodationexist())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User ID Already Exsist')", true);
            }
            else 
            {
                addnewresident();
                clearForm();

                GridView1.DataBind();
            }

           
        }

        // User Update botton event
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifaccommodationexist())
                {
                    updateresident();
                    clearForm();

                    GridView1.DataBind();
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

            clearForm();

        }

        // User Delete botton event
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifaccommodationexist())
                {
                    deleteresident();
                    clearForm();

                    GridView1.DataBind();
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

        // User Search botton event
        protected void Button1_Click(object sender, EventArgs e)
        {
            searchById();
        }



        // LandLoad Search botton event
        protected void Button5_Click(object sender, EventArgs e)
        {
            searchByIdLAndload();
        }

        // LandLoad Add botton event
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (checkifLandLoadExist())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Landloard ID Already Exsist')", true);
            }
            else
            {
                addnewLandLoard();
                clearForm();

                GridView2.DataBind();
            }
        }

        // LandLoad Update botton event
        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifLandLoadExist())
                {
                    updateLandload();
                    clearForm();

                    GridView2.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Landload ID');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }

            clearForm();
        }

        // LandLoad Delete botton event
        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifLandLoadExist())
                {
                    deleteLandload();
                    clearForm();

                    GridView2.DataBind();
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


        // Warden Search botton event
        protected void Button9_Click(object sender, EventArgs e)
        {
            searchByIdWarden(); 
        }

        // Warden add botton event
        protected void Button10_Click(object sender, EventArgs e)
        {
            {
                if (checkifWardenExist())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Warden ID Already Exsist')", true);
                }
                else
                {
                   addnewWarden();
                    clearForm();

                    GridView3.DataBind();
                }
            }
        }

        // Warden update botton event
        protected void Button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifWardenExist())
                {
                    updateWarden();
                    clearForm();

                    GridView3.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Warden ID');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }

            clearForm();
        }

        // Warden delete botton event
        protected void Button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifWardenExist())
                {
                    deleteWarden();
                    clearForm();

                    GridView3.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Warden ID');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }
       


        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>










        //user define function


        void searchById() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM accommodation_resident_tbl WHERE accommodation_id = '" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                   TextBox3.Text = dataTable.Rows[0][1].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Author Id');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }

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

        void deleteresident() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM accommodation_resident_tbl WHERE accommodation_id ='" + TextBox1.Text.Trim() + "'", con);

                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Resident Delete Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void clearForm() 
        {
            TextBox1.Text = string.Empty;
            TextBox3.Text = string.Empty;

            TextBox2.Text = string.Empty;
            TextBox4.Text = string.Empty;

            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        bool checkifLandLoadExist()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM landload_tbl WHERE landload_id = '" + TextBox2.Text.Trim() + "'", conn);

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

        void addnewLandLoard()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO landload_tbl(landload_id,landload_name) VALUES(@landload_id,@landload_name)", con);

                cmd.Parameters.AddWithValue("@landload_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@landload_name", TextBox4.Text.Trim());


                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Landload Added Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void updateLandload()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE landload_tbl SET landload_name=@landload_name WHERE landload_id='" + TextBox2.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@landload_name", TextBox4.Text.Trim());


                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Landload Update Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void deleteLandload()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM landload_tbl WHERE landload_id ='" + TextBox2.Text.Trim() + "'", con);

                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Landloard Delete Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void searchByIdLAndload()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM landload_tbl WHERE landload_id = '" + TextBox2.Text.Trim() + "'", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    TextBox4.Text = dataTable.Rows[0][1].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Landload Id');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        bool checkifWardenExist()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM warden_tbl WHERE warden_id = '" + TextBox5.Text.Trim() + "'", conn);

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

        void addnewWarden()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO warden_tbl(warden_id,warden_name) VALUES(@warden_id,@warden_name)", con);

                cmd.Parameters.AddWithValue("@warden_id", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@warden_name", TextBox6.Text.Trim());


                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Warden Added Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void updateWarden()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE warden_tbl SET warden_name=@warden_name WHERE warden_id='" + TextBox5.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@warden_name", TextBox6.Text.Trim());


                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Warden Update Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void deleteWarden()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM warden_tbl WHERE warden_id ='" + TextBox5.Text.Trim() + "'", con);

                //Execute the querry 

                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Warden Delete Successful');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "');", true);

            }
        }

        void searchByIdWarden()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT * FROM warden_tbl WHERE warden_id = '" + TextBox5.Text.Trim() + "'", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    TextBox6.Text = dataTable.Rows[0][1].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Warden Id');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        
    }
}