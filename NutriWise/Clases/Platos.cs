using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NutriWise
{
    class Platos
    {
        private int id;
        private string nombre;
        private int tipo;
        private List<Alimentos> listaAlimentos = new List<Alimentos>();
        private int[] listaCantidades;
        private int objetivo;
        private int intolerancia;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Tipo { get { return tipo; } set { tipo = value; } }
        public List<Alimentos> ListaAlimentos { get { return listaAlimentos; } set { listaAlimentos = value; } }
        public int[] ListaCantidades { get { return listaCantidades; } set { listaCantidades = value; } }


        public Platos(int id, string nom, int tip)
        {
            this.id = id;
            nombre = nom;
            tipo = tip;
        }
        public Platos(string nom, int tip, int obj, int into)
        {
            nombre = nom;
            tipo = tip;
            objetivo = obj;
            intolerancia= into;
        }
        public Platos() { }
        public bool ComprobarExistencia()
        {
            string consulta = String.Format("SELECT * FROM platos WHERE nombre = '{0}';", this.nombre);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;

            }
            else
            {
                reader.Close();
                return false;
            }
        }


        /// <summary>
        /// Funcion para agregar platos a la base de datos.
        /// </summary>
        /// <returns>1 se se añade con exito, 0 si hay algun error.</returns>
        public int AgregarPlato()
        {
            int retorno;
            string consulta = string.Format("INSERT INTO platos (nombre,idDieta,tipo,Objetivo,Intolerancia) VALUES " +
                "(@nom,@tip,@idDieta,@obj,@into);");

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("@idDieta", 0);
            comando.Parameters.AddWithValue("@nom", nombre);
            comando.Parameters.AddWithValue("@tip", tipo);
            comando.Parameters.AddWithValue("@obj", objetivo);
            comando.Parameters.AddWithValue("@into", intolerancia);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        /// <summary>
        /// Funcion para calcular la cantidad total de platos en la base de datos.
        /// </summary>
        /// <returns>El numero total de platos.</returns>
        public static int CantidadPlatos()
        {
            int cantidad = -1;
            string consulta = "SELECT COUNT(*) FROM platos;";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                cantidad = reader.GetInt32(0);
            }

            reader.Close();
            return cantidad;
        }
        /// <summary>
        /// Funcion para listar todos los platos de la base de datos.
        /// </summary>
        /// <returns>Una List<String> que contiene informacion sobre todos los platos de la base de datos.</String></returns>
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

            reader.Close();
            return lista;
        }
        /// <summary>
        /// Funcion para obtener todos los alimentos que contiene un plato.
        /// </summary>
        public List<Alimentos> BuscarAlimentos()
        {
            List<Alimentos> lista = new List<Alimentos>();
            string consulta = string.Format("SELECT a.idAlimento, a.nombre, a.valorNutricio FROM alimentos a INNER JOIN aliPlato ap ON a.idAlimento = ap.idAlimentos INNER JOIN platos p ON ap.idPlatos = p.idPlato WHERE p.idPlato = '{0}';", this.id);
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

            reader.Close();
            return lista;
        }
        /// <summary>
        /// Funcion para obtener las cantidad de cada ingrediente en un determinado plato.
        /// </summary>
        /// <returns>Un array de int con las cantidad en gramos.</returns>
        public int[] BuscarCantidades()
        {
            int[] lista = new int[listaAlimentos.Count];
            for (int i = 0; i < listaAlimentos.Count; i++)
            {
                string consulta = string.Format("SELECT * FROM aliPlato WHERE idPlatos = '{0}' AND idAlimentos = '{1}';", this.id, listaAlimentos[i].Id);
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    lista[i] = reader.GetInt16(2);
                }
                reader.Close();
            }
            return lista;
        }
        /// <summary>
        /// Funncion para buscar la dieta asignada a un plato.
        /// </summary>
        /// <returns>ID de la dieta.</returns>
        private int BuscarDieta()
        {

            string consulta = String.Format("SELECT idDieta FROM platos WHERE idPlato = '{0}';", this.id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                int ret = reader.GetInt32(0);
                reader.Close();
                return ret;
            }
            else
            {
                reader.Close();
                return 0;
            }
        }
        /// <summary>
        /// Función para insertar en la tabla de relaciones AliPlatos
        /// </summary>
        /// <returns>True si hace todas las inserciones con exito, false si no.</returns>
        public bool InsertarAliPlato()
        {
            bool retorno = false;
            for (int i = 0; i < this.listaAlimentos.Count; i++)
            {
                string consulta = string.Format("INSERT INTO aliPlato (idAlimentos,idPlatos,cantida) VALUES " +
                    "(@idA,@idP,@cant)");

                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
                comando.Parameters.AddWithValue("idA", this.listaAlimentos[i].Id);
                comando.Parameters.AddWithValue("idP", this.Id);
                comando.Parameters.AddWithValue("cant", this.ListaCantidades[i]);

                int aux = comando.ExecuteNonQuery();
                if (aux == 1) retorno = true;
                else retorno = false;

                comando.Dispose();
            }
            return retorno;
        }
        public bool BuscarID()
        {
            string consulta = String.Format("SELECT * FROM platos WHERE nombre = '{0}';", this.Nombre);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                id = reader.GetInt32(0);
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }
    }
}