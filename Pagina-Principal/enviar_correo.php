<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Verificar si se envió el formulario
  // Obtener los valores del formulario
  $nombre = $_REQUEST['nombre'];
  $email = $_REQUEST['email'];
  $mensaje = $_REQUEST['mensaje'];

  // Configurar el destinatario y el asunto del correo electrónico
  $destinatario = "nutriwiseinformacion@gmail.com";
  $asunto = "Nuevo mensaje de contacto";

  // Construir el cuerpo del correo electrónico
  $cuerpo = "Nombre: " . $nombre . "\n";
  $cuerpo .= "Email: " . $email . "\n";
  $cuerpo .= "Mensaje: " . $mensaje . "\n";

  // Configurar la dirección de retorno de mensaje
  $headers = "From: " . $email . "\r\n";
  $headers .= "Reply-To: " . $email . "\r\n";
  $headers .= "Return-Path: " . $email . "\r\n";

  // Enviar el correo electrónico
  $resultado = mail($destinatario, $asunto, $cuerpo, $headers);

  // Verificar si el correo se envió correctamente
  if ($resultado) {
    echo "¡Gracias por contactarnos! Tu mensaje ha sido enviado.";
    echo "<br>";
    // html par volver a la pagina principal;
    echo "<a href='pagina_principal_en.php'>Volver a la pagina principal</a>";

  } else {
    echo "Hubo un error al enviar el mensaje. Por favor, inténtalo de nuevo más tarde.";
  }
?>
