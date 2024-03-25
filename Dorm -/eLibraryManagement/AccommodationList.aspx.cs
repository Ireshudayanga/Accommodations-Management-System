using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class TestPublish : System.Web.UI.Page
    {

        string landloadname;
        string latitude;
        string longitude;

        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)

        {
            



            if (!IsPostBack)
            {
                GetLocationsFromDatabase();

                if (IsLandlord())
                {
                   
                    LoadChatboxForLandlord();
                }

            }

           
          
                // Check if the postback is triggered by clicking on the marker
                if (Request.Form[ClickedMarkerLatitude.UniqueID] != null && Request.Form[ClickedMarkerLongitude.UniqueID] != null)
                {
                     GetLocationsFromDatabase();

                      
                    latitude = ClickedMarkerLatitude.Value;
                    longitude = ClickedMarkerLongitude.Value;


                     showLandLoadData();

                    string imageLink = RetrieveImageLinkFromDatabase();

                        if (!string.IsNullOrEmpty(imageLink))
                        {
                             imgUploaded.ImageUrl = imageLink;
                        }

                    LoadChatbox();

                 }
            
        }


        private bool IsLandlord()
        {
            
            return Session["role"].ToString() == "landloard";
        }

        protected void LoadChatboxForLandlord()
        {
            string landlordName = Session["username"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            string str = "SELECT * FROM chat WHERE Receiver = @LandlordName";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@LandlordName", landlordName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList2.DataSource = ds;
            DataList2.DataBind();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();

            string time = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            string name = username;
            string query = "insert into Chat (Sender, Receiver, Message, Date) values ('" + name + "','" + landloadname + "','" + TextBox1.Text + "','" + time + "')";

            int i = ExecuteQuery(query);
            if (i == 1)
            {
                TextBox1.Text = "";
            }

            LoadChatbox();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LoadChatbox();
            if (IsLandlord())
            {
                LoadChatboxForLandlord();
                LoadChatbox();
            }
        }

        protected void LoadChatbox()
        {
            string username = Session["username"].ToString();

            string name = username;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            string str = "select * from chat where Receiver = '" + name + "' AND Sender = '" + landloadname + "' OR ( Sender = '" + name + "' AND Receiver = '" + landloadname + "') ";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList2.DataSource = ds;
            DataList2.DataBind();

           

        }

        protected int ExecuteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd.ExecuteNonQuery();

        }

        protected void GetLocationsFromDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT latitude, longitude FROM accomodation_publish", con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<object> locations = new List<object>();

                            while (reader.Read())
                            {
                                double latitude;
                                double longitude;

                                if (double.TryParse(reader["latitude"].ToString(), out latitude) &&
                                    double.TryParse(reader["longitude"].ToString(), out longitude))
                                {
                                    locations.Add(new { lat = latitude, lng = longitude });
                                }

                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error occur while fetching location');", true);
                                }
                            }

                            // Serialize the list to JSON
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            string jsonLocations = serializer.Serialize(locations);


                            // Register a script block to call the JavaScript function with locations
                            ScriptManager.RegisterStartupScript(this, GetType(), "addMarkers",
                               $"setLocations('{jsonLocations}');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error');", true);
                    }
                }
            }
        }

        public void showLandLoadData() 
        {
            try
            {
               

                SqlConnection conn = new SqlConnection(connectionString);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                "SELECT ap.*, lt.landload_name FROM accomodation_publish AS ap JOIN landload_tbl AS lt ON ap.publisher_id = lt.landload_id WHERE ap.latitude = @latitude AND ap.longitude = @longitude", conn);

                

                cmd.Parameters.AddWithValue("@latitude", latitude);
                cmd.Parameters.AddWithValue("@longitude", longitude);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox3.Text = dr.GetValue(0).ToString();
                        TextBox2.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox6.Text = dr.GetValue(3).ToString();
                        TextBox8.Text = dr.GetValue(4).ToString();
                        landloadname = dr.GetValue(8).ToString();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' Click on Correct Marker loaction ')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }

        private string RetrieveImageLinkFromDatabase()
        {
            string imageLink = ""; 

            try
            {
                
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT img_link FROM accomodation_publish WHERE latitude = @latitude AND longitude = @longitude", con);

                    cmd.Parameters.AddWithValue("@latitude", latitude);
                    cmd.Parameters.AddWithValue("@longitude", longitude);

                    imageLink = cmd.ExecuteScalar()?.ToString(); 
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            return imageLink;
        }

       
    }

}

