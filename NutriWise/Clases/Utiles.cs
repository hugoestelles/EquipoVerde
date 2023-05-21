using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Rectangle = System.Drawing.Rectangle;

namespace NutriWise.Clases
{
    static class Utiles
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
            catch (Exception)
            {
                // MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }
        public static void EnviarListaCompra(Usuario user, string lista)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("nutriwiseinformacion@gmail.com", "NutriWise", System.Text.Encoding.UTF8);
            correo.To.Add(user.Correo);
            correo.Subject = " Aqui tienes tu lista de la compra:";
            correo.Body = lista;
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
            catch (Exception)
            {
                // MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }
        public static void EnviarDieta(Usuario user, string ruta)
        {
            
            Directory.CreateDirectory(@"C:\NutriWise");

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("nutriwiseinformacion@gmail.com", "NutriWise", System.Text.Encoding.UTF8);
            correo.To.Add(user.Correo);
            correo.Subject = " Aqui tienes tu dieta:";
            correo.Body = "Gracias por utilizar nuestra aplicación :).";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            MemoryStream m1 = new MemoryStream();
            m1.Position = 0;
            correo.Attachments.Add(new Attachment(ruta));

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
            catch (Exception)
            {
                // MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }
        /// <summary>
        /// Funcion para comprobar que el indice de 4 comboBoxes no coincide, a excepcion del caso -1.
        /// </summary>
        /// <param name="selectedIndex1">Indice 1º comboBox</param>
        /// <param name="selectedIndex2">Indice 2º comboBox</param>
        /// <param name="selectedIndex3">Indice 3º comboBox</param>
        /// <param name="selectedIndex4">Indice 4º comboBox</param>
        /// <returns>True si no hay coincidencias, false si las hay.</returns>
        public static bool ComprobarComboBoxes(int selectedIndex1, int selectedIndex2, int selectedIndex3, int selectedIndex4)
        {
            // Verificar que no haya coincidencias excepto cuando selectedIndex es -1
            if ((selectedIndex1 != selectedIndex2 || selectedIndex1 == -1 || selectedIndex2 == -1) &&
                (selectedIndex1 != selectedIndex3 || selectedIndex1 == -1 || selectedIndex3 == -1) &&
                (selectedIndex1 != selectedIndex4 || selectedIndex1 == -1 || selectedIndex4 == -1) &&
                (selectedIndex2 != selectedIndex3 || selectedIndex2 == -1 || selectedIndex3 == -1) &&
                (selectedIndex2 != selectedIndex4 || selectedIndex2 == -1 || selectedIndex4 == -1) &&
                (selectedIndex3 != selectedIndex4 || selectedIndex3 == -1 || selectedIndex4 == -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ComprobarAceptarDieta(System.Windows.Forms.ComboBox[] comboBoxes)
        {
            for (int i = 0; i < comboBoxes.Length; i++)
            {
                for (int j = i + 1; j < comboBoxes.Length; j++)
                {
                    if (comboBoxes[i].SelectedIndex == comboBoxes[j].SelectedIndex && comboBoxes[i].SelectedIndex != -1) return false;
                }
            }
            return true;
        }
        public static Usuario CargarUsuarioActual()
        {
            Usuario user = Usuario.BuscarUsuario(Usuario.UsuarioActual.Correo);
            int id = Usuario.BuscarDieta(user.Objetivo, user.Intolerancia);
            Dietas d1 = new Dietas();
            d1.ObtenerDatosDieta(id);
            d1.Platos = d1.BuscarPlatos();
            List<Platos> p1 = d1.Platos;
            for (int i = 0; i < d1.Platos.Count; i++)
            {
                d1.Platos[i].ListaAlimentos = d1.Platos[i].BuscarAlimentos();
                d1.Platos[i].ListaCantidades = d1.Platos[i].BuscarCantidades();
            }
            Usuario.DietaActual= d1;
            return user;
        }
        public static string SeleccionarPDF(Usuario user)
        {
            int id = user.Id;
            switch (id)
            {
                case 1:
                    return "Ruta 1 dieta";
                case 2:
                    return "Ruta 2 dieta";
                case 3:
                    return "Ruta 3 dieta";
                case 4:
                    return "Ruta 4 dieta";
                case 5:
                    return "Ruta 5 dieta";
                case 6:
                    return "Ruta 6 dieta";
                case 7:
                    return "Ruta 7 dieta";
                case 8:
                    return "Ruta 8 dieta";
                case 9:
                    return "Ruta 9 dieta";
                case 10:
                    return "Ruta 10 dieta";
                case 11:
                    return "Ruta 11 dieta";
                case 12:
                    return "Ruta 12 dieta";
                case 13:
                    return "Ruta 13 dieta";
                case 14:
                    return "Ruta 14 dieta";
                case 15:
                    return "Ruta 15 dieta";
                default:
                    return "";
            }
        }
        public static string FormatearListaCompra(Dietas dietaActual)
        {
            string retorno = "";
            List<Platos> p1 = dietaActual.Platos;
            List<Alimentos> lista = new List<Alimentos>();
            for (int i = 0; i < p1.Count; i++)
            {
                List<Alimentos> provisional = p1[i].ListaAlimentos;
                for (int j = 0; j < provisional.Count; j++)
                {
                    bool compro = false;
                    for (int k = 0; k < lista.Count; k++)
                    {
                        if (provisional[j].Nombre == lista[k].Nombre) compro= true;
                    }
                    if (!compro) 
                    { 
                        lista.Add(provisional[j]);
                        retorno += "\t" + provisional[j].Nombre;
                    }
                }
                retorno += "\n";

            }
            return retorno;

        }
    }
}