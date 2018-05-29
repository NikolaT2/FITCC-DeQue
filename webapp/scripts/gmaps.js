function myMap(str) {
    // Remove points of interest
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

    var lastinfowindow;
    var ajax_get_ustanova;

    if (str == null)
        ajax_get_ustanova = 'http://paviljondedinje.com/kmet/api/get-all-ustanova.php';
    else
        ajax_get_ustanova = 'http://paviljondedinje.com/kmet/api/get-ustanova-from-name.php?naziv=' + str;

    $.get(ajax_get_ustanova, function(data) {
        var markers = JSON.parse(data);
        var map = new google.maps.Map(document.getElementById("map"), mapOptions);
        var currentDate = new Date().toISOString().slice(0, 10).replace('T', ' ');
        var infowindow = new google.maps.InfoWindow({
            content: ''
        });

        markers.forEach(element => {
            $.get('http://paviljondedinje.com/kmet/api/get-ustanova-stanje.php?id_ustanove=' + element['ID_USTANOVE'], function(data_stanje) {
                var stanje = JSON.parse(data_stanje);
            
                var marker = new google.maps.Marker({
                    position: {lat: parseFloat(element['LAT']), lng: parseFloat(element['LON'])},
                    map: map,
                    label: {text: element['NAZIV']},
                    title: "Test marker"
                });
                
                var poslednji_minus_trenutni = 0;
                if (stanje[0] != null)
                    poslednji_minus_trenutni = (parseInt(stanje[0]['POSLEDNJI_UZETI']) - parseInt(stanje[0]['TRENUTNO_STANJE']));
                
                var contentString = '<p>' + element['NAZIV'] + '</p>' + 
                                    '<p>People in queue: ' + poslednji_minus_trenutni + '</p>' + 
                                    '<p>Estimated waiting time: ' + poslednji_minus_trenutni*5 + 'min </p>';
            
                google.maps.event.addListener(marker, 'click', function() {
                    infowindow.close();
                    infowindow.setContent(contentString);
                    infowindow.open(map, marker);
                });    
                
                marker.setMap(map);
            });
        });

        map.addListener('click', function() {
            infowindow.close();
          });

    });
} 