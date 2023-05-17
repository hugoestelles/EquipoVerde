using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Dieta : UserControl
    {
        public Dieta()
        {
            InitializeComponent();
        }
        public void AplicarIdioma()
        {
            label1.Text = StringRecursos.descripcion;
        }
        public void EstablecerCultura(string cultura)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();


        }
    }
}
