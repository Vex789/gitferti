<<<<<<< HEAD
<aside>
 	<?php
        $registros = array();
        
            $uid=0; 
            if (($myfile = fopen("hola", "r")) !== FALSE) {
               
                while (!feof($myfile)) 
                {
                    $datos1[] = fgets($myfile);
                   
                    
                }
                    
                    foreach ($datos1 as $dt) {
                        $uid++;
                        $temp=explode("#", $dt);

                        echo "hora: ".$temp[1]."   valor de Temperatura ".$temp[5]."<br>";
                       

                    }
                fclose($myfile);


                
            }
            else
            {
                $errors[]="archivo no existe";
                print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
            }
        ?>

=======
<aside>
<br><br><br>
<div class="col-md-1"></div>
<div class="col-md-3">
<span>Descripcion de Luz</span>
<br><br><br>
 	<?php
        $registros = array();
        
            $uid=0; 
            if (($myfile = fopen("hola", "r")) !== FALSE) {
               
                while (!feof($myfile)) 
                {
                    $datos1[] = fgets($myfile);
                   
                    
                }
                    
                    foreach ($datos1 as $dt) {
                        $uid++;
                        $temp=explode("#", $dt);

                        echo "hora: ".$temp[1]."   valor de Temperatura ".$temp[5]."<br>";
                       

                    }
                fclose($myfile);


                
            }
            else
            {
                $errors[]="archivo no existe";
                print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
            }
        ?>
</div>
>>>>>>> origin/master
</aside>