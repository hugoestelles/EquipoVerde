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
            int[] indices = new int[4] { cmbIngre1.SelectedIndex, cmbIngre2.SelectedIndex, cmbIngre3.SelectedIndex, cmbIngre4.SelectedIndex };
            List<Alimentos> list = new List<Alimentos>();
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
                                    list.Add(a1);
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
                                    list.Add(a2);
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
                                    list.Add(a3);
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
                                    list.Add(a4);
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
                            if(Utiles.ComprobarComboBoxes(cmbIngre1.SelectedIndex, cmbIngre2.SelectedIndex, cmbIngre3.SelectedIndex, cmbIngre4.SelectedIndex))
                            {
                                for (int i = 0; i < comp.Length; i++)
                                {
                                    if (comp[i] == false) {
                                        Alimentos alim = Alimentos.ObtenerDatosAlimento(indices[i]);
                                        list.Add(alim);
                                            }
                                }
                            }
                            else
                            {
                                //Mostrar error diciendo que alguno de los alimentos se repite.
                            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionBD.Conexion != null) ConexionBD.AbrirConexion();

                if (Dietas.CantPlatosEspecificos(cmbAdminObj.SelectedIndex, cmbAdminInto.SelectedIndex))
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
            if (txtNomDieta.Text == "" || cmbAdminObj.SelectedIndex == -1 || cmbAdminInto.SelectedIndex == -1)
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
                    int objetivo = cmbAdminObj.SelectedIndex;
                    string tipo = cmbAdminInto.SelectedItem.ToString();
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
            string consulta = string.Format("SELECT nombre FROM platos WHERE objetivo={0} AND intolerancia={1};", cmbAdminObj.SelectedIndex, cmbAdminInto.SelectedIndex);
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
    }
}
