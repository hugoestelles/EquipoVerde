using NutriWise.Clases;
using System;
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
            ////Activar cuando hayan datos
            //// Comprobamos si el correo es correcto
            //if (Usuario.ComprobarCorreoEstatico(txtMail.Text))
            //{
            //    // Comprobamos si la cuenta existe
            //    if (Usuario.YaEstaUsuario(txtMail.Text))
            //    {
            //        // Comprobamos si la clave es correcta
            //        if (Usuario.ComprobarClaveEstatica(txtMail.Text, txtContraseña.Text))
            //        {
            //            // Crea una nueva instancia del formulario Form2
            //            Menu form4 = new Menu();

            //            // Esconde el formulario 
            //            Hide();

            //            // Muestra el nuevo formulario
            //            form4.ShowDialog();

            //            // Cierra el formulario 
            //            Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("La clave introducida es incorrecta.", "Clave incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("El usuario introducido no existe.", "Usuario inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("El correo introducido es incorrecto.", "Correo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            // Eliminar cuando se active lo de arriba
            // Crea una nueva instancia del formulario Form2
            Menu form4 = new Menu();

            // Esconde el formulario 
            Hide();

            // Muestra el nuevo formulario
            form4.ShowDialog();

            // Cierra el formulario 
            Close();
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
    }
}
