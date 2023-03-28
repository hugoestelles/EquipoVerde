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
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void pictureBox7_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            int radius = 20; // ajusta este valor para cambiar el radio de los bordes redondeados
            gPath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            gPath.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            gPath.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            gPath.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            gPath.CloseFigure();
            pictureBox1.Region = new Region(gPath);
        }

    }
}
