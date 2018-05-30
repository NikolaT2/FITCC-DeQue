<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$query = "  SELECT * 
            FROM STANJE s 
            LEFT JOIN USTANOVA u ON s.ID_USTANOVE = u.ID_USTANOVE 
            WHERE s.ID_USTANOVE=" . $_GET['id_ustanove'] . " 
            AND DATUM='" . date('Y-m-d') . "';";
            
$result = mysqli_query($con, $query);

$array = array();

while($row = mysqli_fetch_assoc($result)) {
    array_push($array, $row);
}

echo json_encode($array);


?>