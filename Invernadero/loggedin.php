<div class="widget">
	<?php
	if($user_data['Tipo']=="Alumno")
    		echo "<h2>Hello".$user_data['Nombres']."</h2>";
    	else
    			echo "No";

    ?>
    <div class="inner">
        <li>
            <a href="logout.php">LogOut</a>
        </li>
    </div>
</div>