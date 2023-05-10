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

        bool boton1 = false;
        bool boton2 = false;
        bool boton3 = false;

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Ivory;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (!boton2)
            button3.BackColor = Color.PaleGreen;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Ivory;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (!boton1)
            pictureBox5.BackColor = Color.PaleGreen;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!boton1)
            {
                boton1 = true;
                boton2 = false;
                boton3 = false;
                cambioColor();
                dieta1.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!boton2)
            {
                boton2 = true;
                boton1 = false;
                boton3 = false;
                cambioColor();
                dieta1.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            boton1 = false;
            boton2 = false;
            boton3 = true;
            cambioColor();
            perfil1.BringToFront();
        }

        void cambioColor()
        {
            if (this.BackColor == Color.Ivory)
            {
                if (boton1)
                {
                    button3.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.Ivory;
                    button1.BackColor = Color.PaleGreen;
                }
                if (boton2)
                {
                    button3.BackColor = Color.Ivory;
                    pictureBox5.BackColor = Color.PaleGreen;
                    button1.BackColor = Color.PaleGreen;
                }
                if (boton3)
                {
                    button3.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    button1.BackColor = Color.Ivory;
                }
            }
            
            if (this.BackColor == Color.FromArgb(50, 50, 50))
            {
                if (boton1)
                {
                    button3.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.FromArgb(50, 50, 50);
                    button1.BackColor = Color.PaleGreen;
                }
                if (boton2)
                {
                    button3.BackColor = Color.FromArgb(50, 50, 50);
                    pictureBox5.BackColor = Color.PaleGreen;
                    button1.BackColor = Color.PaleGreen;
                }
                if (boton3)
                {
                    button3.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    button1.BackColor = Color.FromArgb(50, 50, 50);
                }
            }

            }

        private void button4_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(50, 50, 50);
            perfil1.BackColor = Color.FromArgb(50, 50, 50);
            dieta1.BackColor = Color.FromArgb(50, 50, 50);
            cambioColor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Ivory;
            perfil1.BackColor = Color.Ivory;
            dieta1.BackColor = Color.Ivory;
            cambioColor();
        }

    }
}
