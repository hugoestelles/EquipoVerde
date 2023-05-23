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
        /// Envía un correo de bienvenida al usario.
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
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Envía la lista de la compra al usuario.
        /// </summary>
        /// <param name="user">El usuario a quién se la tiene que enviar.</param>
        /// <param name="lista">Los alimentos que contiene la lista.</param>
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
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Envía la dieta al usuario.
        /// </summary>
        /// <param name="user">El usuario a quién se la tiene que enviar.</param>
        /// <param name="ruta">La ruta con el pdf de la dieta que tiene que enviar.</param>
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
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Comprueba si alguno de los platos de la dieta se repite.
        /// </summary>
        /// <param name="comboBoxes">Los platos a recibir.</param>
        /// <returns>Si se repite alguno o no.</returns>
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

        /// <summary>
        /// Carga el usuario que ha iniciado sesión.
        /// </summary>
        /// <returns>El usuario actual.</returns>
        public static Usuario CargarUsuarioActual()
        {
            Usuario user = Usuario.BuscarUsuario(Usuario.UsuarioActual.Correo);
            int id = user.IdDieta;
            Dietas d1 = new Dietas();
            d1.ObtenerDatosDieta(id);
            d1.Platos = d1.BuscarPlatos();
            for (int i = 0; i < d1.Platos.Count; i++)
            {
                d1.Platos[i].ListaAlimentos = d1.Platos[i].BuscarAlimentos();
                d1.Platos[i].ListaCantidades = d1.Platos[i].BuscarCantidades();
            }
            Usuario.DietaActual= d1;
            return user;
        }

        /// <summary>
        /// Selecciona uno de los pdf dependiendo de la dieta del usuario.
        /// </summary>
        /// <param name="user">Obtiene el usuario para saber cuál es su dieta.</param>
        /// <returns>El pdf correspondiente a la dieta del usuario.</returns>
        public static string SeleccionarPDF(Usuario user)
        {
            string rutaMadre = Directory.GetCurrentDirectory();
            string oneLevel = Directory.GetParent(rutaMadre).FullName;
            string twoLevel = Directory.GetParent(oneLevel).FullName;

            string carpetaMadre = Path.Combine(twoLevel, "Resources");
            string carpetaDietas = Path.Combine(carpetaMadre, "dietas");

            int id = user.IdDieta;
            switch (id)
            {
                case 1:
                    return Path.Combine(carpetaDietas, "Sin_bajarPeso.pdf");
                case 2:
                    return Path.Combine(carpetaDietas, "Sin_comerSano.pdf");
                case 3:
                    return Path.Combine(carpetaDietas, "Sin_Volumen.pdf");
                case 4:
                    return Path.Combine(carpetaDietas, "Gluten_bajarPeso.pdf");
                case 5:
                    return Path.Combine(carpetaDietas, "Gluten_comerSano.pdf");
                case 6:
                    return Path.Combine(carpetaDietas, "Gluten_Volumen.pdf");
                case 7:
                    return Path.Combine(carpetaDietas, "Lactosa_bajarPeso.pdf");
                case 8:
                    return Path.Combine(carpetaDietas, "Lactosa_comerSano.pdf");
                case 9:
                    return Path.Combine(carpetaDietas, "Lactosa_Volumen.pdf");
                case 10:
                    return Path.Combine(carpetaDietas, "Vegetariana_bajarPeso.pdf");
                case 11:
                    return Path.Combine(carpetaDietas, "Vegetariana_comerSano.pdf");
                case 12:
                    return Path.Combine(carpetaDietas, "Vegetariana_Volumen.pdf");
                case 13:
                    return Path.Combine(carpetaDietas, "Vegana_bajarPeso.pdf");
                case 14:
                    return Path.Combine(carpetaDietas, "Vegana_comerSano.pdf");
                case 15:
                    return Path.Combine(carpetaDietas, "Vegana_Volumen.pdf");
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
                        
                        retorno += "    -" + provisional[j].Nombre + "              ";
                    }
                }
                retorno += "\n ";
            }
            return retorno;

        }
        public static string FormatearListaCompraCorreo(Dietas dietaActual)
        {
            string retorno = "<center><p>";
            List<Platos> p1 = dietaActual.Platos;
            List<Alimentos> lista = new List<Alimentos>();
            for (int i = 0; i < p1.Count; i++)
            {
                List<Alimentos> provisional = p1[i].ListaAlimentos;
                retorno += "<pre>";
                for (int j = 0; j < provisional.Count; j++)
                {
                    bool compro = false;
                    for (int k = 0; k < lista.Count; k++)
                    {
                        if (provisional[j].Nombre == lista[k].Nombre) compro = true;
                    }
                    if (!compro)
                    {
                        lista.Add(provisional[j]);

                        retorno += "    - " + provisional[j].Nombre + "              ";
                    }
                }
                retorno += "</pre><br>";
            }
            retorno += "</p></center>";
            return retorno;

        }
    }
}