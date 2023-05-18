using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Rectangle = System.Drawing.Rectangle;

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
            catch (Exception ex)
            {
                // MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }
        public static void EnviarDieta(Usuario user)
        {



            // Calcular las dimensiones del rectángulo en base al área deseada
            double ancho = 800;
            double alto = 500;

            // Obtener el tamaño de la pantalla
            Screen screen = Screen.PrimaryScreen;
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            // Calcular las coordenadas para el rectángulo centrado en la pantalla
            int rectX = (screenWidth - (int)ancho);
            int rectY = (screenHeight - (int)alto);

            //Point p1 = new Point(1294,751);
            //Point p2 = new Point(108,113);
            Point p1 = new Point(rectX, rectY);
            Point p2 = new Point(108, 113);
            Size s1 = new Size(800, 300);
            // Crear el rectángulo usando la clase Rectangle de System.Drawing
            Rectangle rectangulo = new Rectangle(p1, s1);
            Document documento = new Document();
            //Creamos la instancia para generar el archivo PDF
            //Le pasamos el documento creado arriba y con capacidad para abrir o Crear y de nombre Mi_Primer_PDF
            PdfWriter.GetInstance(documento, new FileStream(@"C:\Dieta.pdf", FileMode.Create));
            documento.Open();
            Bitmap objBitmap = new Bitmap(700, 300);

            //Rectangle r1 = new Rectangle(X, Y, ancho, largo);
            Graphics g1 = Graphics.FromImage(objBitmap);
            g1.CopyFromScreen(p1, Point.Empty, rectangulo.Size);
            objBitmap.Save(@"C:\Dieta.png", ImageFormat.Png);
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Dieta.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 500 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            documento.Add(new Paragraph($"Aqui tienes tu dieta {user.Nombre}:\n\n\n\n"));
            documento.Add(new Paragraph($""));
            documento.Add(new Paragraph($""));
            //int id = Usuario.BuscarDieta(user.Objetivo, user.Intolerancia);
            //documento.Add(new Paragraph($"Id de la dieta: {id}"));
            documento.Add(imagen);
            documento.Close();

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("nutriwiseinformacion@gmail.com", "NutriWise", System.Text.Encoding.UTF8);
            correo.To.Add(user.Correo);
            correo.Subject = " Aqui tienes tu dieta:";
            correo.Body = "Gracias por utilizar nuestra aplicación :).";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            MemoryStream m1 = new MemoryStream();
            m1.Position = 0;
            correo.Attachments.Add(new Attachment(@"C:\Dieta.pdf"));

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
    }
}