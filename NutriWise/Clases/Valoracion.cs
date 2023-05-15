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


        public Valoracion(int id, int nEstrellas, DateTime f, string com)
        {
            this.id = id;
            numEstrellas = nEstrellas;
            fecha = f;
            comentario = com;
        }

        public Valoracion() { }


        public int AgregarValoracion()
        {
            int retorno;
            string consulta = string.Format("INSERT INTO valoraciones (id,numEstrellas,fecha,comentario) VALUES " +
                "(@id,@numEstrellas,@fecha,@comentario)");

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("id", id);
            comando.Parameters.AddWithValue("numEstrellas", numEstrellas);
            comando.Parameters.AddWithValue("fecha", fecha);
            comando.Parameters.AddWithValue("comentario", comentario);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int CantidadValoraciones()
        {
            int cantidad = -1;
            string consulta = "SELECT COUNT(*) FROM valoraciones";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) cantidad = reader.GetInt32(0);

            return cantidad;
        }

        public static int MediaValoraciones()
        {
            int cantidad = -1;
            string consulta = "SELECT AVG(numEstrellas) FROM valoraciones";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) cantidad = reader.GetInt16(0);

            return cantidad;
        }

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

            return valoraciones;
        }

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

            return valoraciones;
        }
    }
}
