<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="landloadPublisher.aspx.cs" Inherits="eLibraryManagement.landloadPublisher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

    var map;
    var marker;

    function myMap() {
        var mapProp = {
            center: new google.maps.LatLng(6.8205951902026225, 80.03945885946213), 
            zoom: 14,
        };

        map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        google.maps.event.addListener(map, 'click', function (event) {
            placeMarker(event.latLng);
        });

    }

    function placeMarker(location) {

        if (marker) {

            marker.setMap(null);
        }

        marker = new google.maps.Marker({
            position: location,
            map: map
        });

        var latitude = location.lat();
        var longitude = location.lng();

        document.getElementById('<%= Latitude.ClientID %>').value = latitude;
        document.getElementById('<%= Longitude.ClientID %>').value = longitude;
    }
    </script>

   
    
    <style>

.label{

    font-size:17px;
    padding:8px;
}
 /* Adjust map container size */
#map {
    height: 100vh;
    width: 100%;
}

/* Custom CSS */
.my-custom-margin {
    margin: 13px;
}



.margin{
    margin:5px;
}

 .button {
     background-color: #04AA6D;
     color: white;
     padding: 7px ;
     margin-top: 15px;
     border: none;
     cursor: pointer;
     width: 75%;
     border-radius: 10px;
     
 }

 .button:hover{
     background-color:#2f692f;
 }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container">
  <div class="row">
      <div class="col-md-8 mx-auto">
          <div class="card">
              <div class="card-body">
                  <div class="row">
                      <div class="col">
                          <center>
                              <img src="images/user%20Icon.png" width="80px"/>
                          </center>
                      </div>
                  </div>
                  <br />
                  <div class="row">
                      <div class="col">
                          <center>
                              <h3>Accommodation Publisher</h3>
                          </center>
                      </div>
                  </div>
                  <div class="row">
                      <div class="col">
                          <hr />
                       </div>
                  </div>
                  </div>

                   <div class="row my-custom-margin">
                    <div class="col-md-6">
                         <label>Images</label>
                        <div class="form-group">
                             <asp:FileUpload  CssClass="form-control" ID="FileUpload1" runat="server" />
                     </div>
                    </div>
                         <div class="col-md-6">
                            <label>Landloard Id</label>
                            <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1"
                                runat="server" placeholder="" ></asp:TextBox>
                            </div>
                        </div>
                 </div>


                  <div class="row my-custom-margin">
                      <div class="col-md-4">
                          <label>Contact No:</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox2"
                              runat="server" placeholder="" TextMode="Phone"></asp:TextBox>
                       </div>
                      </div>
                      <div class="col-md-4">
                          <label>Email</label>
                          <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4"
                              runat="server" placeholder="" TextMode="Email"></asp:TextBox>
                          </div>
                      </div>
                      <div class="col-md-4">
                            <label>City</label>
                            <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox6"
                                runat="server" placeholder="" ></asp:TextBox>
                         </div>
                        </div>
                  </div>


                  <div class="row my-custom-margin">
                      <div class="col-md-12">
                          <label>Full Address:</label>
                          <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8"
                              runat="server" placeholder="" TextMode="MultiLine"></asp:TextBox>
                          </div>
                      </div>
                 </div>

                

              
               <div class="row my-custom-margin">
                   <center>
                    <div class="col-md-12  ">
                         <label class="label">Choose Location from map</label>
                         <div id="googleMap" style="width:100%;height:300px;"></div>
                         <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCiA9QVi_0Y2xLW-_dPGzdn-mUUFGKj-yU&callback=myMap"></script> 
                    </div>
                    </center>
                  </div>

              <asp:HiddenField ID="Latitude" runat="server" />
               <asp:HiddenField ID="Longitude" runat="server" />

                  <div class="form-group  my-custom-margin">
                      <center>
                      <asp:Button class="button" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  />
                      </center>
                  </div>

                  <br />


              </div>
          </div>
          <div class="homelink my-custom-margin">
          <a href="home.aspx" class="nounderline"><< Back to Home</a>
         </div>
      
  </div>

  </div>

</asp:Content>
