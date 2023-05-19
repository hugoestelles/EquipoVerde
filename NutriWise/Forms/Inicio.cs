using System;
using System.Windows.Forms;

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
    }
}
