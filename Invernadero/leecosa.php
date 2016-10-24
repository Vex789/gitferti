
<!doctype html>
<?php include 'init.php';?>
<html>
<?php include 'head.php'; ?>
<body>
    <?php include 'header.php'; ?>
    <div id="container">
        <?php include 'aside.php'; ?>
        <h1>Hola</h1>
        <?php
        $registros = array();
        if(empty($_POST)== false)
        {
            $uid=0; 
            $datos=array();
            if (($myfile = fopen($_POST['archivo'], "r")) !== FALSE) {
               
                while (!feof($myfile)) 
                {
                    $datos[] = fgets($myfile);
                   
                    
                }

                    
                   
                    print_r($datos);
                    foreach ($datos as $dt) {
                        $uid++;
                        $temp=explode("#", $dt);
                        ##print_r($temp);
                        $r1[]=array($uid,$temp[1]);
                    }
                    print_r($r1);
                fclose($myfile);
                require_once 'phplot.php';  // here we include the PHPlot code 
                $plot = new PHPlot;
                $plot->SetDataValues($r1);

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
        }
        ?>
        <form action="" method="post">
            <ul>
                <li>
                    Archivo a subir*:<br>
                    <input type="text" name= "archivo">
                </li>
                
                <li>
                    <input type="submit" value="Upload">
                </li>
            </ul>
        </form>
        <img src="<?php echo $plot->EncodeImage();?>" alt="Plot Image">
    </div>
</body>
</html>