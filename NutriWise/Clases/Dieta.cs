using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Clases
{
    class Dieta
    {
        private int id;
        private string nombre;
        private int objetivo;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Objetivo { get { return objetivo; } set { objetivo = value; } }


        public Dieta(int id, string nom, int obj)
        {
            this.id = id;
            nombre = nom;
            objetivo = obj;
        }

        public Dieta() { }
    }
}
