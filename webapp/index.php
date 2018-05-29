<?php
require_once 'dbconfig.php';
require_once 'timezoneconfig.php';
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
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles -->
    <link href="styles/default.css" rel="stylesheet">

    <script src="scripts/search-suggestions.js"></script>

  </head>

  <body>

    <!-- Navigation -->
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
          <!--
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
          -->
        </div>
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

    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script src="scripts/gmaps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAlIllIUxkJ8epjpWWYZj60o2H_E_HNqVQ&callback=myMap"async defer></script>
    <!-- <script src="https://maps.googleapis.com/maps/api/js?callback=myMap"></script> -->
  </body>

</html>
