<!doctype html>
<?php include 'init.php';?>
<html>
<?php include 'head.php'; ?>
<body>
    <?php include 'header.php'; ?>
    <div id="container">
        
        <?php
        if(isset($_GET['success'])==false)
        {
            if(empty($_POST)== false)
            {
            	$required_fields= array('Nombres','Apellidos','Correo','Tipo');
            	foreach ($_POST as $key => $value) {
                    if (empty($value) && in_array($key, $required_fields)==true) {
                        $errors[]= 'faltan campos';
                        break 1;
                    }
                }
            
                if(user_exists($_POST['username'])==true)
                {
                    $errors[]='usuario ya existe';
                }
                if(filter_var($_POST['Correo'],FILTER_VALIDATE_EMAIL)===false)
                {
                    $errors[]='Ingresa un correo valido';
                }
                if(email_exists($_POST['Correo'])==true)
                {
                    $errors[]='correo ya usado';
                }
            }
        }
        ?>
        <h1>Registrar</h1>
        <?php
            if(isset($_GET['success']) && empty($_GET['success']))
            { 
                echo 'REGISTRADO';
                echo $temppassword;
                echo $tempusername;
            }else
            { 
                if(empty($errors)==true && empty($_POST)==false)
                {
                    $temppassword=$_POST['username'];
                    $tempusername=$_POST['password'];
                    $register_data = array(
                        'Nombres' => $_POST['Nombres'],
                        'Apellidos' => $_POST['Apellidos'],
                        'Correo' => $_POST['Correo'],
                        'username' => $_POST['username'],
                        'password' => $_POST['password'],
                        'Tipo' => $_POST['Tipo'],
                        );

                    register_user($register_data);
                    header('Location: register.php?success');
                    exit();
                }
                else
                if (empty($errors)==false)
                {
                    print_r('<ul><li>'.implode('</li><li>', $errors).'</li></ul>');
                }
            
            
        ?>
                <form action="" method="post">
                	<ul>
                		<li>
                			Nombres*:<br>
                			<input type="text" name= "Nombres">
                		</li>
                		<li>
                			Apellidos*:<br>
                			<input type="text" name ="Apellidos">
                		</li>
                		<li>
                			Correo*:<br>
                			<input type="text" name= "Correo">
                		</li>
                		<li>
                			Usuario:<br>
                			<input type="text" name= "username" >
                		</li>
                		<li>
                			Contraseña:<br>
                			<input type="password" name= "password">
                		</li>
                        <li>
                            Tipo:<br>
                            <select name="Tipo">
                                <option value="Admin">Admin</option>
                                <option value="Ingeniero">Ingeniero</option>
                                <option value="Alumno">Alumno</option>
                                <option value="Visitante">Visitante</option>
                            </select>
                        </li>
                		<li>
                			<input type="submit" value="Registrar">
                		</li>
                	</ul>
                </form>
            <?php } ?>
    </div>
</body>
</html>