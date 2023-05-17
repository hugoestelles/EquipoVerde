using NutriWise.RecursosLocalizables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class Menu : Form
    {
        Perfil perfilControl = new Perfil();
        
        public Menu()
        {
            InitializeComponent();
            Menu menuForm = new Menu(perfilControl);
            menuForm.Show();

        }

        bool dieta = false;
        bool perfil = false;
        bool valoraciones = false;
        bool donativos = false;
        bool lista = false;
        bool video = false;
        bool ayuda = false;

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValoraciones_Click(object sender, EventArgs e)
        {

            perfil = false;
            dieta = false;
            valoraciones = true;
            donativos = false;
            lista = false;
            video = false;
            ayuda = false;
            cambioColor();
            //dieta1.BringToFront();
            valoraciones1.Visible = true;
            perfil1.Visible = false;
            dieta1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = false;
            ayuda1.Visible = false;

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            perfil = true;
            dieta = false;
            valoraciones = false;
            donativos = false;
            lista = false;
            video = false;
            ayuda = false;
            cambioColor();
            //perfil1.BringToFront();
            dieta1.Visible = false;
            perfil1.Visible = true;
            valoraciones1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = false;
            ayuda1.Visible = false;
        }

        void cambioColor()
        {
            if (this.BackColor == Color.Ivory)
            {
                if (dieta)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.Ivory;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;

                }
                if (valoraciones)
                {
                    btnValoraciones.BackColor = Color.Ivory;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (perfil)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.Ivory;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (donativos)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.Ivory;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (lista)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.Ivory;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (video)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.Ivory;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (ayuda)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.Ivory;
                }
            }

            if (this.BackColor == Color.DarkSeaGreen)
            {
                if (perfil)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.DarkSeaGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (dieta)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.DarkSeaGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (valoraciones)
                {
                    btnValoraciones.BackColor = Color.DarkSeaGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (donativos)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.DarkSeaGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (lista)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.DarkSeaGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (video)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.DarkSeaGreen;
                    btnAyuda.BackColor = Color.PaleGreen;
                }
                if (ayuda)
                {
                    btnValoraciones.BackColor = Color.PaleGreen;
                    btnDieta.BackColor = Color.PaleGreen;
                    btnPerfil.BackColor = Color.PaleGreen;
                    btnDonativos.BackColor = Color.PaleGreen;
                    btnListaCompra.BackColor = Color.PaleGreen;
                    btnVideos.BackColor = Color.PaleGreen;
                    btnAyuda.BackColor = Color.DarkSeaGreen;
                }
            }

        }
        private void pctAjustes_Click_1(object sender, EventArgs e)
        {
            if (pnlAjustes.Visible == true)
            {
                pnlAjustes.Visible = false;
                pnlAjustes.BringToFront();
                pctAjustes.BringToFront();
                pctCerrar.BringToFront();
                return;
            }
            if (pnlAjustes.Visible == false) { pnlAjustes.Visible = true; }
        }

        private void btnClaro_Click_1(object sender, EventArgs e)
        {
            this.BackColor = Color.Ivory;
            perfil1.BackColor = Color.Ivory;
            dieta1.BackColor = Color.Ivory;
            valoraciones1.BackColor = Color.Ivory;
            donativos1.BackColor = Color.Ivory;
            listaCompra1.BackColor = Color.Ivory;
            ayuda1.BackColor = Color.Ivory;
            cambioColor();
        }

        private void btnDonativos_Click(object sender, EventArgs e)
        {
            dieta = false;
            perfil = false;
            valoraciones = false;
            donativos = true;
            lista = false;
            video = false;
            ayuda = false;
            cambioColor();
            //dieta1.BringToFront();
            valoraciones1.Visible = false;
            perfil1.Visible = false;
            dieta1.Visible = false;
            donativos1.Visible = true;
            listaCompra1.Visible = false;
            ayuda1.Visible = false;
        }

        private void btnDieta_Click(object sender, EventArgs e)
        {
            dieta = true;
            perfil = false;
            valoraciones = false;
            donativos = false;
            lista = false;
            video = false;
            ayuda = false;
            cambioColor();
            dieta1.Visible = true;
            perfil1.Visible = false;
            valoraciones1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = false;
            ayuda1.Visible = false;
        }

        private void btnListaCompra_Click(object sender, EventArgs e)
        {
            dieta = false;
            perfil = false;
            valoraciones = false;
            donativos = false;
            lista = true;
            video = false;
            ayuda = false;
            cambioColor();
            dieta1.Visible = false;
            perfil1.Visible = false;
            valoraciones1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = true;
            ayuda1.Visible = false;
        }

        private void btnVideos_Click(object sender, EventArgs e)
        {
            dieta = false;
            perfil = false;
            valoraciones = false;
            donativos = false;
            lista = false;
            video = true;
            ayuda = false;
            cambioColor();
            dieta1.Visible = false;
            perfil1.Visible = false;
            valoraciones1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = false;
            ayuda1.Visible = false;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            dieta = false;
            perfil = false;
            valoraciones = false;
            donativos = false;
            lista = false;
            video = false;
            ayuda = true;
            cambioColor();
            dieta1.Visible = false;
            perfil1.Visible = false;
            valoraciones1.Visible = false;
            donativos1.Visible = false;
            listaCompra1.Visible = false;
            ayuda1.Visible = true;

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
            cambioColor();
        }

        private void pctIngles_Click(object sender, EventArgs e)
        {
            EstablecerCultura("EN-GB");
            ayuda1.EstablecerCultura("EN-GB");
            donativos1.EstablecerCultura("EN-GB");
            perfil1.EstablecerCultura("EN-GB");
            dieta1.EstablecerCultura("EN-GB");
            valoraciones1.EstablecerCultura("EN-GB");

        }

        public void AplicarIdioma()
        {
            btnDieta.Text = StringRecursos.Dieta;
            btnDonativos.Text = StringRecursos.Donativos;
            btnPerfil.Text = StringRecursos.Perfil;
            btnValoraciones.Text = StringRecursos.Valoraciones;
            btnListaCompra.Text = StringRecursos.ListaCompra;
            btnVideos.Text = StringRecursos.Videos;
            btnAyuda.Text = StringRecursos.Ayuda;
            
        }
        public void EstablecerCultura(string cultura)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();
            

        }

        private void pctEspalñol_Click(object sender, EventArgs e)
        {
            EstablecerCultura("ES-ES");
            ayuda1.EstablecerCultura("ES-ES");
            donativos1.EstablecerCultura("ES-ES");
            perfil1.EstablecerCultura("ES-ES");
            dieta1.EstablecerCultura("ES-ES");
            valoraciones1.EstablecerCultura("ES-ES");

        }

        public Menu(Perfil perfilControl)
        {
            InitializeComponent();
            this.perfilControl = perfilControl;
        }

        
        private void valoraciones1_Load(object sender, EventArgs e)
        {
            EstablecerCultura("EN-GB");
            perfil1.EstablecerCultura("EN-GB");
            ayuda1.EstablecerCultura("EN-GB");
            donativos1.EstablecerCultura("EN-GB");
            dieta1.EstablecerCultura("EN-GB");
            valoraciones1.EstablecerCultura("EN-GB");
        }
    }


}
