var link = 'http://localhost/webapp';

var lastinfowindow;
var lastmarker;
var lastmarkerid;

var map;
var mapOptions;
var myStyles;

var global_naziv;
var global_type;

var markers_array = [];

function initialize()
{
    var myStyles =[
        {
            featureType: "poi",
            elementType: "labels",
            stylers: [
                  { visibility: "off" }
            ]
        }
    ];

    mapOptions = {
        center: new google.maps.LatLng(43.3555541,17.8074431),
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        styles: myStyles,
        gestureHandling: 'greedy'
    }

    map = new google.maps.Map(document.getElementById("map"), mapOptions);
}

function isInfoWindowOpen(infoWindow){
    var map = infoWindow.getMap();
    return (map !== null && typeof map !== "undefined");
}

function getMarkersData()
{
    var ajax_get_ustanova;
    var infowindow = new google.maps.InfoWindow({
        content: ''
    });

    for (var i = 0; i < markers_array.length; i++ ) {
        markers_array[i].setMap(null);
    }
    markers_array.length = 0;

    if (global_naziv == null && global_type == null)
        ajax_get_ustanova = link + '/api/get-all-ustanova.php';
    if (global_naziv != null && global_type == null)
        ajax_get_ustanova = link + '/api/get-ustanova-from-name.php?naziv=' + global_naziv;
    if (global_naziv == "" && global_type != null)
        ajax_get_ustanova = link + '/api/get-ustanova-from-type.php?tip=' + global_type;

    $.get(ajax_get_ustanova, function(data) {
        var markers = JSON.parse(data);
        var currentDate = new Date().toISOString().slice(0, 10).replace('T', ' ');

        markers.forEach(element => {
            $.get(link  + '/api/get-ustanova-stanje.php?id_ustanove=' + element['ID_USTANOVE'], function(data_stanje) {
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
                
                var rv_od = element['RV_OD'] != null ? element['RV_OD'].substring(0,5) : 'N';
                var rv_do = element['RV_DO'] != null ? element['RV_DO'].substring(0,5) : 'N';
                var contentString = '<p>' + element['NAZIV'] + '</p><hr/>' +
                                    '<div class=\'marker-item\'><p>People in queue: ' + poslednji_minus_trenutni + '</p>' + 
                                    '<p>Estimated waiting time: ' + poslednji_minus_trenutni*5 + 'min </p><hr/></div>' + 
                                    'Radno vrijeme: ' + rv_od + ' - ' + rv_do;
            
                google.maps.event.addListener(marker, 'click', function() {
                    infowindow.close();
                    infowindow.setContent(contentString);
                    infowindow.open(map, marker);

                    lastinfowindow = infowindow;
                    lastmarker = marker;
                    lastmarkerid = element['ID_USTANOVE'];
                });    
                
                marker.setMap(map);

                markers_array.push(marker);
            });
        });

        map.addListener('click', function() {
            infowindow.close();
            lastinfowindow = null;
          });

    });

    if (lastinfowindow != null)
    {
        $.get(link  + '/api/get-ustanova-from-id.php?id_ustanove=' + lastmarkerid, function(data_ustanova) {
            var element = JSON.parse(data_ustanova);
            $.get(link  + '/api/get-ustanova-stanje.php?id_ustanove=' + lastmarkerid, function(data_stanje) {
                var stanje = JSON.parse(data_stanje);

                var poslednji_minus_trenutni = 0;
                if (stanje[0] != null)
                    poslednji_minus_trenutni = (parseInt(stanje[0]['POSLEDNJI_UZETI']) - parseInt(stanje[0]['TRENUTNO_STANJE']));
                
                var rv_od = element[0]['RV_OD'] != null ? element[0]['RV_OD'].substring(0,5) : 'N';
                var rv_do = element[0]['RV_DO'] != null ? element[0]['RV_DO'].substring(0,5) : 'N';
                var contentString = '<p>' + element[0]['NAZIV'] + '</p><hr/>' +
                                    '<div class=\'marker-item\'><p>People in queue: ' + poslednji_minus_trenutni + '</p>' + 
                                    '<p>Estimated waiting time: ' + poslednji_minus_trenutni*5 + 'min </p><hr/></div>' + 
                                    'Radno vrijeme: ' + rv_od + ' - ' + rv_do;

                lastinfowindow.setContent(contentString);
            });
        });

        lastinfowindow.open(map, lastmarker);
    }
}

function myMap(naziv, type) {
    // Remove points of interest

    global_naziv = naziv;
    global_type = type;

    initialize();
    getMarkersData();

    window.setInterval(getMarkersData, 5000);
};