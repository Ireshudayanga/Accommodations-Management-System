using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagement
{
    public partial class AdverticementPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLocationsFromDatabase();
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

    }
}