using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Clases
{
    class Platos
    {
        private int id;
        private string nombre;
        private Hashtable alimentos = new Hashtable();

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public Hashtable Alimentos { get { return alimentos; } set { alimentos = value; } }


        public Platos(int id, string nom, Hashtable ali)
        {
            this.id = id;
            nombre = nom;
            alimentos = ali;
        }

        public Platos() { }
    }
}
