using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NutriWise.Clases
{
    class Utiles
    {
        /// <summary>
        /// Funcion para enviar un correo de bienvenida al usario.
        /// </summary>
        /// <param name="user">Usuario al que se lo queremos mandar.</param>
        public static void EnviarCorreoBienvenida(Usuario user)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("nutriwiseinformacion@gmail.com", "NutriWise", System.Text.Encoding.UTF8);
            correo.To.Add(user.Correo);
            correo.Subject = " ¡Bienvenido/a a Nutriwise! Comienza tu viaje hacia una vida saludable";
            string body = "Estimado/a  " + user.Nombre +
              "<br><br>¡Queremos darte la más cordial bienvenida a Nutriwise! Estamos encantados de que te hayas registrado en nuestra aplicación y hayas decidido embarcarte en un viaje hacia una vida más saludable y equilibrada. Queremos ser tu compañero confiable en esta travesía, proporcionándote las herramientas y recursos necesarios para alcanzar tus metas de bienestar." +
              "<br><br>En Nutriwise, entendemos que la nutrición es un factor fundamental para mantener una buena salud y alcanzar tus objetivos personales. Nuestra aplicación ha sido diseñada pensando en ti y en tus necesidades individuales. A través de ella, tendrás acceso a una amplia variedad de características y beneficios exclusivos que te ayudarán a seguir un estilo de vida saludable." +
              "<br><br>Aquí hay un vistazo de lo que puedes esperar de Nutriwise:" +
              "<br><br>  - Planes de alimentación personalizados: Nuestro equipo de expertos en nutrición ha desarrollado planes de alimentación adaptados a tus objetivos, preferencias y requerimientos específicos. Te brindaremos opciones saludables y equilibradas que se ajusten a tu estilo de vida." +
              "<br><br>-- Comunidad y soporte: Formarás parte de una comunidad activa y solidaria de personas que, al igual que tú, están comprometidas con un estilo de vida saludable. Podrás compartir tus experiencias, recibir apoyo y participar en desafíos que te motivarán a alcanzar tus metas." +
              "<br><br>Estamos emocionados de que hayas decidido unirte a Nutriwise y confíes en nosotros como tu aliado para alcanzar una vida más saludable. Nos comprometemos a brindarte un servicio excepcional y a acompañarte en cada paso del camino." +
              "<br><br>Si tienes alguna pregunta o necesitas ayuda, no dudes en ponerte en contacto con nuestro equipo de soporte. Estamos aquí para ayudarte y asegurarnos de que tengas la mejor experiencia posible con nuestra aplicación." +
              "<br><br>Una vez más, bienvenido a Nutriwise. Estamos emocionados de comenzar este viaje contigo y esperamos verte alcanzar tus objetivos de bienestar y salud." +
              "<br><br>¡Saludos saludables!";

            correo.Body = body;

            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("nutriwiseinformacion@gmail.com", "gibkjjmaiuliihbe");

            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

            try
            {
                smtp.Send(correo);
                // MessageBox.Show("Correo enviado con éxito");
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
