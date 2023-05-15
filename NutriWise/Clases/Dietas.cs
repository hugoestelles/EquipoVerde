using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWise.Clases
{
    class Dietas
    {
        private int id;
        private string nombre;
        private int objetivo;
        private string tipo;
        private int cantPlatos;
        private int cantAlim;
        private List<Platos> platos;

        public int Id { get { return id; } }
        public string Nombre { get { return nombre; } }
        public int Objetivo { get { return objetivo; } }
        public string Tipo { get { return tipo; } }
        public int CantPlatos { get { return cantPlatos; } }
        public int CantAlim { get { return cantAlim; } }
        public List<Platos> Platos { get { return platos; } }


        public Dietas(int id, string nombre, int objetivo, string tipo, int cantPlatos, int cantAlim)
        {
            this.id = id;
            this.nombre = nombre;
            this.objetivo = objetivo;
            this.tipo = tipo;
            platos = BuscarPlatos();
            this.cantPlatos = cantPlatos;
            this.cantAlim = cantAlim;
        }
        public Dietas(string nom, int obj, string tip)
        {
            nombre = nom;
            objetivo = obj;
            tipo = tip;
            platos = BuscarPlatos();
            cantPlatos = platos.Count;
            cantAlim = ContarAlimentos();
        }
        public Dietas() { }
        public List<Alimentos> ListaCompra()
        {
            List<Alimentos> lista = new List<Alimentos>();
            string consulta = String.Format("SELECT * FROM alimentos a INNER JOIN aliPlato ap ON a.idAlimento = ap.idAlimentos INNER JOIN platos p ON ap.idPlatos = p.idPlato INNER JOIN dietas d ON p.idDieta = d.idDieta WHERE d.idDieta = '{0}';", this.id);
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

        public int ContarAlimentos()
        {
            int retorno = 0;
            string consulta = String.Format("SELECT * FROM alimentos a INNER JOIN aliPlato ap ON a.idAlimento = ap.idAlimentos INNER JOIN platos p ON ap.idPlatos = p.idPlato INNER JOIN dietas d ON p.idDieta = d.idDieta WHERE d.idDieta = '{0}';", this.id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    retorno++;
                }
            }
            return retorno;
        }
        public List<Platos> BuscarPlatos()
        {
            List<Platos> lista = new List<Platos>();
            string consulta = String.Format("SELECT * FROM platos p INNER JOIN dietas d ON p.idDieta = d.idDieta WHERE d.idDieta = '{0}';", this.id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Platos p1 = new Platos();
                    lista.Add(p1);
                }
            }
            return lista;
        }
        public int AgregarDieta()
        {
            int retorno;
            string consulta = String.Format("INSERT INTO dietas (nombre, objetivoUsu, tipoDieta, cantidadPlatos, cantidadIngredientes) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", this.nombre, this.objetivo, this.tipo, this.cantPlatos, this.cantAlim);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

    }
}
