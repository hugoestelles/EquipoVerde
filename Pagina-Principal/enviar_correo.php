<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Verificar si se envió el formulario
if (isset($_POST['enviar'])) {
  // Obtener los valores del formulario
  echo "SSSS";
  $nombre = $_POST['nombre'];
  $email = $_POST['email'];
  $mensaje = $_POST['mensaje'];

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
  } else {
    echo "Hubo un error al enviar el mensaje. Por favor, inténtalo de nuevo más tarde.";
  }
}
?>
