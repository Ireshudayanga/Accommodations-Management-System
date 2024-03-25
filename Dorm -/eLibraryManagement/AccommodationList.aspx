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

   <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
   <style>

     .customcard{

         padding-bottom: 10%;
          padding-top: 10%;
     }
     .custom-textbox {
     width: 400px;
     height: 51px;
     padding: 10px;
     border: 1px solid #ced4da;
     border-radius: 5px;
     box-sizing: border-box; /* This ensures that padding and border are included in the width and height */
     font-size: 16px;
     }
      .button {
          background-color: #04AA6D;
         color: white;
         padding: 7px ;
         margin-top: 15px;
         border: none;
         cursor: pointer;
         width: 15%;
         border-radius: 10px;
  
      }

      .hide{

          display:none;
      }

     .message-box {
         border: none;
         border-radius: 5px;
         margin-bottom: 10px;
         padding: 10px;
     }

     .sender {
         font-weight: bold;
     }

     .message-input {
         margin-bottom: 10px;
     }

     /* Styling for LinkButton */
     .link-button {
         display: inline-block;
         padding: 6px 12px;
         margin-bottom: 0;
         font-size: 14px;
         font-weight: normal;
         line-height: 1.42857143;
         text-align: center;
         white-space: nowrap;
         vertical-align: middle;
         cursor: pointer;
         background-image: none;
         border: 1px solid transparent;
         border-radius: 4px;
         transition: all 0.3s ease;
         color: #fff;
         background-color: #007bff;
         border-color: #007bff;
     }

     .link-button:hover {
         color: #fff;
         background-color: #0056b3;
         border-color: #0056b3;
     }

     .customrow{

         padding:40px;
     }

     /* Style for message boxes */
.message {
    margin-bottom: 10px;
    overflow: hidden;
}

/* Style for sender's message aligned to the right */
.message.right {
    text-align: right;
}

/* Style for receiver's message aligned to the left */
.message.left {
    text-align: left;
}

/* Style for sender's name */
.sender {
    font-weight: bold;
    margin-right: 5px; /* Adjust as needed */
}

/* Style for message text */
.message-text {
    display: inline-block;
    background-color: #f3f3f3;
    padding: 5px 10px;
    border-radius: 10px;
    max-width: 70%; /* Adjust as needed */
    word-wrap: break-word; /* Ensure long messages wrap */
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
              
         

                 <div class="row ">

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

<div class="container customcard">
 <div class="card">
   <div class="card-body">

     <div class="row customrow">
         <div class="col-md-12">


     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="100"></asp:Timer>
             
             <div class="message-box">
            <asp:DataList ID="DataList2" runat="server">
                <ItemTemplate>
                    <div class='<%# Eval("Sender").ToString() == "username" ? "message right" : "message left" %>'>
                        <div>
                            <span class="sender"><%# Eval("Sender") %>:</span>
                         <span class="message-text"><%# Eval("Message") %></span>
                     </div>
                    </div>
             </ItemTemplate>
            </asp:DataList>
            </div>
           
         </ContentTemplate>
     </asp:UpdatePanel>
    
             

     <asp:DataList ID="DataList1" runat="server" RepeatDirection="Vertical" Height="1px" Width="189px">
     </asp:DataList>

     <center>
     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
     <asp:TextBox CssClass="custom-textbox" ID="TextBox1" runat="server" Width="400px" Height="51px"></asp:TextBox>
     <asp:Button class="button" ID="Button1" runat="server" Text="Replay" OnClick="Button1_Click" />
     </center>
     
      </div> 
   </div>  
  </div> 
 </div>  
 </div>

</asp:Content>
