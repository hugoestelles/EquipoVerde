using NutriWise.Clases;
using System;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class Donativos : UserControl
    {
        public Donativos()
        {
            InitializeComponent();
        }

        private void btnDonacion_Click(object sender, System.EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            Usuario user = Usuario.UsuarioActual;
            //// Falta el nombre del usuario 
            Donativo donacion = new Donativo((double)nudCantidad.Value, fecha, user.Nombre, user.Id);

            donacion.Donar();
        }
    }
}
