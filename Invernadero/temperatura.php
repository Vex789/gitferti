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
    <div id="container">
        <?php include 'asidetemp.php'; ?>
        <h1></h1>
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
                        $min=$temp[7];
                        $max=$temp[8];

                        $hum1[]=array($uid,$temp[9]);
                       

                    }
                fclose($myfile);
                require_once 'phplot.php';  // here we include the PHPlot code 
                $plot = new PHPlot(600, 400);
                $plot->SetDataValues($hum1);
                //Turn off X axis ticks and labels because they get in the way:
                $plot->SetXTickLabelPos('none');
                $plot->SetXTickPos('none');
                $plot->SetPrintImage(False); // No automatic output
                //Draw it
                $plot->DrawGraph();


                
            }
            else
            {
                $errors[]="archivo no existe";
                print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
            }
        ?>

        <form action="" method="post">
            <ul>
            	<div>
                    Graphica de Temperatura:<br><br>
                    <?php
                    echo "Valor Minimo ".$min."&emsp;"."Valor Maximo".$max."<br>";
                    ?> 
                    <img class="img-responsive" src="<?php echo $plot->EncodeImage();?>" >
                </div>

            </ul>
        </form>
    </div>
</body>
</html>