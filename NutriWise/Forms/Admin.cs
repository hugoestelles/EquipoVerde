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

        #region Validaciones
        private void ValidarAgregarDieta()
        {
            errorDatos.Clear();

            if (txtNomDieta.Text == "")
            {
                errorDatos.SetError(txtNomDieta, "Ingresa nombre");
            }

            if (cmbAdminDietObj.SelectedIndex == -1)
            {
                errorDatos.SetError(cmbAdminDietObj, "Selecciona objetivo");
            }

            if (cmbAdminDietInto.SelectedIndex == -1)
            {
                errorDatos.SetError(cmbAdminDietInto, "Selecciona intolerancia");
            }
        }
        #endregion

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
            grbIngredientes.Visible = false;
            grbEliminarUsu.Visible = false;
            try
            {
                if(ConexionBD.Conexion != null)
                {
                    ConexionBD.AbrirConexion();
                    CargarAlimentos();
                    ConexionBD.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No hay platos suficientes para crear una dieta.", "Platos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ConexionBD.CerrarConexion();
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

        private void mnuDietaAgregar_Click(object sender, EventArgs e)
        {
            errorDatos.Clear();
            grbPlato.Visible = false;
            grbDieta.Visible = true;
            grbDieta.BringToFront();
            grbEliminarUsu.Visible = false;
            grbIngredientes.Visible = false;

        }
        private void mnuEliminarUsuario_Click(object sender, EventArgs e)
        {
            grbPlato.Visible = false;
            grbDieta.Visible = false;
            grbIngredientes.Visible=false;
            grbEliminarUsu.Visible = true;
            grbEliminarUsu.BringToFront();
        }

        private void timerAdmin_Tick(object sender, EventArgs e)
        {
           lblAdminReloj.Text = DateTime.Now.ToString("hh:mm:ss");
            lblAdminFecha.Text = DateTime.Now.ToString("d");
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
            lblElimNombreR2.Text = "(Nombre)";
            lblElimApe2.Text = "(Apellidos)";
            lblElimCorreo2.Text = "(Correo)";
            txtEliminarUsu.Clear();
            grbEliminarUsu.Visible = false;
        }

        private void btnDietaVolver_Click(object sender, EventArgs e)
        {
            grbDieta.Visible = false;
        }

        private void btnPlatoVolver_Click(object sender, EventArgs e)
        {
            grbPlato.Visible = false;
            ResetPlatos();
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

            string[] nombres = new string[4] { cmbIngre1.Text, cmbIngre2.Text, cmbIngre3.Text, cmbIngre4.Text };
            List<Alimentos> list = new List<Alimentos>();
            try
            {
                if (ConexionBD.Conexion != null)
                {
                    ConexionBD.AbrirConexion();

                    ConexionBD.CerrarConexion();
                }
                else
                {

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionBD.Conexion != null) ConexionBD.AbrirConexion();

                if (Dietas.CantPlatosEspecificos(cmbAdminDietObj.SelectedIndex, cmbAdminDietInto.SelectedIndex))
                {
                    EliminarCargaPlatos();
                    CargarPlatos();
                }
                else MessageBox.Show("No hay platos suficientes para crear una dieta.", "Platos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConexionBD.CerrarConexion();
            }
            catch (Exception) { MessageBox.Show("No se ha podido establecer conexión.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { ConexionBD.CerrarConexion(); }
        }

        private void btnDietaAceptar_Click(object sender, EventArgs e)
        {
            ValidarAgregarDieta();
            if (txtNomDieta.Text == "" || cmbAdminDietObj.SelectedIndex == -1 || cmbAdminDietInto.SelectedIndex == -1)
            {
                MessageBox.Show("Debes ingresar un nombre y seleccionar un tipo de objetivo y de intolerancia.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ComboBox[] platos = new ComboBox[] { cmbPlato1, cmbPlato2, cmbPlato3, cmbPlato4, cmbPlato5, cmbPlato6, cmbPlato7, cmbPlato8, cmbPlato9, cmbPlato10, cmbPlato11, cmbPlato12, cmbPlato13, cmbPlato14, cmbPlato15, cmbPlato16, cmbPlato17, cmbPlato18, cmbPlato19, cmbPlato20, cmbPlato21 };
                int cantPlatos = Dietas.CantPlatosSeleccionados(platos);

                if (cantPlatos == 0) MessageBox.Show("Debes ingresar como mínimo 1 plato.", "Ningún plato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string nombre = txtNomDieta.Text;
                    int objetivo = cmbAdminDietObj.SelectedIndex;
                    string tipo = cmbAdminDietInto.SelectedItem.ToString();
                    int cantIngredientes = -1;

                    try
                    {
                        if (ConexionBD.Conexion != null) ConexionBD.AbrirConexion();
                        List<int> idPlatos = Dietas.ObtenerIdPlatos(platos);
                        cantIngredientes = Dietas.CantAlimentosPlatos(idPlatos);
                        ConexionBD.CerrarConexion();
                    }
                    catch (Exception) { MessageBox.Show("No se ha podido establecer conexión.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally { ConexionBD.CerrarConexion(); }

                    Dietas dieta = new Dietas(nombre, objetivo, tipo, cantPlatos, cantIngredientes);
                    if (dieta.PlatosRepetidos(platos)) MessageBox.Show("No se puede repetir ningún plato.", "Platos repetidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        try
                        {
                            if (ConexionBD.Conexion != null) ConexionBD.AbrirConexion();
                            dieta.AgregarDieta();
                            dieta.AnyadirPlatos(platos);
                            ConexionBD.CerrarConexion();
                        }
                        catch (Exception) { MessageBox.Show("No se ha podido establecer conexión.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally { ConexionBD.CerrarConexion(); }

                        MessageBox.Show("La dieta ha sido agregada.", "Dieta agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EliminarCargaPlatos();
                    }
                }
            }
        }

        private void CargarPlatos()
        {
            string consulta = string.Format("SELECT nombre FROM platos WHERE objetivo={0} AND intolerancia={1};", cmbAdminDietObj.SelectedIndex, cmbAdminDietInto.SelectedIndex);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);

            try
            {
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string nombrePlato = reader.GetString(0);
                    cmbPlato1.Items.Add(nombrePlato);
                    cmbPlato2.Items.Add(nombrePlato);
                    cmbPlato3.Items.Add(nombrePlato);
                    cmbPlato4.Items.Add(nombrePlato);
                    cmbPlato5.Items.Add(nombrePlato);
                    cmbPlato6.Items.Add(nombrePlato);
                    cmbPlato7.Items.Add(nombrePlato);
                    cmbPlato8.Items.Add(nombrePlato);
                    cmbPlato9.Items.Add(nombrePlato);
                    cmbPlato10.Items.Add(nombrePlato);
                    cmbPlato11.Items.Add(nombrePlato);
                    cmbPlato12.Items.Add(nombrePlato);
                    cmbPlato13.Items.Add(nombrePlato);
                    cmbPlato14.Items.Add(nombrePlato);
                    cmbPlato15.Items.Add(nombrePlato);
                    cmbPlato16.Items.Add(nombrePlato);
                    cmbPlato17.Items.Add(nombrePlato);
                    cmbPlato18.Items.Add(nombrePlato);
                    cmbPlato19.Items.Add(nombrePlato);
                    cmbPlato20.Items.Add(nombrePlato);
                    cmbPlato21.Items.Add(nombrePlato);
                }
                reader.Close();
            }
            catch (Exception) { MessageBox.Show("No se ha podido establecer conexión.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { ConexionBD.CerrarConexion(); }
        }

        private void EliminarCargaPlatos()
        {
            ComboBox[] comboBoxes = new ComboBox[] { cmbPlato1, cmbPlato2, cmbPlato3, cmbPlato4, cmbPlato5, cmbPlato6, cmbPlato7, cmbPlato8, cmbPlato9, cmbPlato10, cmbPlato11, cmbPlato12, cmbPlato13, cmbPlato14, cmbPlato15, cmbPlato16, cmbPlato17, cmbPlato18, cmbPlato19, cmbPlato20, cmbPlato21 };
            foreach (ComboBox cmb in comboBoxes)
            {
                cmb.Items.Clear();
                cmb.Text = "";
            }
        }
        private void CargarAlimentos()
        {
            List<Alimentos> list = Alimentos.ListarAlimentos();
            for (int i = 0; i < list.Count; i++)
            {
                cmbIngre1.Items.Add(list[i].Nombre);
                cmbIngre2.Items.Add(list[i].Nombre);
                cmbIngre3.Items.Add(list[i].Nombre);
                cmbIngre4.Items.Add(list[i].Nombre);
            }
        }

        private void btnPlatoReset_Click(object sender, EventArgs e)
        {
            ResetPlatos();
        }
        private void ResetPlatos()
        {
            /*txtNomPlato.Text = string.Empty;
            cmbAdminPlatosInto.SelectedIndex = -1;
            cmbAdminPlatosObj.SelectedIndex = -1;
            cmbAdminPlatosTipo.SelectedIndex = -1;
            cmbIngre1.SelectedIndex = -1;
            cmbIngre2.SelectedIndex = -1;
            cmbIngre3.SelectedIndex = -1;
            cmbIngre4.SelectedIndex = -1;
            txtAgregarIngre1.Text = string.Empty;
            txtAgregarIngre2.Text = string.Empty;
            txtAgregarIngre3.Text = string.Empty;
            txtAgregarIngre4.Text = string.Empty;
            txtValorN1.Text = string.Empty;
            txtValorN2.Text = string.Empty;
            txtValorN3.Text = string.Empty;
            txtValorN4.Text = string.Empty;
            nudCantidadN1.Value= 0;
            nudCantidadN2.Value= 0;
            nudCantidadN3.Value= 0;
            nudCantidadN4.Value= 0;*/

        }


        private void btnAceptarIngre_Click(object sender, EventArgs e)
        {
            string[] nombres = new string[4] {txtNomIngre1.Text, txtNomIngre2.Text, txtNomIngre3.Text, txtNomIngre4.Text};
            decimal[] valoresNutri = new decimal[4] {nudVN1.Value, nudVN2.Value, nudVN3.Value, nudVN4.Value };
            try
            {
                if (ConexionBD.Conexion != null)
                {
                    ConexionBD.AbrirConexion();
                    for (int i = 0; i < nombres.Length; i++)
                    {
                        if (nombres[i] != "" && valoresNutri[i] != 0) 
                        {
                            
                            Alimentos a = new Alimentos(nombres[i], (double)valoresNutri[i]);
                            if (!a.ComprobarExistencia())
                            { 
                                a.AgregarAlimento();
                            }
                            else
                            {
                                MessageBox.Show("Ya hay un alimento con ese nombre en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } 
                    }
                    ConexionBD.CerrarConexion();
                }
                else
                {

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

        private void btnRestIngre_Click(object sender, EventArgs e)
        {
            ResetIngredientes();
        }

        private void btnVolverIngre_Click(object sender, EventArgs e)
        {
            grbIngredientes.Visible = false;
            ResetIngredientes();
        }
        private void ResetIngredientes()
        {
            txtNomIngre1.Text = String.Empty;
            txtNomIngre2.Text = String.Empty;
            txtNomIngre3.Text = String.Empty;
            txtNomIngre4.Text = String.Empty;

            nudVN1.Value= 0;
            nudVN2.Value= 0;
            nudVN3.Value= 0;
            nudVN4.Value= 0;
        }

        private void mnuAgregarIngrediente_Click(object sender, EventArgs e)
        {
            grbDieta.Visible = false;
            grbEliminarUsu.Visible = false;
            grbPlato.Visible = false;
            grbIngredientes.Visible = true;
            grbIngredientes.BringToFront();
        }
    }
}
