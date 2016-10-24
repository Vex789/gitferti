 <?php 
	session_start();
	$temppassword='';
	$tempusername='';
	require 'connect.php';
	require 'user.php';
	if(isset($_SESSION['user_id']))
	{
		$session_user_id=$_SESSION['user_id'];
		$user_data= user_data($session_user_id,'user_id','Nombres','Apellidos','Tipo');
	}
	$errors = array();
?>