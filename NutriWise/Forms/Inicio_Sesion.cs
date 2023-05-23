using MySql.Data.MySqlClient;
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
            try
            {
                using (MySqlConnection conect = ConexionBD.Conexion)
                {
                    ConexionBD.CerrarConexion();
                    ConexionBD.AbrirConexion();
                    string correo = txtMail.Text;
                    string contra = txtContraseña.Text;
                    //// Comprobamos si el correo es correcto
                    if (Usuario.ComprobarCorreoEstatico(correo))
                    {
                        // Comprobamos si la cuenta existe
                        if (Usuario.YaEstaUsuario(correo))
                        {
                            // Comprobamos si la clave es correcta
                            if (Usuario.ComprobarClaveEstatica(correo, contra))
                            {
                                Usuario user = Usuario.BuscarUsuario(correo);
                                Usuario.UsuarioActual = user;
                                Usuario.UsuarioActual = Utiles.CargarUsuarioActual();
                                MessageBox.Show(Usuario.DietaActual.Nombre);
                                //MessageBox.Show("Bienvenido " + user.Nombre + " " + user.Apellidos, "Inicio de sesión correcto");
                                ConexionBD.CerrarConexion();

                                // Crea una nueva instancia del formulario Form2
                                Menu form4 = new Menu();

                                // Esconde el formulario
                                Hide();

                                // Muestra el nuevo formulario
                                form4.ShowDialog();

                                // Cierra el formulario
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("La clave introducida es incorrecta.", "Clave incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ConexionBD.CerrarConexion();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El correo introducido no existe.", "Usuario inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ConexionBD.CerrarConexion();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El correo introducido es erróneo.", "Correo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ConexionBD.CerrarConexion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ConexionBD.CerrarConexion();
            }
            finally
            {
                ConexionBD.CerrarConexion();
            }
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
