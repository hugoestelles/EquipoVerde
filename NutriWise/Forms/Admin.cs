using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NutriWise.Clases;

namespace NutriWise
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void grbInfo_Enter(object sender, EventArgs e)
        {

        }

        private void txtEliminarUsu_TextChanged(object sender, EventArgs e)
        {

        }





        private void btnAdminEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conect = ConexionBD.Conexion)
                {
                    ConexionBD.CerrarConexion();
                    ConexionBD.AbrirConexion();
                    if (!string.IsNullOrEmpty(txtEliminarUsu.Text))
                    {
                        string correo = txtEliminarUsu.Text;
                        if (Usuario.ComprobarCorreoEstatico(correo))
                        {
                            DialogResult confirmacion = MessageBox.Show("Borrado de registro seleccionado. ¿Continuar?",
                                "Eliminación", MessageBoxButtons.YesNo);

                            if (confirmacion == DialogResult.Yes)
                            {

                                // Eliminar el usuario y obtener el número de registros afectados
                                int registrosAfectados = Usuario.EliminarUsuario(correo);

                                // Cerrar la conexión después de eliminar el usuario
                                ConexionBD.CerrarConexion();

                                if (registrosAfectados > 0)
                                {
                                    MessageBox.Show("El usuario se eliminó correctamente.");
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún usuario con el correo especificado.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Correo introducido erróneo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un correo.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
            }
            finally
            {
                ConexionBD.CerrarConexion();
            }
        }


        private void mnuPlatoAgregar_Click(object sender, EventArgs e)
        {
            grbPlato.Visible = true;
            grbPlato.BringToFront();
            grbDieta.Visible = false;
            grbEliminarUsu.Visible = false;

        }

        private void mnuDietaAgregar_Click(object sender, EventArgs e)
        {
            grbPlato.Visible = false;
            grbDieta.Visible = true;
            grbDieta.BringToFront();
            grbEliminarUsu.Visible = false;

        }
        private void mnuEliminarUsuario_Click(object sender, EventArgs e)
        {
            grbPlato.Visible = false;
            grbDieta.Visible = false;
            grbEliminarUsu.Visible = true;
            grbEliminarUsu.BringToFront();
        }

        private void timerAdmin_Tick(object sender, EventArgs e)
        {
            // lblAdminReloj = DateTime.Now.ToString("t");
        }

        private void btnAdminCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdminSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnElimVolver_Click(object sender, EventArgs e)
        {
            grbEliminarUsu.Visible = false;
        }

        private void btnDietaVolver_Click(object sender, EventArgs e)
        {
            grbDieta.Visible = false;
        }

        private void btnPlatoVolver_Click(object sender, EventArgs e)
        {
            grbPlato.Visible = false;
        }


    }
}
