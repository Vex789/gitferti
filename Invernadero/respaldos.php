<!doctype html>
<?php include 'init.php';?>
<html>
<?php include 'head.php';?>
<body>
    <?php include 'header.php'; ?>
      <div class="container col-md-12">
        <div class=""></div>
        <div class="col-md-3" style="background-color: #E6E6FA; border-radius: 5px; ">        	
        	<form action="guardar.php" class="col-md-8" style="" method="post" id="formulario">
            <label for="">Tipo Suelo</label><br>
          	<select id="suelo" name="suelo" style="border-radius: 5px; ">
          		<option value="Tipo1">Tipo 1</option>
          		<option value="Tipo2">Tipo 2</option>
          		<option value="Tipo3">Tipo 3</option>
          	</select>
          	<label for="">Procentaje humedad</label><br>
            <input type="text" name="humedad" id="humedad" ><br>      
          	<label for="">Tiempo de Riego</label><br>
           	<input type="text" name="tiempo" id="tiempo"><br>
            <label for="">Inicio Riego</label><br>
            <input type="time" name="hora" id="inicio_R" name="inicio_R"><br>
            <label for="">Final Riego</label><br>
            <input type="time" name="hora" id="fin_R" name="fin_R"><br>
            <label for="">Encendido Emergencia</label><br>
            <input type="text" name="emergencia" id="emergencia"><br>
            <label for=""> Gasto Micronutrientes(%)</label><br>
            <input type="text" name="micronutrientes" id="micronutrientes"><br>
            <label for=""> Gasto Macronutrientes(%)</label><br>
            <input type="text" name="macronutrientes" id="macronutrientes"><br>
            <label for=""> Gasto Agua(%)</label><br>
            <input type="text" name="agua" id="agua"><br><br>
            <button type="submit">Actualizar</button><br><br>
            </form>      
            </div>
	        <div class="row" >
	        <div class="col-md-1"></div>
	        <div class="col-md-7" style="background-color: #E6E6FA;"><br><br> 
	        <p>Respaldos</p>
	               <?php 
	                    $dir = (isset($_GET['dir']))?$_GET['dir']:"C:/Respaldos"; 
	                    $directorio=opendir($dir); 
	                    while ($archivo = readdir($directorio)) { 
	                     if(is_dir("$dir/$archivo") )  
	                    echo "<br>"; 
	                    else echo "<a  class='col-md-12' href=\"$dir/$archivo\" download>$archivo</a><br>"; 
	                    //secho "<embed src=\"$dir/$archivo\" type=''>";
	                    echo "<br>";
	                    } 
	                    closedir($directorio); 
	                           
	                    ?>
	        </div>
	        </div>
	        </div>
</body>
</html>

 <link rel="stylesheet" href="bootstrap-3.3.4-dist/js">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
