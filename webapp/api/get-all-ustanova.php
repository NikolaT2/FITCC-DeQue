<?php
require_once '../dbconfig.php';

$query = "SELECT * FROM USTANOVA;";
$result = mysqli_query($con, $query);

$array = array();

while($row = mysqli_fetch_assoc($result)) {
    array_push($array, $row);
 }

 echo json_encode($array);

?>