function initMap() {
    var directionsService = new google.maps.DirectionsService;
    var directionsDisplay = new google.maps.DirectionsRenderer;
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: { lat: 41.85, lng: -87.65 }
    });

    var submit = (document.getElementById('submit'));
    var input = (document.getElementById('pac-input'));
    var destination = (document.getElementById('destination'));
    directionsDisplay.setMap(map);
   


    document.getElementById('submit').addEventListener('click', function () {

        var inputCollection = (document.getElementById('pac-input').value);
        document.getElementById('MainContent_CollectionAddress').value = inputCollection;

        var inputDistination = (document.getElementById('destination').value);
        document.getElementById('MainContent_DestinationAddress').value = inputDistination;

        calculateAndDisplayRoute(directionsService, directionsDisplay);
    });
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(destination);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(submit);

    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo('bounds', map);

    var autocompleteDestination = new google.maps.places.Autocomplete(destination);
    autocompleteDestination.bindTo('bounds', map);


}

function calculateAndDisplayRoute(directionsService, directionsDisplay) {
    directionsService.route({
        origin: document.getElementById('pac-input').value,
        destination: document.getElementById('destination').value,
        optimizeWaypoints: true,
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
                document.getElementById('MainContent_RouteDistance').value += route.legs[i].distance.text;
                
            }
          
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}
function DriverTrackcalculateAndDisplayRoute(directionsService, directionsDisplay) {
    var waypts = [];
    var checkboxArray = document.getElementById('MainContent_AddressDistina0');
    var checkboxArray = document.getElementById('MainContent_AddressCollection1');
    for (var i = 0; i < checkboxArray.length; i++) {
     
            waypts.push({
               location: checkboxArray[i].value,
              //  location:checkboxArray.value,
                stopover: true
            });
        
    }

    directionsService.route({
        origin: document.getElementById('MainContent_AddressCollection0').value,
        destination: document.getElementById('MainContent_AddressDistina1 ').value,
        waypoints: waypts,
        optimizeWaypoints: true,
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
            var route = response.routes[0];
            var summaryPanel = document.getElementById('directions-panel');
            summaryPanel.innerHTML = '';
            // For each route, display summary information.
            for (var i = 0; i < route.legs.length; i++) {
                var routeSegment = i + 1;
                summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
                    '</b><br>';
                summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
            }
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}
function trackDriverUsingAddress() {
    var DriverAddress = document.getElementById('address').value;
    geocoder.geocode({ 'address': DriverAddress }, function (results, status) {
        if (status == 'OK') {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}


