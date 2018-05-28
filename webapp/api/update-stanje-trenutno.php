<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$query =    "SELECT * FROM STANJE 
            WHERE ID_USTANOVE=" . $_GET['id_ustanove'] .
            " AND DATUM='" . date('Y-m-d') . "';";

$result = mysqli_query($con, $query);
$array = array();

while($row = mysqli_fetch_assoc($result)) {
    array_push($array, $row);
}

if (empty($array) == TRUE) 
{
    $query =    "INSERT INTO STANJE(ID_USTANOVE, TRENUTNO_STANJE, POSLEDNJI_UZETI, DATUM)
                VALUES(" . $_GET['id_ustanove'] . ", 0, 0, '" . date('Y-m-d') . "');";

    $con->query($query);
}

$query =    "UPDATE STANJE 
            SET TRENUTNO_STANJE=" . $_GET['trenutno_stanje'] . 
            " WHERE ID_USTANOVE=" . $_GET['id_ustanove'] . 
            " AND DATUM='" . date('Y-m-d') . "';";

if ($con->query($query) == TRUE)
{
    echo "Record updated successfuly";
}
else
{
    echo "Error updating record: " . $con->error;
}

?>