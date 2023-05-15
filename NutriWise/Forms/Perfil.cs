using System.Windows.Forms;

namespace NutriWise
{
    public partial class Perfil : UserControl
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            textBox1.Enabled = true;
            //textBox1.BorderStyle= FixedSingle;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            textBox1.Enabled = false;
        }
    }
}
