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
            int estrella = 0;
            try
            {
                using (MySqlConnection conect = ConexionBD.Conexion)
                {
                    DateTime fecha = DateTime.Now;
                    Valoracion valoracion = new Valoracion((int)estrella, fecha, txtValoracion.Text);
                    int resultado = valoracion.AgregarValoracion();
                    if (resultado == 1)
                    {
                        MessageBox.Show("Valoración enviada con éxito", "Valoración enviada");
                        txtValoracion.Text = "";
                        estrella = 0;
                        Estrella0();
                    }
                    else
                    {
                        MessageBox.Show("Error al enviar la valoración", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        int estrella = 0;
        private void pctStar1_MouseEnter(object sender, System.EventArgs e)
        {
            Estrella1();
        }

        private void pctStar1_MouseLeave(object sender, System.EventArgs e)
        {
            MantenerEstrella();
        }

        private void pctStar2_MouseEnter(object sender, System.EventArgs e)
        {
            Estrella2();
        }

        private void pctStar2_MouseLeave(object sender, System.EventArgs e)
        {
            MantenerEstrella();
        }

        private void pctStar3_MouseEnter(object sender, System.EventArgs e)
        {
            Estrella3();
        }

        private void pctStar3_MouseLeave(object sender, System.EventArgs e)
        {
            MantenerEstrella();
        }

        private void pctStar4_MouseEnter(object sender, System.EventArgs e)
        {
            Estrella4();
        }

        private void pctStar4_MouseLeave(object sender, System.EventArgs e)
        {
            MantenerEstrella();
        }

        private void pctStar5_MouseEnter(object sender, System.EventArgs e)
        {
            Estrella5();
        }

        private void pctStar5_MouseLeave(object sender, System.EventArgs e)
        {
            MantenerEstrella();
        }
        private void Estrella0()
        {
            pctStar1.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar2.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar3.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar4.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar5.Image = NutriWise.Properties.Resources.Noestrella;
        }
        private void Estrella1()
        {
            pctStar1.Image = NutriWise.Properties.Resources.Estrella;
            pctStar2.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar3.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar4.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar5.Image = NutriWise.Properties.Resources.Noestrella;
        }
        private void Estrella2()
        {
            pctStar1.Image = NutriWise.Properties.Resources.Estrella;
            pctStar2.Image = NutriWise.Properties.Resources.Estrella;
            pctStar3.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar4.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar5.Image = NutriWise.Properties.Resources.Noestrella;
        }
        private void Estrella3()
        {
            pctStar1.Image = NutriWise.Properties.Resources.Estrella;
            pctStar2.Image = NutriWise.Properties.Resources.Estrella;
            pctStar3.Image = NutriWise.Properties.Resources.Estrella;
            pctStar4.Image = NutriWise.Properties.Resources.Noestrella;
            pctStar5.Image = NutriWise.Properties.Resources.Noestrella;
        }
        private void Estrella4()
        {
            pctStar1.Image = NutriWise.Properties.Resources.Estrella;
            pctStar2.Image = NutriWise.Properties.Resources.Estrella;
            pctStar3.Image = NutriWise.Properties.Resources.Estrella;
            pctStar4.Image = NutriWise.Properties.Resources.Estrella;
            pctStar5.Image = NutriWise.Properties.Resources.Noestrella;
        }
        private void Estrella5()
        {
            pctStar1.Image = NutriWise.Properties.Resources.Estrella;
            pctStar2.Image = NutriWise.Properties.Resources.Estrella;
            pctStar3.Image = NutriWise.Properties.Resources.Estrella;
            pctStar4.Image = NutriWise.Properties.Resources.Estrella;
            pctStar5.Image = NutriWise.Properties.Resources.Estrella;
        }

        private void pctStar1_Click(object sender, System.EventArgs e)
        {
            estrella = 1;
        }

        private void pctStar2_Click(object sender, System.EventArgs e)
        {
            estrella = 2;
        }

        private void pctStar3_Click(object sender, System.EventArgs e)
        {
            estrella = 3;
        }

        private void pctStar4_Click(object sender, System.EventArgs e)
        {
            estrella = 4;
        }

        private void pctStar5_Click(object sender, System.EventArgs e)
        {
            estrella = 5;
        }
        private void MantenerEstrella()
        {
            switch (estrella)
            {
                case 1:
                    Estrella1();
                    break;
                case 2:
                    Estrella2();
                    break;
                case 3:
                    Estrella3();
                    break;
                case 4:
                    Estrella4();
                    break;
                case 5:
                    Estrella5();
                    break;
                default:
                    Estrella0();
                    break;
            }
        }


    }






}

