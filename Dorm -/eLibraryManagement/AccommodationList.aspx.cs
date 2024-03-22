using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class TestPublish : System.Web.UI.Page
    {

        string latitude;
        string longitude;

        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)

        {
            



            if (!IsPostBack)
            {
                GetLocationsFromDatabase();

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

                }
            
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
                "SELECT * FROM accomodation_publish WHERE latitude = @latitude AND longitude = @longitude", conn);

                

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

