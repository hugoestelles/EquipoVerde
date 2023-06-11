using NutriWise.Clases;
using System;
using System.Windows.Forms;
using NutriWise.RecursosLocalizables;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Donativos : UserControl
    {
        public Donativos()
        {
            InitializeComponent();
        }

        private void btnDonacion_Click(object sender, System.EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            Usuario user = Usuario.UsuarioActual;
            Donativo donacion = new Donativo((double)nudCantidad.Value, fecha, user.Nombre, user.Id);

            try
            {
                if (ConexionBD.Conexion != null) ConexionBD.AbrirConexion();
                donacion.Donar();
                MessageBox.Show("Su donación de " + donacion.Cant + " euros se ha llevado a cabo.", "Donación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("Error al conectar con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { ConexionBD.CerrarConexion(); }
        }

        private void AplicarIdioma()
        {
            lblDonacion.Text = StringRecursos.donacion;
            lblCredenciales.Text = StringRecursos.Credenciales;
            lblCantidad.Text = StringRecursos.Cantidad;
            btnDonacion.Text = StringRecursos.Donar;
        }
        public void EstablecerCultura(string cultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();
        }
    }
}
