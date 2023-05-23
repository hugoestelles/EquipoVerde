using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NutriWise
{
    class Donativo
    {
        private int idDonativo;
        private double cant;
        private DateTime fecha;
        private string nomUser;
        private int idUsuario;

        public int IdDonativo { get { return idDonativo; } }
        public double Cant { get { return cant; } }
        public DateTime Fecha { get { return fecha; } }
        public string NomUser { get { return nomUser; } }
        public int IdUsuario { get { return idUsuario; } }


        public Donativo(double canti, DateTime fech, string nom, int idUser)
        {
            cant = canti;
            fecha = fech;
            nomUser = nom;
            idUsuario = idUser;
        }

        /// <summary>
        /// Funcion para realizar donativo.
        /// </summary>
        /// <returns>1 si se realiza la donacion con exito, 0 si hay algun problema.</returns>
        public int Donar()
        {
            int retorno;
            string consulta = string.Format("INSERT INTO donativos (cantidad,fechaDonativo,nombre, idUsuari) VALUES " +
                "(@cant,@fecha,@nomUser, @idUusario)");

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("cant", cant);
            comando.Parameters.AddWithValue("fecha", fecha);
            comando.Parameters.AddWithValue("nomUser", nomUser);
            comando.Parameters.AddWithValue("idUusario", idUsuario);


            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        /// <summary>
        /// Funcion para listar todos los donativos de la base de datos.
        /// </summary>
        /// <returns>Una List<String> con todos los donativos.</String></returns>
        public static List<string> ListarDonativos()
        {
            List<string> valoraciones = new List<string>();
            string consulta = "SELECT * FROM donativos";
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
        /// Funcion para calcular la cantidad total de donativos.
        /// </summary>
        /// <returns>La cantidad total de donativos.</returns>
        public static double CantidadRecaudada()
        {
            double cantidad = -1;
            string consulta = "SELECT SUM(cant) FROM donativos";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                cantidad = reader.GetDouble(0);
            }

            reader.Close();
            return cantidad;
        }
    }
}
