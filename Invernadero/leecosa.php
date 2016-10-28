<<<<<<< HEAD

=======
>>>>>>> origin/master
<!doctype html>
<?php include 'init.php';?>
<html>
<?php include 'head.php'; 
$page = $_SERVER['PHP_SELF'];
$sec = "10";
?>
<meta http-equiv="refresh" content="<?php echo $sec?>;URL='<?php echo $page?>'">
<body>
    <?php include 'header.php'; ?>
<<<<<<< HEAD
    <div id="container" style="height:auto;">
        <?php include 'aside.php'; ?>
=======
>>>>>>> origin/master
        <?php
        $registros = array();
        
            $uid=0; 
            if (($myfile = fopen("hola", "r")) !== FALSE) {
               
                while (!feof($myfile)) 
                {
                    $datos[] = fgets($myfile);
                   
                    
                }
                    
                    foreach ($datos as $dt) {
                        $uid++;
                        $temp=explode("#", $dt);
                        ##print_r($temp);
                        $hum1[]=array($uid,$temp[3]);
                        $humrel1[]=array($uid,$temp[6]);
                        $temper[]=array($uid,$temp[9]);
                        $luz[]=array($uid,$temp[12]);
                        $tambo[]=array($uid,$temp[13]);
                        $macro[]=array($uid,$temp[14]);
                        $micro[]=array($uid,$temp[15]);
                       

                    }
                fclose($myfile);
                require_once 'phplot.php';  // here we include the PHPlot code 
                $plot = new PHPlot(300, 200);
                $plot->SetDataValues($hum1);
                //Turn off X axis ticks and labels because they get in the way:
                $plot->SetXTickLabelPos('none');
                $plot->SetXTickPos('none');
                $plot->SetPrintImage(False); // No automatic output
                //Draw it
                $plot->DrawGraph();

                $plotHR = new PHPlot(300, 200);
                $plotHR->SetDataValues($humrel1);
                //Turn off X axis ticks and labels because they get in the way:
                $plotHR->SetXTickLabelPos('none');
                $plotHR->SetXTickPos('none');
                $plotHR->SetPrintImage(False); // No automatic output
                //Draw it
                $plotHR->DrawGraph();

                $plotTp = new PHPlot(300, 200);
                $plotTp->SetDataValues($temper);

                //Turn off X axis ticks and labels because they get in the way:
                $plotTp->SetXTickLabelPos('none');
                $plotTp->SetXTickPos('none');
                $plotTp->SetPrintImage(False); // No automatic output
                //Draw it
                $plotTp->DrawGraph();

                $plotLuz = new PHPlot(300, 200);
                $plotLuz->SetDataValues($luz);

                //Turn off X axis ticks and labels because they get in the way:
                $plotLuz->SetXTickLabelPos('none');
                $plotLuz->SetXTickPos('none');
                $plotLuz->SetPrintImage(False); // No automatic output
                //Draw it
                $plotLuz->DrawGraph();

                $plotTB = new PHPlot(300, 200);
                $plotTB->SetDataValues($tambo);
                $plotTB->SetPlotType('bars');
                //Turn off X axis ticks and labels because they get in the way:
                $plotTB->SetXTickLabelPos('none');
                $plotTB->SetXTickPos('none');
                $plotTB->SetPrintImage(False); // No automatic output
                //Draw it
                $plotTB->DrawGraph();

                $plotMI = new PHPlot(300, 200);
                $plotMI->SetDataValues($macro);
                $plotMI->SetPlotType('bars');
                //Turn off X axis ticks and labels because they get in the way:
                $plotMI->SetXTickLabelPos('none');
                $plotMI->SetXTickPos('none');
                $plotMI->SetPrintImage(False); // No automatic output
                //Draw it
                $plotMI->DrawGraph();

                
            }
            else
            {
                $errors[]="archivo no existe";
                print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
            }
        
        ?>
<<<<<<< HEAD
        <form action="" method="post">
            <ul>
                <div>
                    Graphica de Humedad suelo:<br>
                    <img src="<?php echo $plot->EncodeImage();?>" >
                </div>
                <div>
                    Graphica de Humedad relativa:<br>
                    <img src="<?php echo $plotHR->EncodeImage();?>">
                </div>
                <div>
                    Graphica de Temperatura:<br>
                    <img src="<?php echo $plotTp->EncodeImage();?>">
                </div>
                <div>
                    Graphica de Luz:<br>
                    <img src="<?php echo $plotLuz->EncodeImage();?>">
                </div>
                <div>
                    Graphica de Macronutrientes:<br>
                    <img src="<?php echo $plotMA->EncodeImage();?>" >
                </div>
                <div>
                    Graphica de Micronutrientes:<br>
                    <img src="<?php echo $plotMI->EncodeImage();?>" >
                </div>
                <div>
                    Graphica de Tambo:<br>
                    <img src="<?php echo $plotTB->EncodeImage();?>" >
                </div>
                testst<br>

            </ul>
        </form>
    </div>

</body>
</html>
=======


        <div class="container col-md-12" >
          <div class="col-md-3" style="background-color: #E6E6FA; border-radius: 5px; ">
           <form action="" class="col-md-8" style="" method="post" id="formulario"><br>
            <p>Datos Actuales</p>
             <?php
                $conn = new mysqli("localhost", "root","", "invernadero");
                // Check connection
                if ($conn->connect_error) {
                    die("Connection failed: " . $conn->connect_error);
                } 


                $sql="SELECT *From comunicacion where id='1'";
                $result = $conn->query($sql);
                if ($result->num_rows > 0) {
              // output data of each row
                while($row = $result->fetch_assoc()) {
                    $suelo=$row["suelo"];
                    $humedad=$row["humedad"];
                    $tiempo=$row["tiempo_riego"];
                    $inicio_R=$row["inicio_riego"];
                    $fin_R=$row["fin_riego"];
                    $emergencia=$row["emergencia"];
                    $micro=$row["micronutrientes"];
                    $macro=$row["macronutrientes"];
                    $agua=$row["agua"];

                    echo "
                         <label for=''>Tipo Suelo</label><br>
                        <input type='text' name='suelo' id='suelo' value='$suelo' ><br>      
                        <label for=''>Procentaje humedad</label><br>
                        <input type='text' name='humedad' id='humedad' value='$humedad' ><br>      
                        <label for=''>Tiempo de Riego</label><br>
                        <input type='text' name='tiempo' id='tiempo' value='$tiempo'><br>
                        <label for=''>Inicio Riego</label><br>
                        <input type='text' name='inicio_R' id='inicio_R' value='$inicio_R' ><br>      
                        <label for='>Final Riego</label><br>
                        <input type='text' name='fin_R' id='fin_R' value='$fin_R' ><br>      
                        <label for=''>Encendido Emergencia</label><br>
                        <input type='text' name='emergencia' id='emergencia' value='$emergencia'><br>
                        <label for=''> Gasto Micronutrientes(%)</label><br>
                        <input type='text' name='micronutrientes' id='micronutrientes' value='$micro'><br>
                        <label for=''> Gasto Macronutrientes(%)</label><br>
                        <input type='text' name='macronutrientes' id='macronutrientes' value='$macro'><br>
                        <label for=''> Gasto Agua(%)</label><br>
                        <input type='text' name='agua' id='agua' value='$agua'><br><br>
                       
                    ";

                }
                } 
               
                ?>
            </form>      
           
              
          </div>
            <div class="container col-md-9">
                
                 <form action="" method="post">
              
                 <div class="col-md-4" >
                    <label>Graphica de Humedad suelo:<br></label>
                    <a href="humSue.php"><img class="img-responsive" src="<?php echo $plot->EncodeImage();?>" ></a>
                </div>
                <div class="col-md-4" >
                    <label>Graphica de Humedad relativa:<br></label>
                    <a href="humrela.php"><img class="img-responsive" src="<?php echo $plotHR->EncodeImage();?>">
                </div>
                <div class="col-md-4" >
                    <label style="font-weight: no">Graphica de Temperatura:<br></label>
                    <a href="temperatura.php"><img class="img-responsive" src="<?php echo $plotTp->EncodeImage();?>"></a>
                </div>
                <div class="col-md-4">
                    <label>Graphica de Luz:<br></label>
                    <a href="luz.php"><img class="img-responsive" src="<?php echo $plotLuz->EncodeImage();?>"></a>
                </div>
                 <div class="col-md-4">
                    <label>Graphica de Macronutrientes:<br></label>
                    <a href="macronut.php"><img class="img-responsive" src="<?php echo $plotMI->EncodeImage();?>" ></a>
                </div>
                <div class="col-md-4">
                    <label>Graphica de Micronutrientes:<br></label>
                    <a href="micronut.php"><img class="img-responsive" src="<?php echo $plotMI->EncodeImage();?>" ></a>
                </div>
                <div class="col-md-4">
                    <label>Graphica de Mezcla:<br></label>
                    <a href="tambo.php"><img class="img-responsive" src="<?php echo $plotTB->EncodeImage();?>" ></a>
                </div>
                <br>
                </div>
            </form>
        </div>

            </div>
           
</body>
</html>

 <link rel="stylesheet" href="bootstrap-3.3.4-dist/js">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
>>>>>>> origin/master
