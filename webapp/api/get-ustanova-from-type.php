<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$query = "SELECT * FROM USTANOVA WHERE TIP=" . $_GET['tip'] . ";";
$result = mysqli_query($con, $query);

$array = array();

while($row = mysqli_fetch_assoc($result)) {
    array_push($array, $row);
 }

 echo json_encode($array);

?>