<?php
require_once 'dbconfig.php';
require_once 'timezoneconfig.php';

$query = "SELECT DISTINCT(NAZIV) FROM USTANOVA;";
$result = mysqli_query($con, $query);

$array = array();

while($row = mysqli_fetch_assoc($result)) {
    array_push($array, $row);
}

?>

<!DOCTYPE html>
<html lang="en">

  <head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>DeQue</title>

    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" rel="stylesheet" />

    <!-- Custom styles -->
    <link href="styles/default6.css" rel="stylesheet"> 

    <script src="scripts/search-suggestions.js"></script>

  </head>

  <body>

    <!-- Navigation old
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <div class="container">
        <a class="navbar-brand" href="#">DeQue</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
          <form class="navbar-form navbar-search-form active" role="search">
           <div class="form-group">
            <div class="input-group">
              <input type="text" class="form-control search-input" id="searchBox" onkeyup="showResult(this.value)" placeholder="Search for...">
              <span class="input-group-btn">
                <button class="btn btn-default search-img" type="button" onclick="reloadMap()"><i class="fa fa-search"><img class="img-search" src="icons/search-icon.png"></img></i></button>
              </span>
            </div>
            <div id="livesearch"></div>
           </div>
          </form>
          
          <ul class="navbar-nav ml-auto">
            <li class="nav-item active">
              <a class="nav-link" href="#">Home
                <span class="sr-only">(current)</span>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">About</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Services</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Contact</a>
            </li>
          </ul>

        </div>
      </div>
    </nav>
    -->

    <!-- Navigation new -->
    <nav class="navbar fixed-top navbar-expand-md navbar-light bg-white">
        <a href="index.php" class="navbar-brand">DeQue</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar5">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse" id="navbar5">
            <form class="mx-2 my-auto d-inline w-100" autocomplete="off">
                <div class="input-group">
                  <input type="text" class="form-control border border-right-0 search-input" id="searchBox" onkeyup="showResult(this.value)" placeholder="Search for...">
                  <span class="input-group-append">
                    <button class="btn btn-outline-secondary border border-left-0 search-img" type="button" onclick="reloadMap()"><i class="fa fa-search"></i></button>
                  </span>
                </div>
                <div id="livesearch"></div>
            </form>
            <ul class="navbar-nav">
                <li class="nav-item active">
                    <a class="nav-link" href="#">Inquire<span class="sr-only">Home</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">About</a>
                </li>
            </ul>
        </div>
    </nav>

    <!-- Page Content -->
    <div id="map" style="width:100%; height:100%;">My map will go here</div>
    <div class="container">
      <div class="row">
        <div class="col-lg-12 text-center map-container">
          
        </div>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-lg-12 text-center">
          <ul class="list-unstyled">
            <li>Team ETFIS - FIT Innovation Challenge 2018</li>
          </ul>
        </div>
      </div>
    </div>

    <div class="left-info-pane">
      <div class="top-ustanove" id="top-ustanove">
        <?php
        for($i = 1; $i <= 5; $i++)
        {
            $naziv = $array[$i]['NAZIV'];
            echo "<div class=\"top-ustanova\" onclick=reloadList(this.childNodes[1].childNodes[1].innerHTML);fillSearchBox(this.childNodes[1].childNodes[1].innerHTML);reloadMap();>\n";
            echo "  <div class=\"top-ustanova-content\">\n";
            echo "    <span id=\"span-naziv\">" . $naziv . "</span>\n";
            echo "  </div>\n";
            echo "</div>\n";
        }
        ?>
      </div>
      <div class="ustanove-same-name" id="ustanove-same-name">
      </div>
    </div>

    <!-- Bootstrap core JavaScript -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/popper.js/1.13.0/umd/popper.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <script src="scripts/gmaps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAlIllIUxkJ8epjpWWYZj60o2H_E_HNqVQ&callback=myMap" async defer></script>
    <!-- <script src="https://maps.googleapis.com/maps/api/js?callback=myMap"></script> -->

    <script src="scripts/top-ustanova.js"></script>
  </body>

</html>
