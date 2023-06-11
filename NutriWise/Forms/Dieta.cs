﻿using NutriWise.Clases;
using System.Collections.Generic;
using System.Windows.Forms;
using NutriWise.RecursosLocalizables;
using System.Globalization;
using System.Threading;

namespace NutriWise
{
    public partial class Dieta : UserControl
    {
        public Dieta()
        {
            InitializeComponent();
        }
        public void CargarDataGrid()
        {
            Dietas d1 = Usuario.DietaActual;
            string[] dias = new string[7] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            dgvDieta.Rows.Clear();

            // Crear una lista de platos clasificados por tipo
            List<Platos>[] comidas = new List<Platos>[3];
            for (int k = 0; k < 3; k++)
            {
                comidas[k] = new List<Platos>();
            }

            // Clasificar los platos según su tipo
            foreach (Platos plato in d1.Platos)
            {
                if (plato.Tipo == 0)
                    comidas[0].Add(plato);
                else if (plato.Tipo == 1)
                    comidas[1].Add(plato);
                else
                    comidas[2].Add(plato);
            }

            // Añadir los platos al DataGridView
            for (int i = 0; i < dias.Length; i++)
            {
                List<Platos> platosDia = new List<Platos>();

                // Añadir un plato de cada tipo al día

                platosDia.Add(comidas[0][i]);
                platosDia.Add(comidas[1][i]);
                platosDia.Add(comidas[2][i]);

                dgvDieta.Rows.Add(dias[i], platosDia[0].Nombre, platosDia[1].Nombre, platosDia[2].Nombre);
            }
            dgvDieta.ClearSelection();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if(Usuario.DietaActual.Id == 0 || Usuario.DietaActual.Id > 15)
            {
                MessageBox.Show("Lo sentimos, su dieta aun no está disponible para mandar por correo :(\n Intentelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Utiles.EnviarDieta(Usuario.UsuarioActual, Utiles.SeleccionarPDF(Usuario.UsuarioActual));
                MessageBox.Show("Dieta enviada por correo con exito!","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void ActualizarNombre()
        {
            lblNombreDieta.Text = Usuario.DietaActual.Nombre;
        }

        public void EstablecerCultura(string cultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            AplicarIdioma();

        }
        private void AplicarIdioma()
        {
            lblNombreDieta.Text = StringRecursos.descripcion;
            btnEnviarDieta.Text = StringRecursos.enviar;

        }
    }
}
