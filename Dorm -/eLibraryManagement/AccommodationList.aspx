<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccommodationList.aspx.cs" Inherits="eLibraryManagement.TestPublish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>
     #map {
         height: 400px;
         width: 100%;
     }

     /* Custom CSS */
.my-custom-margin {
    margin: 13px;
}

 </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class ="container">

    <div id="map">

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCiA9QVi_0Y2xLW-_dPGzdn-mUUFGKj-yU&callback=initMap" async defer></script>

    
    <script>
        var map;
        var locations = [];

        function initMap() {
            console.log("initMap() function called.");
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: 6.8205951902026225, lng: 80.03945885946213 },
                zoom: 14
            });

            GetLocationsFromDatabase();

           
        }

        function addMarker(location) {

            // alert("Adding marker at location: " + JSON.stringify(location)); to check location data parsing correctly
            var marker = new google.maps.Marker({
                position: location,
                map: map
            });

            marker.addListener('click', function () {

                // Set the values of hidden fields with the latitude and longitude
                document.getElementById('<%= ClickedMarkerLatitude.ClientID %>').value = location.lat;
                document.getElementById('<%= ClickedMarkerLongitude.ClientID %>').value = location.lng;

                // Trigger a postback to send the values to the server
                __doPostBack('<%= ClickedMarkerLatitude.UniqueID %>', '');
               
            });
        }

        function setLocations(jsonLocations) {
            locations = JSON.parse(jsonLocations);
            // Call GetLocationsFromDatabase to add markers for the retrieved locations
            GetLocationsFromDatabase();
        }

        function GetLocationsFromDatabase() {


            for (var i = 0; i < locations.length; i++) {
                addMarker(locations[i]);
            }
        }

    </script>
   </div>

    <br/>
    <br />
   
    <div class="row">
    <div class="col-md-12 mx-auto">
        <div class="card">
            <div class="card-body my-custom-margin">
                
                <div class="row ">
                    <div class="col">
                        <center>
                            <h3>Accommodation Details</h3>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr />
                     </div>
                </div>
                </div>

            <div class="row  mx-auto">
                <div class="col-md-12">
                    <div class="form-group">
                       
                        <asp:Image ID="imgUploaded" Width="500px" runat="server" />
    
                 </div>
             </div>
            </div>
              
            <br />

                 <div class="row  my-custom-margin">

                      <div class="col-md-5  mx-auto">
                         <label>Landloard Id</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                             runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                 
                       <div class="col-md-5  mx-auto">
                         <label>Contact No:</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="TextBox2"
                            runat="server" placeholder=""  ReadOnly="True" TextMode="Phone"></asp:TextBox>
                    </div>
                  </div>
               </div>


                <div class="row my-custom-margin">
                   
                    <div class="col-md-5  mx-auto">
                        <label>Email</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="TextBox4"
                            runat="server" placeholder=""  ReadOnly="True" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-5  mx-auto">
                          <label>City</label>
                          <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6"
                              runat="server" placeholder=""  ReadOnly="True" ></asp:TextBox>
                       </div>
                      </div>
                </div>


                <div class="row my-custom-margin">
                    <div class="col-md-11  mx-auto">
                        <label>Full Address:</label>
                        <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="TextBox8"
                            runat="server" placeholder=""  ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
               </div>


            <asp:HiddenField ID="ClickedMarkerLatitude" runat="server" />
            <asp:HiddenField ID="ClickedMarkerLongitude" runat="server" />

            <br />
            <br /> 
            
            </div>

         <div class="homelink my-custom-margin">
          <a href="home.aspx" class="nounderline"><< Back to Home</a>
         </div>
        </div>
       
    

  </div>
</div>

</asp:Content>
