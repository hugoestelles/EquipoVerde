using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWise
{
    class Alimentos
    {
        private int id;
        private string nombre;
        private double valorNutri;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public double ValorNutri { get { return valorNutri; } set { valorNutri = value; } }


        public Alimentos(int id, string nom, double vNutri)
        {
            this.id = id;
            nombre = nom;
            valorNutri = vNutri;
        }

        public Alimentos() { }

    }
}
