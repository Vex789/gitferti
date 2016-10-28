 <?php
        if(isset($_SESSION['user_id']))
        {

          echo 'Logged In';
          echo "
            <nav class='navbar navbar-default col-md-12' role='navigation'>
            <div class='navbar-header'>
            <button type='button' class='navbar-toggle' data-toggle='collapse'data-target='.navbar-ex1-collapse'>
            <span class='sr-only'>Desplegar navegación</span>
            <span class='icon-bar'></span>
            <span class='icon-bar'></span>
            <span class='icon-bar'></span>
            </button>
            <a class='navbar-brand' href='home.php'>Home</a>
            </div>" ;
          echo "<div class='collapse navbar-collapse navbar-ex1-collapse'>
                <ul class='nav navbar-nav'>
                <li ><a href='respaldos.php'>Respaldos</a></li> 
                <li >
                <a href='leecosa.php' class='dropdown-toggle' data-toggle='dropdown'>Graficas<b class='caret'></b>
                </a>
                <ul class='dropdown-menu'>
                  <li><a href='humSue.php'>Grafica de Humedad suelo</a></li>
                  <li><a href='humrela.php'>Grafica de Humedad Relativa</a></li>
                  <li><a href='temperatura.php'>Grafica de Temperatura</a></li>
                  <li><a href='luz.php'>Grafica de Luz</a></li>
                  <li><a href='macronut.php'>Grafica de Macronutrientes</a></li>
                  <li><a href='micronut.php'>Grafica de Micronutrientes</a></li>
                  <li><a href='tambo.php'>Grafica  de Mezcla</a></li>
                </ul>
                </li>              
                </ul>
               </div>";
        }
        else
        {
          
          echo "
            <nav class='navbar navbar-default col-md-12' role='navigation'>
            <div class='navbar-header'>
            <button type='button' class='navbar-toggle' data-toggle='collapse'data-target='.navbar-ex1-collapse'>
            <span class='sr-only'>Desplegar navegación</span>
            <span class='icon-bar'></span>
            <span class='icon-bar'></span>
            <span class='icon-bar'></span>
            </button>
            <a class='navbar-brand' href='home.php'>Home</a>
            </div>" ;
          
          echo " <div class='collapse navbar-collapse navbar-ex1-collapse'>
                <ul class='nav navbar-nav'>
                <li class='disabled'><a href='respaldos.php'>Respaldos</a></li> 
                <li class='dropdown disabled'>
                <a href='leecosa.php' class='dropdown-toggle' data-toggle='dropdown'>Graficas<b class='caret'></b>
                </a>
                <ul class='dropdown-menu'>
                <li><a href='humSue.php'>Grafica de Humedad suelo</a></li>
                <li><a href='humrela.php'>Grafica de Humedad Relativa</a></li>
                <li><a href='temperatura.php'>Grafica de Temperatura</a></li>
                <li><a href='luz.php'>Grafica de Luz</a></li>
                <li><a href='macronut.php'>Grafica de Macronutrientes</a></li>
                <li><a href='micronut.php'>Grafica de Micronutrientes</a></li>
                <li><a href='tambo.php'>Grafica  de Mezcla</a></li>
                </ul>
                </li>              
                </ul>
                </div>";
        }
        ?>
  <!-- En caso de no haberse logueado-->
  <!--<div class="collapse navbar-collapse navbar-ex1-collapse">
    <ul class="nav navbar-nav">
          <li class="disabled"><a href='respaldos.php'>Respaldos</a></li> 
          <li class="dropdown disabled">
        <a href="" class="dropdown-toggle" data-toggle="dropdown">Grafica<b class="caret"></b>
        </a>
        <ul class="dropdown-menu">
          <li><a href="humSue.php">Grafica de Humedad suelo</a></li>
          <li><a href="humrela.php">Grafica de Humedad Relativa</a></li>
          <li><a href="temperatura.php">Grafica de Temperatura</a></li>
          <li><a href="luz.php">Grafica de Luz</a></li>
          <li><a href="macronut.php">Grafica de Macronutrientes</a></li>
          <li><a href="micronut.php">Grafica de Micronutrientes</a></li>
          <li><a href="tambo.php">Grafica  de Mezcla</a></li>
    </ul>
      </li>              
                 
                    
           

     
    </ul>
 
</div>
</nav>-->
