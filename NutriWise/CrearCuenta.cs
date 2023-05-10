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
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
