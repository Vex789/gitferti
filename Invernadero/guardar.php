<?php

		$suelo=$_POST['suelo'];
		$humedad=$_POST['humedad'];
		$tiempo=$_POST['tiempo'];
		$inicio_R=$_POST['inicio_R'];
		$fin_R=$_POST['fin_R'];
		$emergencia=$_POST['emergencia'];
		$micro=$_POST['micronutrientes'];
		$macro=$_POST['macronutrientes'];
		$agua=$_POST['agua'];

 		@mysql_connect("localhost","root","") or die("No se pudo conectar al servidor de BD");
		mysql_select_db("invernadero") or die("No se pudo seleccionar la BD");;
		$qry="UPDATE comunicacion set suelo='$suelo',humedad='$humedad', tiempo_riego='$tiempo',inicio_riego='$inicio_R', fin_riego='$fin', emergencia='$emergencia', micronutrientes='$micro', macronutrientes='$macro',agua='$agua' where id='1'";
		//$sql = "INSERT INTO comunicacion(suelo, humedad, tiempo_riego, inicio_riego, fin_riego, emergencia, micronutrientes, macronutrientes, agua)VALUES ('$suelo', '$humedad', '$tiempo', '$inicio_R', '$fin_R', '$emergencia', '$micro', '$macro', '$agua')";
		mysql_query($qry) or die("No se pudo actualizar el registro, error:" . mysql_error());


				header('location: respaldos.php');



?>