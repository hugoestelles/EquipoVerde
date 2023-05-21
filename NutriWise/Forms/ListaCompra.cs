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
    }
}
