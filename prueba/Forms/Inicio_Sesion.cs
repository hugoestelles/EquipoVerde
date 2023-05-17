using System;
using NutriWise.RecursosLocalizables;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Inicio_Sesion : Form
    {
        public Inicio_Sesion()
        {
            InitializeComponent();
        }

        private void btnInicio_Sesion_Click(object sender, EventArgs e)
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

        private void lblCrear_Click(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jaja Pringao");
        }

        private void pctContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == '♥')
            { 
                txtContraseña.PasswordChar = '\0';
                pctContraseña.Image = NutriWise.Properties.Resources.ver;
            }

            else 
            { 
                txtContraseña.PasswordChar = '♥';
                pctContraseña.Image = NutriWise.Properties.Resources.ojo;
            }
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AplicarIdioma()
        {
            lblInicio.Text = StringRecursos.sesion;
            lblBienvenido.Text = StringRecursos.Bienvenida1;
            lblCredenciales.Text = StringRecursos.Credenciales;
            lblContraseña.Text = StringRecursos.Contraseña;
            lblOlvidado.Text = StringRecursos.olvidar;
            btnInicio.Text = StringRecursos.sesion;
            lblNoCuenta.Text = StringRecursos.nocuenta;
            lblCrear.Text = StringRecursos.crear;
        }
        public void EstablecerCultura(string cultura)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();


        }

        private void Inicio_Sesion_Load(object sender, EventArgs e)
        {
            EstablecerCultura("EN-GB");
        }


    }
}
