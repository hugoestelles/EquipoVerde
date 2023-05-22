using NutriWise.Clases;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class ListaCompra : UserControl
    {
        public ListaCompra()
        {
            InitializeComponent();
        }

        public void CargarLista()
        {
            lblListaCompra.Text = Utiles.FormatearListaCompra(Usuario.DietaActual);
        }

        private void btnEnviarListaCompra_Click(object sender, System.EventArgs e)
        {
            Utiles.EnviarListaCompra(Usuario.UsuarioActual, Utiles.FormatearListaCompraCorreo(Usuario.DietaActual));
            MessageBox.Show("Correo enviado con exito!", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
