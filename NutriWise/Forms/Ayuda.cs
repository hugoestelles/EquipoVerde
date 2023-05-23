using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Ayuda : UserControl
    {
        public Ayuda()
        {
            InitializeComponent();
        }

        private void AplicarIdioma()
        {
            lblAyuda.Text = StringRecursos.MenuAyuda;
        }
        public void EstablecerCultura(string cultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();
        }
    }
}
