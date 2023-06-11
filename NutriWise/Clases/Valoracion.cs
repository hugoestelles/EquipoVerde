using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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


        public Valoracion(int nEstrellas, DateTime f, string com)
        {
            numEstrellas = nEstrellas;
            fecha = f;
            comentario = com;
        }

        /// <summary>
        /// Funcion para añadir valoracion a la base de datos.
        /// </summary>
        /// <returns>1 si se añade con exito, 0 si no.</returns>
        public int AgregarValoracion()
        {
            if (ConexionBD.Conexion != null)
            {
                try
                {
                    ConexionBD.AbrirConexion();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                int retorno;
                string consulta = string.Format("INSERT INTO valoraciones (numEstrellas,fechaValoracion,comentario) VALUES " +
                    "(@numEstrellas,@fecha,@comentario)");

                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
                comando.Parameters.AddWithValue("numEstrellas", numEstrellas);
                comando.Parameters.AddWithValue("fecha", fecha);
                comando.Parameters.AddWithValue("comentario", comentario);

                retorno = comando.ExecuteNonQuery();
                ConexionBD.CerrarConexion();
                return retorno;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Funcion para obtener la cantidad de valoraciones en la base de datos.
        /// </summary>
        /// <returns>La cantidad de valoraciones en formato int.</returns>
        public static int CantidadValoraciones()
        {
            int cantidad = -1;
            string consulta = "SELECT COUNT(*) FROM valoraciones";
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
        /// Funcion para calcular la media de las valoraciones.
        /// </summary>
        /// <returns>La media de las valoraciones en formato int.</returns>
        public static int MediaValoraciones()
        {
            int cantidad = -1;
            string consulta = "SELECT AVG(numEstrellas) FROM valoraciones";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                cantidad = reader.GetInt16(0);
            }

            reader.Close();
            return cantidad;
        }
        /// <summary>
        /// Funcion para listar todas las valoraciones de la base de datos.
        /// </summary>
        /// <returns>Una List<String> con toda la informacion.</String></returns>
        public static List<string> ListarValoraciones()
        {
            List<string> valoraciones = new List<string>();
            string consulta = "SELECT * FROM valoraciones";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    valoraciones[i] = reader.GetInt32(0) + "," + reader.GetInt16(1) + "," + reader.GetDateTime(2) + "," + reader.GetString(3);
                    i++;
                }
            }

            reader.Close();
            return valoraciones;
        }
        /// <summary>
        /// Funcion para obtener las fecha de todas las valoraciones de la base de datos en un intervalo de tiempo.
        /// </summary>
        /// <param name="fInicial">Fecha inicial.</param>
        /// <param name="fFinal">Fecha final.</param>
        /// <returns>Una List<String> con todas las fechas.</String></returns>
        public static List<string> FechaValoraciones(DateTime fInicial, DateTime fFinal)
        {
            List<string> valoraciones = new List<string>();
            string consulta = "SELECT * FROM valoraciones WHERE fecha BETWEEN @fInicial AND @fFinal";

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("fInicial", fInicial.ToString("yyyy/MM/dd"));
            comando.Parameters.AddWithValue("fFinal", fFinal.ToString("yyyy/MM/dd"));
            MySqlDataReader reader = comando.ExecuteReader();

            int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    valoraciones[i] = reader.GetInt32(0) + "," + reader.GetInt16(1) + "," + reader.GetDateTime(2) + "," + reader.GetString(3);
                    i++;
                }
            }

            reader.Close();
            return valoraciones;
        }
    }
}
