function initMap() {
    var directionsService = new google.maps.DirectionsService;
    var directionsDisplay = new google.maps.DirectionsRenderer;
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: { lat: 41.85, lng: -87.65 }
    });

    var driverLat = (document.getElementById('MainContent_latd').value)
    var driverLng = (document.getElementById('MainContent_lngd').value)
    var Location = new google.maps.LatLng(driverLat, driverLng);

    var submit = (document.getElementById('submit'));
    directionsDisplay.setMap(map);
   

    document.getElementById('submit').addEventListener('click', function () {
        var marker = new google.maps.Marker({
            position: Location,
            animation: google.maps.Animation.BOUNCE
        });
        marker.setMap(map);
        calculateAndDisplayRoute(directionsService, directionsDisplay);

       
    });
  
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(submit);

    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo('bounds', map);

    var autocompleteDestination = new google.maps.places.Autocomplete(destination);
    autocompleteDestination.bindTo('bounds', map);


}
function calculateAndDisplayRoute(directionsService, directionsDisplay) {

    
    directionsService.route({
        origin: document.getElementById('MainContent_AddressCollection0').value,
        destination: document.getElementById('MainContent_AddressDistina1').value,
       // waypoints: [{ location: document.getElementById('MainContent_AddressCollection1').value, stopover: true }, { location: document.getElementById('MainContent_AddressDistina0').value, stopover: true }],
        waypoints: [{ location: document.getElementById('MainContent_AddressCollection1').value, stopover: true }, { location: document.getElementById('MainContent_AddressDistina0').value, stopover: true }, { location: document.getElementById('MainContent_AddressDistina2').value, stopover: true }, { location: document.getElementById('MainContent_AddressCollection2').value, stopover: true }],
        optimizeWaypoints: true,
        durationInTraffic: true,  
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
            var route = response.routes[0];
            var summaryPanel = document.getElementById('directions-panel');
            summaryPanel.innerHTML = '';
            // For each route, display summary information.
            for (var i = 0; i < route.legs.length; i++) {
                //var routeSegment = i + 1;
                //summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
                //    '</b><br>';
                summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
            }

        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}


