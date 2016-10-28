<?php 
include 'init.php';


if(empty($_POST)== false)
{
	$username = $_POST['username'];
	$password = $_POST['password'];

	if(empty($username) || empty($password))
	{
		$errors[] = 'no hay datos';

	}else if(user_exists($username)==false)
	{
		$errors[] = 'no existe ese usuario';

	}else{
		$login = login($username,$password);
		if($login == false){
			$errors[]='Error en el password';
		}
		else
		{
			$_SESSION['user_id']=$login;
			header('Location: index.php');   
		}
	}
	
		
}
?>
<html>
<?php include 'head.php'; ?>
<body>
    <?php include 'header.php'; ?>
    <div id="container">
        <?php include 'aside.php'; ?>
        <h1>Hola</h1>
        <?php
        if(empty($errors)==false)
        print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
        ?>
    </div>
</body>
</html>

	        
	        
