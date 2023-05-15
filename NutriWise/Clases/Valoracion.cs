using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWise.Clases
{
    internal class Valoracion
    {
        private int id;
        private int numEstrellas;
        private DateTime fecha;
        private string comentario;

        public int Id { get { return id; } set { id = value; } }
        public int NumEstrellas { get { return numEstrellas; } set { numEstrellas = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }
        public string Comentario { get { return comentario; } set { comentario = value; } }

/*
        public Valoraciones(int id, int nEstrellas, DateTime f, string com)
        {
            this.id = id;
            numEstrellas = nEstrellas;
            fecha = f;
            comentario = com;
        }

        public Valoraciones() { }*/
    }
}
