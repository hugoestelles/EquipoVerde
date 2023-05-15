using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace NutriWise
{
    class Platos
    {
        private int id;
        private string nombre;
        private int tipo;
        private List<Alimentos> listaAlimentos = new List<Alimentos>();
        private int[] listaCantidades;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Tipo { get { return tipo; } set { tipo = value; } }
        public List<Alimentos> ListaAlimentos { get { return listaAlimentos; } }
        public int[] ListaCantidades { get { return listaCantidades; } }


        public Platos(int id, string nom, int tip)
        {
            this.id = id;
            nombre = nom;
            tipo = tip;
            listaAlimentos = BuscarAlimentos();
            listaCantidades = BuscarCantidades();
        }

        public Platos() { }



        public int AgregarPlato()
        {
            int retorno;
            string consulta = string.Format("INSERT INTO platos (id,nombre,tipo,listaAlimentos,listaCantidades) VALUES " +
                "(@id,@nom,@tip,@lAlimentos,@lCantidades)");

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("id", id);
            comando.Parameters.AddWithValue("nom", nombre);
            comando.Parameters.AddWithValue("tip", tipo);
            comando.Parameters.AddWithValue("lAlimentos", listaAlimentos);
            comando.Parameters.AddWithValue("lCantidades", listaCantidades);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int CantidadPlatos()
        {
            int cantidad = -1;
            string consulta = "SELECT COUNT(*) FROM platos";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) cantidad = reader.GetInt32(0);

            return cantidad;
        }

        public static List<string> ListarPlatos()
        {
            List<string> lista = new List<string>();
            string consulta = "SELECT * FROM platos";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista[i] = reader.GetInt32(0) + "," + reader.GetString(1) + "," + reader.GetInt16(2);
                    i++;
                }
            }

            return lista;
        }

        private List<Alimentos> BuscarAlimentos()
        {
            List<Alimentos> lista = new List<Alimentos>();
            string consulta = string.Format("SELECT * FROM alimentos a INNER JOIN aliPlato ap ON a.idAlimento = ap.idAlimentos INNER JOIN platos p ON ap.idPlatos = p.idPlato WHERE p.idPlato = '{0}';",this.id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Alimentos a1 = new Alimentos(reader.GetInt32(0),reader.GetString(1),reader.GetDouble(2));
                    lista.Add(a1);
                   
                }
            }

            return lista;
        }

        private int[] BuscarCantidades()
        {
            int[] lista = new int[listaAlimentos.Count];
            for (int i = 0; i < listaAlimentos.Count; i++)
            {
                string consulta = string.Format("SELECT cantida FROM aliPlato WHERE idPlatos = '{0}' AND idAlimentos = '{1}';", this.id, listaAlimentos[i].Id);
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    lista[i] = reader.GetInt16(0);
                }
            }
                return lista;
        }
    }
}
