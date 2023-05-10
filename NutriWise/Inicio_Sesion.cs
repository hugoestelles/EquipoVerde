using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void label8_Click(object sender, EventArgs e)
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
        

    }
}
