using NutriWise.Clases;
using System.Windows.Forms;

namespace NutriWise
{
    public partial class Perfil : UserControl
    {
        public Perfil()
        {
            InitializeComponent();
        }


        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            txtNombre.Enabled = true;
            txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtApellido.Enabled = true;
            txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMail.Enabled = true;
            txtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            nudAltura.Enabled = true;
            nudAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            nudPeso.Enabled = true;
            nudPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cmbIntolerancias.Enabled = true;
            cmbIntolerancias.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            nudActividad.Enabled = true;
            nudActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cmbObjetivo.Enabled = true;
            cmbObjetivo.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            btnAceptar.Visible = true;
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {

            txtNombre.Enabled = false;
            txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtApellido.Enabled = false;
            txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtMail.Enabled = false;
            txtMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            nudAltura.Enabled = false;
            nudAltura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            nudPeso.Enabled = false;
            nudPeso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            cmbIntolerancias.Enabled = false;
            cmbIntolerancias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            nudActividad.Enabled = false;
            nudActividad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            cmbObjetivo.Enabled = false;
            cmbObjetivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAceptar.Visible = false;
        }
        public void CambioColorPerdfil()
        {
            txtNombre.BackColor = this.BackColor;
            txtApellido.BackColor = this.BackColor;
            txtMail.BackColor = this.BackColor;
            nudAltura.BackColor = this.BackColor;
            nudPeso.BackColor = this.BackColor;
            cmbIntolerancias.BackColor = this.BackColor;
            nudActividad.BackColor = this.BackColor;
            cmbObjetivo.BackColor = this.BackColor;
        }

        public void ActualizarDatosUsuario()
        {
            Usuario us = Usuario.UsuarioActual;
            txtMail.Text = us.Correo;
            txtNombre.Text = us.Nombre;
            txtApellido.Text = us.Apellidos;
            nudAltura.Value = us.Altura;
            nudPeso.Value = us.Peso;
            cmbIntolerancias.SelectedIndex = us.Intolerancia;
            nudActividad.Value = us.Actividad;
            cmbObjetivo.SelectedIndex = us.Objetivo;
        }
    }
}
