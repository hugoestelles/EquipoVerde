using MySql.Data.MySqlClient;
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
        public Alimentos(string nom, double vNurti)
        {
            nombre = nom;
            valorNutri = vNurti;
        }

        public List<Alimentos> ListarAlimentos()
        {
            List<Alimentos> lista = new List<Alimentos>();
            string consulta = String.Format("SELECT * FROM alimentos;");
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Alimentos a1 = new Alimentos(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2));
                    lista.Add(a1);
                }
            }
            return lista;
        }

        public bool ComprobarExistencia(string nombre)
        {
            string consulta = String.Format("SELECT * FROM alimentos WHERE nombre = '{0}';", nombre);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else return false;
        }
        public int AgregarAlimento()
        {
            int retorno;
            string consulta = String.Format("INSERT INTO alimentos (nombre, valorNutricio) VALUES ('{0}', '{1}');", this.nombre, this.valorNutri);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

    }
}
