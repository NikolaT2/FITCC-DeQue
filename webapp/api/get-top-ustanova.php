<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$query = "SELECT DISTINCT(NAZIV) FROM USTANOVA WHERE TIP=" . $_GET['tip'] . ";";
$result = mysqli_query($con, $query);

// Prva ustanova, samo za testiranje
$row = mysqli_fetch_assoc($result);

$i = 0;
while($row = mysqli_fetch_assoc($result)) {
    $naziv = $row['NAZIV'];

    echo "<div class=\"top-ustanova\" onclick=loadUstanovaName(this.childNodes[1].childNodes[1].innerHTML);fillSearchBox(this.childNodes[1].childNodes[1].innerHTML);reloadMap();>\n";
    echo "  <div class=\"top-ustanova-content\">\n";
    echo "    <span id=\"span-naziv\">" . $naziv . "</span>\n";
    echo "  </div>\n";
    echo "</div>\n";
    
    $i++;

    if ($i == 5)
        break;
}

?>