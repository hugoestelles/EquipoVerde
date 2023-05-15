using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases;

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

                int resultado = 0;

                ConexionBD.AbrirConexion();
                if (!string.IsNullOrEmpty(txtEliminarUsu.Text))
                {
                    string nombre = txtEliminarUsu.Text;
                    if (ConexionBD.Conexion != null)
                    {

                        DialogResult confirmacion = MessageBox.Show("Borrado de registro seleccionado. ¿Continuar?",
                                                    "Eliminación", MessageBoxButtons.YesNo);
                        resultado = Usuario.EliminarUsuario(nombre);

                    }
                    else
                    {
                        MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
                    }
                    // Cierro la conexión
                    ConexionBD.CerrarConexion();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
