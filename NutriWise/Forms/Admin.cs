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

        private void btnBuscarUsu_Click(object sender, EventArgs e)
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
                            if (Usuario.YaEstaUsuario(correo))
                            {
                                DialogResult confirmacion = MessageBox.Show("Desea buscar el registro seleccionado. ¿Continuar?",
                                    "Buscar", MessageBoxButtons.YesNo);

                                if (confirmacion == DialogResult.Yes)
                                {

                                    // Buscar el usuario y obtener el número de registros afectados
                                    Usuario u1 = Usuario.BuscarUsuario(correo);

                                    lblElimNombreR2.Text = u1.Nombre;
                                    lblElimApe2.Text = u1.Apellidos;
                                    lblElimCorreo2.Text = u1.Correo;
                                    // Cerrar la conexión después de eliminar el usuario
                                    ConexionBD.CerrarConexion();

                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún usuario con el correo especificado.");
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
                MessageBox.Show("Error al buscar el usuario: " + ex.Message);
            }
            finally
            {
                ConexionBD.CerrarConexion();
            }
        }

        private void btnPlatoAceptar_Click(object sender, EventArgs e)
        {
            bool[] comp = new bool[4] { false, false, false ,false };
            try
            {
                if (ConexionBD.Conexion != null)
                {
                    ConexionBD.AbrirConexion();
                    if (txtNomPlato.Text != "") // Compruebo que el nombre del plato no este vacio.
                    {
                        //Comprobaciones 1 alimento.
                        if (cmbIngre1.SelectedIndex == -1 && txtAgregarIngre1.Text != "" && txtValorN1.Text != "")
                        {
                            comp[0] = true;
                            Alimentos a1 = new Alimentos(txtAgregarIngre1.Text, double.Parse(txtValorN1.Text));
                            if (!a1.ComprobarExistencia())
                            {
                                if(a1.AgregarAlimento() == 1)
                                {
                                    //Mostrar mensaje de alimento agreado con exito.
                                }
                                else
                                {
                                    //Mostrar mensaje indicando que ha ocurrido un error inesperado.
                                }
                            }
                            else
                            {
                                //Mostrar error diciendo que ya hay un alimento con ese nombre en la bd.
                            }
                        }
                        //Comprobaciones 2 alimento.
                        else if (cmbIngre2.SelectedIndex == -1 && txtAgregarIngre2.Text != "" && txtValorN2.Text != "")
                        {
                            comp[1] = true;
                            Alimentos a2 = new Alimentos(txtAgregarIngre2.Text, double.Parse(txtValorN2.Text));
                            if (!a2.ComprobarExistencia())
                            {
                                if (a2.AgregarAlimento() == 1)
                                {
                                    //Mostrar mensaje de alimento agreado con exito.
                                }
                                else
                                {
                                    //Mostrar mensaje indicando que ha ocurrido un error inesperado.
                                }
                            }
                            else
                            {
                                //Mostrar error diciendo que ya hay un alimento con ese nombre en la bd.
                            }
                        }
                        //Comprobaciones 3 alimento.
                        else if (cmbIngre3.SelectedIndex == -1 && txtAgregarIngre3.Text != "" && txtValorN3.Text != "")
                        {
                            comp[2] = true;
                            Alimentos a3 = new Alimentos(txtAgregarIngre3.Text, double.Parse(txtValorN3.Text));
                            if (!a3.ComprobarExistencia())
                            {
                                if (a3.AgregarAlimento() == 1)
                                {
                                    //Mostrar mensaje de alimento agreado con exito.
                                }
                                else
                                {
                                    //Mostrar mensaje indicando que ha ocurrido un error inesperado.
                                }
                            }
                            else
                            {
                                //Mostrar error diciendo que ya hay un alimento con ese nombre en la bd.
                            }
                        }
                        //Comprobaciones 4 alimento.
                        else if (cmbIngre4.SelectedIndex == -1 && txtAgregarIngre4.Text != "" && txtValorN4.Text != "")
                        {
                            comp[3] = true;
                            Alimentos a4 = new Alimentos(txtAgregarIngre4.Text, double.Parse(txtValorN4.Text));
                            if (!a4.ComprobarExistencia())
                            {
                                if (a4.AgregarAlimento() == 1)
                                {
                                    //Mostrar mensaje de alimento agreado con exito.
                                }
                                else
                                {
                                    //Mostrar mensaje indicando que ha ocurrido un error inesperado.
                                }
                            }
                            else
                            {
                                //Mostrar error diciendo que ya hay un alimento con ese nombre en la bd.
                            }
                        }
                        else
                        {
                            //Comprobar que los alimentos seleccionados en el combo box no se repitan. (No se como hacerlo)
                        }
                    }
                    else
                    {
                        //Mostrar error por pantalla de que el nombre del plato esta vacio. (error provider o messagebox).
                    }
                    ConexionBD.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionBD.CerrarConexion();
            }
        }

    }
}
