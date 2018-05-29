<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Location.aspx.vb" Inherits="Intelli_Fleet_Web.Location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <html>
  <head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Simple markers</title>
    <style>
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      #map {
        height: 80%;
      }
      iframe {
  top: 0;
  left: 0;
}
    </style>
  </head>
  <body>
    <div id="map"></div>
	<div><input id="lat" type="text" runat="server"/></div>
    
    <script>
        var map;
        var myVar;
        var str;

        function dataCheck() {
            function checkData() {
                var mLat = document.getElementById("lat");
                var coordinates = mLat.value;
                if (coordinates != null) {
                    startMap();
                    clearTimeout(myVar);
                }
            };
            myVar = setInterval(checkData, 3000);
        }

        function myStopFunction() {
            clearTimeout(myVar);
        }

        function startMap() {
            var mLat = document.getElementById("lat");
            // var mLong = document.getElementById("lng");
            // addMarker(-26.023878, 28.258395);
            // addMarker(Number(mLat.value), Number(mLong.value), 'Location');
            str = mLat.value;
            var res = str.split(" ");
            var text = "";
            for (i = 0; i < res.length; i += 3) {
                addMarker(Number(res[i + 1]), Number(res[i + 2]), res[i]);
            }
        }

        function addMarker(dLat, dLong, nameTitle) {
            var myLatLng = { lat: dLat, lng: dLong }
            
            var contentString = '<div id="content">' +
            '<div id="siteNotice">' +
            '</div>' +
            //'<h1 id="firstHeading" class="firstHeading">Tutor</h1>' +
            '<div id="bodyContent">' +
            '<p><b>Tutor</b>'  +
            '<iframe src="GetTutorProfile.aspx?tutorID='+nameTitle +'">' +
            'View profile</a>' +
            '(last visited June 22, 2009).</p>' +
            '</div>' +
            '</div>';
            //var contentString = '<iframe src="GetTutorProfile.aspx?tutorID" + id">View Profile</a>'

            var infowindow = new google.maps.InfoWindow({
                content: contentString
            });

            var mTitle = "Tutor: " + nameTitle;
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: mTitle
            });
            
            marker.addListener('click', function () {
                infowindow.open(map, marker);
            });
        }
        // -26.189374 28.018336 -26.188609 28.019189 -26.187309 28.017038
        function initMap() {
            var myLatLng = { lat: -26.023878, lng: 28.262064 };

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 4,
                center: myLatLng
            });
            
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: 'Driver 1'
            });

            dataCheck();
        }
    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDJccYm4AuCWmDo7dtw1pU1dZN7kt5dMXk&callback=initMap">
    </script>
  </body>
</html>







</asp:Content>
