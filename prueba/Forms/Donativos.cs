using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
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

        public void AplicarIdioma()
        {
            lblDonacion.Text = StringRecursos.Donativos;
            lblCredenciales.Text = StringRecursos.Credenciales;
            lblNombre.Text = StringRecursos.Nombre;
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
