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

                        echo "hora: ".$temp[1]."   valor Humedad suelo".$temp[2]."<br>";
                       

                    }
                fclose($myfile);


                
            }
            else
            {
                $errors[]="archivo no existe";
                print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
            }
        ?>

</aside>