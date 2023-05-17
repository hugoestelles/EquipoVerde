using MySql.Data.MySqlClient;
using NutriWise.Clases;
using System;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class Valoraciones : UserControl
    {
        public Valoraciones()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, System.EventArgs e)
        {
            ConexionBD.AbrirConexion();
            DateTime fecha = DateTime.Now;
            Valoracion valoracion = new Valoracion((int)nupEstrellas.Value, fecha, txtValoracion.Text);
            int resultado = valoracion.AgregarValoracion();
            if (resultado == 1)
            {
                MessageBox.Show("Valoración enviada con éxito", "Valoración enviada");
                txtValoracion.Text = "";
                nupEstrellas.Value = 0;
            }
            else
            {
                MessageBox.Show("Error al enviar la valoración", "Error");
            }
            ConexionBD.CerrarConexion();
        }
    }
}
