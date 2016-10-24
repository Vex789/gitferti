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
        if(isset($_SESSION['user_id']))
        	echo 'Logged In';
        ?>
    </div>
</body>
</html>
