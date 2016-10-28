<aside>
	<?php
	if(isset($_SESSION['user_id']))
    	include 'loggedin.php';
	else
    	include 'login.php';
 	?>
 	
</aside>