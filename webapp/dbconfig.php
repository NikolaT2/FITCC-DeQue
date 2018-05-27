<?php
$con = mysqli_connect("localhost","paviljon_kmet","kmetkmet","paviljon_kmetovi");

// Check connection
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }
?>