using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriWise.Forms
{
    public partial class Videos : UserControl
    {
        public Videos()
        {
            InitializeComponent();
        }

        public void CambioColor()
        {
            if (this.BackColor == Color.Ivory)
            {
                pctComidaLactosa.Image = NutriWise.Properties.Resources.ComidaSinLactosa;
                pctComidaVegana.Image = NutriWise.Properties.Resources.ComidaVegana;
                pctComidaSaludable.Image = NutriWise.Properties.Resources.ComidaSaludable;
            }
            if (this.BackColor == Color.DarkSeaGreen)
            {
                pctComidaLactosa.Image = NutriWise.Properties.Resources.ComidaSinLactosaOscuro;
                pctComidaVegana.Image = NutriWise.Properties.Resources.ComidaVeganaOscuro;
                pctComidaSaludable.Image = NutriWise.Properties.Resources.ComidaSaludableOscuro;
            }

        }

        private void pctComidaSaludable_Click(object sender, EventArgs e)
        {
            Process.Start("www.youtube.com/watch?v=cei3JhG72bg");
        }

        private void pctComidaVegana_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=_SpIHhePKWg");
        }

        private void pctComidaLactosa_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=q-sAjWopVPI");
        }

    }

}


