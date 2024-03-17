<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="eLibraryManagement.map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Adjust map container size */
        #map {
            height: 100vh;
            width: 100%;
        }
    </style>

   <script>

       var map;
       var marker;

       function myMap() {
           var mapProp = {
               center: new google.maps.LatLng(51.508742, -0.120850),
               zoom: 5,
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
       }
   </script>
  
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="googleMap" style="width:100%;height:400px;"></div>



   <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCiA9QVi_0Y2xLW-_dPGzdn-mUUFGKj-yU&callback=myMap"></script>


</asp:Content>
