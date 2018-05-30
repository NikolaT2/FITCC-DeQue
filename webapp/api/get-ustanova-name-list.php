<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$query = "SELECT * FROM USTANOVA WHERE NAZIV LIKE '%" . $_GET['naziv'] . "%';";
$result = mysqli_query($con, $query);

while($row = mysqli_fetch_assoc($result)) {
    echo "<div class=\"top-ustanova\">\n";
    echo "  <div class=\"top-ustanova-content ustanova-item\">\n";
    echo "<a>" . $row['NAZIV'] . "</a>";
    echo "<p>Radno vrijeme: " . substr($row['RV_OD'], 0, 2) . ":" . substr($row['RV_DO'], 0, 2) . "</p>";
    echo "<p>Adresa: " . $row['ADRESA'] . "</p>";
    echo "  </div>\n";
    echo "</div>\n";
}

?>