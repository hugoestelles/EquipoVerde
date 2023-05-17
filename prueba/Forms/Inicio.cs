using System;
using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnInicio_Sesion_Click(object sender, EventArgs e)
        {

            // Crea una nueva instancia del formulario Form2
            Inicio_Sesion form2 = new Inicio_Sesion();
            // Esconde el formulario 
            this.Hide();
            // Muestra el nuevo formulario
            form2.ShowDialog();
            // Cierra el formulario 
            this.Close();



        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {

            // Crea una nueva instancia del formulario Form2
            CrearCuenta form3 = new CrearCuenta();

            // Esconde el formulario 
            this.Hide();

            // Muestra el nuevo formulario
            form3.ShowDialog();

            // Cierra el formulario 
            this.Close();

        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AplicarIdioma()
        {
            label1.Text = StringRecursos.Bienvenida;
            btnInicio.Text = StringRecursos.sesion;
            btnRegistrarse.Text = StringRecursos.Registrarse;
        }

        public void EstablecerCultura(string cultura)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();


        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            EstablecerCultura("EN-GB");
        }
    }
}
