using NutriWise.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            btnAyuda.BackColor = Color.Ivory;
        }

        bool dieta = false;
        bool perfil = false;
        bool valoraciones = false;
        bool donativos = false;
        bool lista = false;
        bool videos = false;
        bool ayuda = true;
        bool mantenimiento = false;

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cambioColor()
        {
            if (this.BackColor == Color.Ivory)
            {
                if (dieta)
                {
                    LimpiarBotones();
                    btnDieta.BackColor = Color.Ivory;
                }
                if (valoraciones)
                {
                    LimpiarBotones();
                    btnValoraciones.BackColor = Color.Ivory;
                }
                if (perfil)
                {
                    LimpiarBotones();
                    btnPerfil.BackColor = Color.Ivory;
                }
                if (donativos)
                {
                    LimpiarBotones();
                    btnDonativos.BackColor = Color.Ivory;
                }
                if (lista)
                {
                    LimpiarBotones();
                    btnListaCompra.BackColor = Color.Ivory;
                }
                if (videos)
                {
                    LimpiarBotones();
                    btnVideos.BackColor = Color.Ivory;
                }
                if (ayuda)
                {
                    LimpiarBotones();
                    btnAyuda.BackColor = Color.Ivory;
                }
                if (mantenimiento)
                {
                    LimpiarBotones();
                    btnMantenimiento.BackColor = Color.Ivory;
                }
            }

            if (this.BackColor == Color.DarkSeaGreen)
            {
                if (perfil)
                {
                    LimpiarBotones();
                    btnPerfil.BackColor = Color.DarkSeaGreen;
                }
                if (dieta)
                {
                    LimpiarBotones();
                    btnDieta.BackColor = Color.DarkSeaGreen;
                }
                if (valoraciones)
                {
                    LimpiarBotones();
                    btnValoraciones.BackColor = Color.DarkSeaGreen;
                }
                if (donativos)
                {
                    LimpiarBotones();
                    btnDonativos.BackColor = Color.DarkSeaGreen;
                }
                if (lista)
                {
                    LimpiarBotones();
                    btnListaCompra.BackColor = Color.DarkSeaGreen;
                }
                if (videos)
                {
                    LimpiarBotones();
                    btnVideos.BackColor = Color.DarkSeaGreen;
                }
                if (ayuda)
                {
                    LimpiarBotones();
                    btnAyuda.BackColor = Color.DarkSeaGreen;
                }
                if (mantenimiento)
                {
                    LimpiarBotones();
                    btnMantenimiento.BackColor = Color.DarkSeaGreen;
                }
            }
            perfil1.CambioColorPerdfil();
            videos1.CambioColor();
        }
        private void pctAjustes_Click_1(object sender, EventArgs e)
        {
            if (pnlAjustes.Visible)
            {
                pnlAjustes.Visible = false;
                return;
            }
            else { pnlAjustes.Visible = true; }
        }

        private void btnDonativos_Click(object sender, EventArgs e)
        {
            if (!donativos)
            {
                CambiarMenu();
                donativos = true;
                donativos1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Donativos");
            }
        }

        private void btnDieta_Click(object sender, EventArgs e)
        {
            if (!donativos)
            {
                CambiarMenu();
                dieta = true;
                dieta1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Dieta");

                try
                {
                    if (ConexionBD.Conexion != null)
                    {
                        ConexionBD.CerrarConexion();
                        ConexionBD.AbrirConexion();
                        //dieta1.CargarDataGrid();
                        //string ruta = Utiles.SeleccionarPDF(Usuario.UsuarioActual);
                        //Utiles.EnviarDieta(Usuario.UsuarioActual,ruta);
                        ConexionBD.CerrarConexion();
                    }
                    else MessageBox.Show("No existe conexión a la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConexionBD.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConexionBD.CerrarConexion();
                }
                finally
                {
                    ConexionBD.CerrarConexion();
                }
            }
        }

        private void btnListaCompra_Click(object sender, EventArgs e)
        {
            if (!lista)
            {
                CambiarMenu();
                lista = true;
                listaCompra1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Lista");
                try
                {
                    if (ConexionBD.Conexion != null)
                    {
                        ConexionBD.CerrarConexion();
                        ConexionBD.AbrirConexion();
                        listaCompra1.CargarLista();

                        ConexionBD.CerrarConexion();
                    }
                    else MessageBox.Show("No existe conexión a la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConexionBD.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConexionBD.CerrarConexion();
                }
                finally
                {
                    ConexionBD.CerrarConexion();
                }
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (!perfil)
            {
                CambiarMenu();
                perfil = true;
                perfil1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Perfil");
            }
        }

        private void btnValoraciones_Click(object sender, EventArgs e)
        {
            if (!valoraciones)
            {
                CambiarMenu();
                valoraciones = true;
                valoraciones1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Valoraciones");
            }
        }
        private void btnVideos_Click(object sender, EventArgs e)
        {
            if (!videos)
            {
                CambiarMenu();
                videos = true;
                videos1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Videos");
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            if (!ayuda)
            {
                CambiarMenu();
                ayuda = true;
                ayuda1.Visible = true;
                cambioColor();
                btnTitulo.Text = ("Ayuda");
            }
        }

        private void pctClaro_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Ivory;
            perfil1.BackColor = Color.Ivory;
            dieta1.BackColor = Color.Ivory;
            valoraciones1.BackColor = Color.Ivory;
            donativos1.BackColor = Color.Ivory;
            listaCompra1.BackColor = Color.Ivory;
            ayuda1.BackColor = Color.Ivory;
            videos1.BackColor = Color.Ivory;
            cambioColor();
        }

        private void pctOscuro_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSeaGreen;
            perfil1.BackColor = Color.DarkSeaGreen;
            dieta1.BackColor = Color.DarkSeaGreen;
            valoraciones1.BackColor = Color.DarkSeaGreen;
            donativos1.BackColor = Color.DarkSeaGreen;
            listaCompra1.BackColor = Color.DarkSeaGreen;
            ayuda1.BackColor = Color.DarkSeaGreen;
            videos1.BackColor = Color.DarkSeaGreen;
            cambioColor();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            CambiarOpcion();
            mantenimiento = true;
            cambioColor();

            Admin form5 = new Admin();

            form5.ShowDialog();
        }

        private void CambiarOpcion()
        {
            dieta = false;
            perfil = false;
            valoraciones = false;
            donativos = false;
            lista = false;
            videos = false;
            ayuda = false;
            mantenimiento = false;
        }
        private void CambiarMenu()
        {
            dieta1.Visible = false;
            perfil1.Visible = false;
            valoraciones1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = false;
            ayuda1.Visible = false;
            videos1.Visible = false;
            CambiarOpcion();
        }

        private void LimpiarBotones()
        {
            btnValoraciones.BackColor = Color.PaleGreen;
            btnDieta.BackColor = Color.PaleGreen;
            btnPerfil.BackColor = Color.PaleGreen;
            btnDonativos.BackColor = Color.PaleGreen;
            btnListaCompra.BackColor = Color.PaleGreen;
            btnVideos.BackColor = Color.PaleGreen;
            btnAyuda.BackColor = Color.PaleGreen;
            btnMantenimiento.BackColor = Color.PaleGreen;
        }

    }
}