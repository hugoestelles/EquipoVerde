using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWise
{
    class Donativo
    {
        private int idDonativo;
        private double cant;
        private string nomUser;
        private DateTime fecha;

        public int IdDonativo { get { return idDonativo; } }
        public double Cant { get { return cant; } }
        public string NomUser { get { return nomUser; } }
        public DateTime Fecha { get { return fecha;} }

        public Donativo(int id, double canti, string nom, DateTime fech)
        {
            idDonativo  = id;
            cant = canti;
            nomUser = nom;
            fecha = fech;
        }

    }
}
