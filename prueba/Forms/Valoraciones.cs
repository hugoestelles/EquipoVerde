using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Valoraciones : UserControl
    {
        public Valoraciones()
        {
            InitializeComponent();
        }
        public void AplicarIdioma()
        {
            label1.Text = StringRecursos.Receta;
            label4.Text = StringRecursos.Receta;
            label2.Text = StringRecursos.para1;
            label3.Text = StringRecursos.para2;
        }
        public void EstablecerCultura(string cultura)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();


        }
    }
}
