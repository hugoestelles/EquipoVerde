using MySql.Data.MySqlClient;
using NutriWise.Clases;
using System;
using System.Windows.Forms;

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
            if (txtContraseña.Text == txtConfirmar.Text)
            {
                try
                {
                    MySqlConnection conect = ConexionBD.Conexion;
                    ConexionBD.AbrirConexion();
                    if (!string.IsNullOrEmpty(txtMail.Text))
                    {
                        string correo = txtMail.Text;
                        if (Usuario.YaEstaUsuario(correo))
                        {
                            MessageBox.Show("Correo ya en uso, introduzca otro");
                            ConexionBD.CerrarConexion();
                        }
                        else
                        {
                            ConexionBD.CerrarConexion();
                            // Crea una nueva instancia del formulario Form2
                            Menu form4 = new Menu();

                            // Esconde el formulario 
                            this.Hide();

                            // Muestra el nuevo formulario
                            form4.ShowDialog();

                            // Cierra el formulario 
                            this.Close();
                            // Cerrar la conexión después de eliminar el usuario

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un correo válido.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    ConexionBD.CerrarConexion();
                }
            }
            else
            {
                MessageBox.Show("Contraseñas no coinciden.");
                ConexionBD.CerrarConexion();
            }
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
    }
}

