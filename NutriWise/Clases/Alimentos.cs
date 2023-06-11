﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        public Alimentos()
        {
        }
        public Alimentos(string nom, double vNurti)
        {
            nombre = nom;
            valorNutri = vNurti;
        }
        /// <summary>
        /// Funcion para listar todos los alimentos de la base de datos.
        /// </summary>
        /// <returns>Una lista de alimentos.</returns>
        public static List<Alimentos> ListarAlimentos()
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
            reader.Close();
            return lista;
        }
        /// <summary>
        /// Funcion para comprobar si un alimento ya existe en la base de datos.
        /// </summary>
        /// <returns>True si existe, false si no existe.</returns>
        public bool ComprobarExistencia()
        {
            string consulta = String.Format("SELECT * FROM alimentos WHERE nombre = '{0}';", this.nombre);
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
        /// Funcion para agregar alimento a la base de datos.
        /// </summary>
        /// <returns>1 si añade el alimento, 0 si hay algun error.</returns>
        public int AgregarAlimento()
        {
            int retorno;
            string consulta = String.Format("INSERT INTO alimentos (nombre, valorNutricio) VALUES " +
                "(@nom, @valorNutri);");
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("nom", nombre);
            comando.Parameters.AddWithValue("valorNutri", valorNutri);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        /// Función para obtener los datos de alimento
        /// </summary>
        /// <param></param>
        /// <returns> retorna al que es un nuevo alimento o null</returns>
        public static Alimentos ObtenerDatosAlimento(string nombre)
        {
            Alimentos a1;
            string consulta = String.Format("SELECT * FROM alimentos WHERE nombre = '{0}';", nombre);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                a1 = new Alimentos(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2));
                reader.Close();
                return a1;

            }
            else
            {
                reader.Close();
                return null;
            }
        }

        /// <summary>
        /// La función busca el id.
        /// </summary>
        /// <returns>ve si tiene id y retorna true o folse</returns>
        public bool BuscarID()
        {
            string consulta = String.Format("SELECT * FROM alimentos WHERE nombre = '{0}';", this.Nombre);
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
