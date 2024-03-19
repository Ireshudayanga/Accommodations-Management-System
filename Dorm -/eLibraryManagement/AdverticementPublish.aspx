<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdverticementPublish.aspx.cs" Inherits="eLibraryManagement.AdverticementPublish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #map {
            height: 400px;
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="map">

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCiA9QVi_0Y2xLW-_dPGzdn-mUUFGKj-yU&callback=initMap" async defer></script>

    <script>

    


       
    </script>

    <script>
        var map;
        var location = [];

        function initMap() {
            console.log("initMap() function called.");
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: 6.8205951902026225, lng: 80.03945885946213 },
                zoom: 15
            });

            GetLocationsFromDatabase();
        }

        function addMarker(location) {

            alert("Adding marker at location: " + JSON.stringify(location));
            var marker = new google.maps.Marker({
                position: location,
                map: map
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
    
</asp:Content>
