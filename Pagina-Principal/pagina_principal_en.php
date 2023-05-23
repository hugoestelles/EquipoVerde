<?php 
    $servidor = "database-pi.cusxbcc1yr4p.us-east-1.rds.amazonaws.com"; // database-pi.cusxbcc1yr4p.us-east-1.rds.amazonaws.com
    $usuario = "admin";
    $password = "12345678";
    $db = "nutriwise";
    $conexion = mysqli_connect($servidor, $usuario, $password, $db);
    if (!$conexion) {
        die("Conexión fallida: " . mysqli_connect_error());
    }
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/gh/hung1001/font-awesome-pro-v6@18657a9/css/all.min.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link rel="stylesheet" href="./style.css">
    <script type="text/javascript">
  function googleTranslateElementInit() {
    new google.translate.TranslateElement({pageLanguage: 'es', includedLanguages: 'en', layout: google.translate.TranslateElement.InlineLayout.SIMPLE}, 'google_translate_element');
  }
</script>
<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
    <title>Nutri Wise</title>
</head>
<script>
    // Función para mostrar la sección correspondiente al botón seleccionado
    function showSection(sectionId) {
      // Ocultar todas las secciones
      var sections = document.querySelectorAll("section");
      for (var i = 0; i < sections.length; i++) {
        sections[i].classList.add("hidden");
      }

      // Mostrar la sección seleccionada
      var selectedSection = document.getElementById(sectionId);
      if (selectedSection) {
        selectedSection.classList.remove("hidden");
      }
    }
  </script>
  <script src="./index.js"></script>

<body>
    <div class="wrapper">

        <div class="top_navbar">
                <div class="top_menu">
                    <div class="logo">
                        NutriWise
                    </div>
                    <ul>
                        <li>
                            <div id="google_translate_element"></div>
                        </li>
                    </ul>

                </div>
        </div>

        <div class="sidebar">
            <ul>
                <li><a id="informacion">
                            <span class="icon"><i class="fa-solid fa-circle-info"></i></span>
                            <span class="title">Information</span>
                </a></li>
                <li><a id="dietas">
                        <span class="icon"><i class="fa-solid fa-salad"></i></span>
                        <span class="title">Dietas</span>
                </a></li>
                <li><a id = "valoraciones">
                        <span class="icon"><i class="fa-solid fa-star"></i></span>
                        <span class="title">Valoraciones</span>
                    </a></li>
                <li><a id="donaciones">
                        <span class="icon"><i class="fa-solid fa-hand-holding-dollar"></i></span>
                        <span class="title">Donations</span>
                </a></li>
                <li><a id="equipo">
                        <span class="icon"><i class="fa-solid fa-users"></i></span>
                        <span class="title">Equipo Desarrollador</span>
                </a></li>
                <li><a id="contacto">
                        <span class="icon"><i class="fa-solid fa-mailbox"></i></span>
                        <span class="title">Contactos</span>
                </a></li>

            </ul>
        </div>

        <div class="main_container">
        <div id="valoraciones-page">
            <?php 
                $consultaValoraciones = "SELECT * FROM valoraciones";
                $resultadoValoraciones = mysqli_query($conexion, $consultaValoraciones);
                echo "<h1>COMENTARIOS Y VALORACIONES</h1>";
                echo "<br>";
                echo "<br>";
                while ($fila = mysqli_fetch_array($resultadoValoraciones)) {
                    echo "<div class='message-container'>";
                    echo "<div class='message-circle'>";
                    echo "<i class='fa-solid fa-user-secret'></i>";
                    echo "</div>";
                    echo "<div class='message-bubble'>";
                    echo "<div class='message-info'>";
                    echo "Valoración : ";
                    for ($i = 0; $i < $fila['numEstrellas']; $i++) {
                        echo "<i class='fa-solid fa-star'></i>";
                    }
                    echo "</div>";
                    echo "<span>" . $fila['fechaValoracion'] . "</span>";
                    echo "<div class='message-text'>";
                    echo "<p>" . $fila['comentario'] . "</p>";
                    echo "</div>";
                    echo "</div>";
                    echo "</div>";
                }
            ?>
        </div>
            <div id="donaciones-page">
                <?php 
                    $usuariosTotalesConsulta = "SELECT SUM(idUsuario) AS usuariosTotales FROM usuario";
                    $resultadoUsuariosTotales = mysqli_query($conexion, $usuariosTotalesConsulta);
                    $filaUsuariosTotales = mysqli_fetch_assoc($resultadoUsuariosTotales);
                    $usuariosTotales = 0;
                    if ($filaUsuariosTotales && isset($filaUsuariosTotales['usuariosTotales'])) {
                        $usuariosTotales = $filaUsuariosTotales['usuariosTotales'];
                    }
                    
                    $consultaTotalDonado = "SELECT SUM(cantidad) AS total FROM donativos";
                    $resultadoTotalDonado = mysqli_query($conexion, $consultaTotalDonado);
                    $filaTotalDonado = mysqli_fetch_assoc($resultadoTotalDonado);
                    $totalDonado = 0;
                    if ($filaTotalDonado && isset($filaTotalDonado['total'])) {
                        $totalDonado = $filaTotalDonado['total'];
                    }
                    
                    $consultaNombrePrimerDonador = "SELECT usuario.nombre AS nombre, MAX(donativos.cantidad) AS max_monto
                    FROM usuario
                    INNER JOIN donativos ON usuario.idUsuario = donativos.idUsuari
                    GROUP BY usuario.nombre
                    ORDER BY max_monto DESC
                    LIMIT 1;";
                    $resultadoNombrePrimerDonador = mysqli_query($conexion, $consultaNombrePrimerDonador);
                    $filaNombrePrimerDonador = mysqli_fetch_assoc($resultadoNombrePrimerDonador);
                    $NombrePrimerDonador = '';
                    $CantidadPrimerDonador = 0;
                    if ($filaNombrePrimerDonador) {
                        $NombrePrimerDonador = $filaNombrePrimerDonador['nombre'];
                        $CantidadPrimerDonador = $filaNombrePrimerDonador['max_monto'];
                    }
                    
                    $consultaDonadores = "SELECT usuario.nombre AS nombre, donativos.fechaDonativo AS fecha, donativos.cantidad AS cantidad
                    FROM usuario
                    INNER JOIN donativos ON usuario.idUsuario = donativos.idUsuari
                    ORDER BY donativos.fechaDonativo DESC";
                    
                    // Execute the query and retrieve the results
                    $resultadoDonadores = mysqli_query($conexion, $consultaDonadores);
                    
                    // Check if the query executed successfully
                    if ($resultadoDonadores) {
                        // Process the results
                        while ($filaDonador = mysqli_fetch_assoc($resultadoDonadores)) {
                            // Access the data for each donator
                            $nombreDonador = $filaDonador['nombre'];
                            $fechaDonativo = $filaDonador['fecha'];
                            $cantidadDonativo = $filaDonador['cantidad'];
                            
                            // Perform further processing or output the data as needed
                            // ...
                        }
                    } else {
                        // Handle the case when the query fails
                        echo "Error executing the query: " . mysqli_error($conexion);
                    }
                    

                    $resultadoDonadores = mysqli_query($conexion, $consultaDonadores);               
                    
                    echo "<div class='top-donors'>";
                    echo "<h3 class='titulo-tabla'>Mejor Donante</h3>";
                    echo "<ol id='donors-list'>";
                    echo "<li class='titulo-tabla'><span class='donor-name'>". $NombrePrimerDonador ."</span> - <span class='donor-amount'>". $CantidadPrimerDonador ."€</span></li>";
                    echo "</ol>";
                    echo "</div>";
                    echo "<h3 class='titulo-tabla'>Donaciones</h3>";
                    echo "<table class='tabla-donadores'>";
                        echo "<thead><tr><th>Nombre</th><th>Fecha</th><th>Cantidad</th></tr></thead>";
                        echo "<tbody>";
                        while ($filaDonativo = mysqli_fetch_assoc($resultadoDonadores)) {
                        echo "<tr><td>" . $filaDonativo['nombre'] . "</td><td>" . $filaDonativo['fecha'] . "</td><td>" . $filaDonativo['cantidad'] . "€</td></tr>";
                        }
                        echo "</tbody>";
                    echo "</table>";
                    echo "<div class='estadisticas-container'>";
                    echo "<div class='estadistica'>";
                    echo "<div class='estadistica-title'>Usuarios Totales</div>";
                    echo "<i class='fa-solid fa-users'></i>";
                    echo "<p>". $usuariosTotales ."</p>";
                    echo "</div>";
                    echo "<div class='estadistica'>";
                    echo "<div class='estadistica-title'>Dinero recaudado</div>";
                    echo "<i class='fa-solid fa-money-bill'></i>";
                    echo "<p>". $totalDonado ."€</p>";
                    echo "</div>";
                    echo "</div>";
                ?>
            </div>

            <div id="informacion-page">
                <h1 class="title-info">¿Quiénes somos?</h1>
                <p class="text-info">NutriWise es una empresa especializada en el desarrollo de software para nutrición. Nuestra aplicación de escritorio, disponible en Windows, permite a los usuarios crear dietas personalizadas basadas en su peso y objetivos. Nos enfocamos en ofrecer una experiencia fácil de usar y personalizada para cada usuario.</p>

                <h2 class="subtitle-info">Nuestra historia</h2>
                <p class="text-info">NutriWise fue fundada en el año 2023 por un grupo de nutricionistas apasionados por la tecnología. Desde entonces, hemos trabajado arduamente para desarrollar y mejorar nuestra aplicación de nutrición, brindando una solución innovadora y accesible para las personas interesadas en mejorar su salud.</p>

                <h2 class="subtitle-info">Nuestro equipo</h2>
                <p class="text-info">En NutriWise, contamos con un equipo de expertos en nutrición y tecnología, dedicados a brindar la mejor experiencia a nuestros usuarios. Nuestro equipo se enfoca en estar siempre a la vanguardia en cuanto a tendencias de nutrición y tecnología, para poder ofrecer las soluciones más actualizadas y eficientes.</p>

                <h1 class="title-info">¿Qué hacemos?</h1>
                <p class="text-info">En NutriWise, nos enfocamos en brindar soluciones personalizadas de nutrición para cada usuario. Nuestra aplicación de escritorio permite a los usuarios crear dietas personalizadas basadas en su peso y objetivos, ofreciendo una amplia variedad de opciones para personalizar la dieta según las preferencias y restricciones alimentarias de cada usuario.</p>

                <h2 class="subtitle-info">Cómo funciona nuestra aplicación</h2>
                <p class="text-info">Para utilizar NutriWise, los usuarios simplemente deben ingresar su peso actual y su objetivo (ya sea perder peso, mantenerse en su peso actual o ganar masa muscular). Luego, la aplicación generará una dieta personalizada basada en los objetivos y preferencias alimentarias de cada usuario. Los usuarios pueden personalizar aún más su dieta agregando alimentos específicos o estableciendo restricciones alimentarias.</p>

                <h2 class="subtitle-info">Nuestro compromiso con la salud</h2>
                <p class="text-info">En NutriWise, estamos comprometidos con la salud de nuestros usuarios. Por eso, nos enfocamos en brindar soluciones personalizadas y eficientes para ayudar a las personas a alcanzar sus objetivos de nutrición. También ofrecemos una amplia variedad de recursos educativos en nuestro sitio web para ayudar a los usuarios a aprender más sobre nutrición y llevar un estilo de vida saludable.</p>
            </div>

            <div id="contacto-page">
                <h1 class="title-contacto">Contacta con nosotros</h1>
                <form action="enviar_correo.php" class="FormContact" method="POST" name="enviar">
                    <label for="nombre">Nombre:</label>
                    <input type="text" id="nombre" name="nombre" required>
                    <br><br>
                    
                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" required>
                    <br><br>
                    
                    <label for="mensaje">Mensaje:</label>
                    <input type="text" name="mensaje" id="mensaje" required>
                    <br><br>
                    
                    <input type="submit" value="Enviar">
                </form>
            </div>

            <div id="equipo-page">
            <h1 class="title-equipo">Nuestro Equipo</h1>
            <div class="cont-mensaje-bienvenida">
                <div class="mensaje-bienvenida">
                    Somos un grupo apasionado y dedicado de profesionales de la tecnología que trabajamos en el desarrollo y mejora continua de la plataforma NutriWise.
                    En NutriWise, nuestro objetivo principal es proporcionar una solución innovadora para ayudarte a llevar un estilo de vida saludable.
                    A través de nuestra plataforma, podrás acceder a herramientas y recursos útiles que te ayudarán a gestionar tu alimentación y mantener un equilibrio nutricional adecuado.
                    Como equipo de desarrolladores, nos enorgullece trabajar en conjunto para crear una experiencia en línea intuitiva y fácil de usar. Nos esforzamos por implementar nuevas funcionalidades, mejorar la usabilidad y garantizar la fiabilidad de la plataforma para ofrecerte la mejor experiencia posible.
                    Valoramos tus comentarios y sugerencias, ya que nos ayudan a continuar evolucionando y adaptándonos a tus necesidades. Nuestro compromiso es brindarte una plataforma confiable y efectiva que te ayude a tomar decisiones informadas sobre tu alimentación y bienestar general.
                    Gracias por ser parte de la comunidad NutriWise. ¡Esperamos que disfrutes de nuestra plataforma y que te sea útil en tu viaje hacia una vida más saludable!
                    ¡El equipo de desarrolladores de NutriWise!
                </div>
            </div>
            <!-- <div class="cont-img-grupal">
                <img src="img/R.jpg" alt="foto grupal" class="img-grupal">
            </div> -->
                <div class="cont-imagenes">
                <div class="team-member">
                    <img src="img/Oscar.jpeg" class="img-persona" alt="Foto del compañero 1">
                    <h2>Óscar</h2>
                </div>
                <div class="team-member">
                    <img src="img/Hugo.jpeg" class="img-persona" alt="Foto del compañero 2">
                    <h2>Hugo</h2>
                </div>
                <div class="team-member">
                    <img src="img/Jesus.jpg" class="img-persona" alt="Foto del compañero 3">
                    <h2>Jesús</h2>
                </div>
                <div class="team-member">
                    <img src="img/David.jpg" class="img-persona" alt="Foto del compañero 4">
                    <h2>David</h2>
                </div>
                <div class="team-member">
                    <img src="img/Alejandro.jpg" class="img-persona" alt="Foto del compañero 5">
                    <h2>Alejandro</h2>
                </div>
                <div class="team-member">
                    <img src="img/Ruben.jpg" class="img-persona" alt="Foto del compañero 6">
                    <h2>Rubén</h2>
                </div>
                </div>
            </div>

            <div id="dietas-page">
                <h1 class="title-equipo">Dietas Disponibles</h1>
                <div class="cont-dietas">
                    <?php
                        $consultaDietas = "SELECT * FROM dietas";
                        $resultadoDietas = mysqli_query($conexion, $consultaDietas);
                        while ($fila = mysqli_fetch_array($resultadoDietas)) {
                            $idDieta = $fila['idDieta'];
                            $nombreDieta = $fila['nombre'];
                            $tipoDieta = $fila['tipoDieta'];
                            $numPlatos = $fila['cantidadPlatos'];
                            $numIngredientes = $fila['cantidadIngredientes'];
                            echo "<div class='dieta-cont'>";
                            echo "<div class='nombre-dieta'>$nombreDieta</div>";
                            echo "<div class='tipo-dieta'>$tipoDieta</div>";
                            echo "<img src='img/dieta.jpg' alt='foto de la dieta' class='foto-dieta' width='190px' height='150px'>";
                            echo "<div class='cont-info-plato'>";
                            echo "<i class='fa-solid fa-plate-utensils num'></i><div class='num-platos'>$numPlatos</div>";
                            echo "<i class='fa-solid fa-carrot num'></i><div class='num-ingredientes'>$numIngredientes</div>";
                            echo "</div>";
                            echo "</div>";
                        };
                    ?>
                </div>
            </div>


        </div>
    </div>
</body>

</html>