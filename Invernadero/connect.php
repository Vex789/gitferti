<?php
	$connect_error='error con la base de datos';
	mysql_connect('localhost','root','') or die($connect_error);
	mysql_select_db('invenadero') or die($connect_error);
?>