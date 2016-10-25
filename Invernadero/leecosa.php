
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
    <div id="container" style="height:auto;">
        <?php include 'aside.php'; ?>
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