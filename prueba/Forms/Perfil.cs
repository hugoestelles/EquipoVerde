using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Perfil : UserControl
    {

        public Perfil()
        {
            InitializeComponent();

        }
        public void AplicarIdioma()
        {
            lblNomb.Text = StringRecursos.Nombre;
            lblApell.Text = StringRecursos.Apellidos;
            lblAlt.Text = StringRecursos.Altura;
            lblPes.Text = StringRecursos.Peso;
            lblCorreo.Text = StringRecursos.Correo;
            lblTole.Text = StringRecursos.Alergias_tolerancias;
            lblAct.Text = StringRecursos.ActividadFisica;
            lblObj.Text = StringRecursos.Objetivo;
            lblTolerancias.Text = StringRecursos.Tolerancias;
            lblObjetivo.Text = StringRecursos.TipoObjetivo;
            lblActividad.Text = StringRecursos.dias;
        }
        public void EstablecerCultura(string cultura)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();


        }

       

        
    }




}
