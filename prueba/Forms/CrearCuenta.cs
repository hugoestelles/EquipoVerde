using System;
using System.Windows.Forms;
using NutriWise.RecursosLocalizables;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }


        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Form2
            Menu form4 = new Menu();

            // Esconde el formulario 
            this.Hide();

            // Muestra el nuevo formulario
            form4.ShowDialog();

            // Cierra el formulario 
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
                txtConfirmar.PasswordChar = '\0';
                pctContraseña.Image = NutriWise.Properties.Resources.ver;
            }

            else
            {
                txtContraseña.PasswordChar = '*';
                txtConfirmar.PasswordChar = '*';
                pctContraseña.Image = NutriWise.Properties.Resources.ojo;
            }
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblIniciar_Click(object sender, EventArgs e)
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

        public void AplicarIdioma()
        {
            lblNombre.Text = StringRecursos.Nombre;
            label6.Text = StringRecursos.Peso;
            lblEmail.Text = StringRecursos.Correo;
            lblContraseña.Text = StringRecursos.Contraseña;
            lblIntolerancias.Text = StringRecursos.Intolerancias;
            lblApellido.Text = StringRecursos.Apellidos;
            lblAltura.Text = StringRecursos.Altura;
            lblObjetivo.Text = StringRecursos.Objetivo;
            lblConfirmar.Text = StringRecursos.Confirmar;
            lblActividad.Text = StringRecursos.Actividad;
            lblSemana.Text = StringRecursos.Semana;
            btnRegistrarse.Text = StringRecursos.Registrarse;
            lblIniciar.Text = StringRecursos.sesion;
            lblCrear.Text = StringRecursos.crear;
        }

        public void EstablecerCultura(string cultura)
        {

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();


        }

        private void CrearCuenta_Load(object sender, EventArgs e)
        {
            EstablecerCultura("EN-GB");
        }
    }
}

