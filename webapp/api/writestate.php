<?php
require_once '../dbconfig.php';
require_once '../timezoneconfig.php';

$procInput1 = $_GET['id_ustanove'];
$procInput2 = $_GET['broj'];
$procInput3 = date('Y-m-d h:m:s');

$s = $con->prepare('SET @s0 = ?, @s1 = ?, @s2 = ?') or die('Unable to prepare: ' . $c->error);
$s->bind_param('iii', $procInput1, $procInput2, $procInput3);
$s->execute();

$s = $con->prepare("CALL insertState(@s0, @s1, @s2)") or die('Unable to prepare: ' . $c->error);
$s->execute();

?>