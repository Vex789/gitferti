<!doctype html>
<?php include 'init.php';?>
<html>
<?php include 'head.php'; ?>
<body>
    <?php include 'header.php'; ?>
<<<<<<< HEAD
    <div id="container">
        <?php include 'aside.php'; ?>
        <h1>Hola</h1>
        <?php
        if(isset($_SESSION['user_id']))
        	echo 'Logged In';
        ?>
    </div>
=======
    <div class="container">
    <img src="0.jpg" class="img-responsive" width="1200" >
    </div>
  <!-- <br>
   <div id="myCarousel" class="carousel slide col" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
    <li data-target="#myCarousel" data-slide-to="3"></li>
  </ol>
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="1.jpg" alt="Chania">
    </div>

    <div class="item">
      <img src="2.jpg" alt="Chania">
    </div>

    <div class="item">
      <img src="3.jpg" alt="Flower">
    </div>

    <div class="item">
      <img src="4.jpg" alt="Flower">
    </div>
  </div>
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

      -->
       <?php include 'login.php'; ?>
       
          <?php
        if(isset($_SESSION['user_id']))
        	echo 'Logged In';
        ?>
   		

>>>>>>> origin/master
</body>
</html>
