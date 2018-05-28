<?php
require_once '../dbconfig.php';

$query = "  SELECT * 
            FROM STANJE s 
            LEFT JOIN USTANOVA u ON s.ID_USTANOVE = u.ID_USTANOVE 
            WHERE s.ID_USTANOVE=" . $_GET['ustanova'] . " 
            AND DATUM='" . $_GET['datum'] . "';";
            
$result = mysqli_query($con, $query);

$array = array();

while($row = mysqli_fetch_assoc($result)) {
    array_push($array, $row);
 }

 echo json_encode($array);

?>