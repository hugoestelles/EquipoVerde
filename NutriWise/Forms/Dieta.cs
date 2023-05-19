using NutriWise.Clases;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class Dieta : UserControl
    {
        public Dieta()
        {
            InitializeComponent();
            ConexionBD.CerrarConexion();
            ConexionBD.AbrirConexion();
            Usuario u1 = Usuario.UsuarioActual;
            int id = Usuario.BuscarDieta(u1.Objetivo, u1.Intolerancia);
            MessageBox.Show(id.ToString());
            Dietas d1 = new Dietas();
            d1.ObtenerDatosDieta(id);
            MessageBox.Show(d1.Nombre);
            CargarDataGrid(d1);
            ConexionBD.CerrarConexion();
        }
        private void CargarDataGrid(Dietas d1)
        {
            string[] dias = new string[7] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            dgvDieta.Rows.Clear();
            List<Platos> comidas = new List<Platos>();
            for (int i = 0; i < d1.Platos.Count; i++)
            {
                if (d1.Platos[i].Tipo == 0) comidas.Add(d1.Platos[i]);
                else if (d1.Platos[i].Tipo == 1) comidas.Add(d1.Platos[i]);
                else comidas.Add(d1.Platos[i]);
                dgvDieta.Rows.Add(dias[i], comidas[0].Nombre, comidas[1].Nombre, comidas[2].Nombre);
            }
        }
    }
}
