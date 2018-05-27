function myMap() {
    var myStyles =[
        {
            featureType: "poi",
            elementType: "labels",
            stylers: [
                  { visibility: "off" }
            ]
        }
    ];

    var mapOptions = {
        center: new google.maps.LatLng(43.3555541,17.8074431),
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        styles: myStyles 
    }

    var marker = new google.maps.Marker({
        position: {lat: 43.3555541, lng: 17.8074432},
        map: map,
        title: "Test marker"
    });

    var contentString = '<p>Bank 1</p><p>People in queue: 7<p><p>Estimated waiting time: 17min</p>';

    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });

    marker.addListener('click', function() {
        infowindow.open(map, marker);
      });    
    
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
    marker.setMap(map);
} 