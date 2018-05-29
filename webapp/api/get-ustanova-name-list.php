<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$query = "SELECT * FROM USTANOVA WHERE NAZIV LIKE '%" . $_GET['naziv'] . "%';";
$result = mysqli_query($con, $query);

while($row = mysqli_fetch_assoc($result)) {
    echo "<div class=\"top-ustanova\">\n";
    echo "  <div class=\"top-ustanova-content\">\n";
    echo $row['NAZIV'];
    echo "  </div>\n";
    echo "</div>\n";
}

?>