﻿using MySql.Data.MySqlClient;
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


        /// <summary>
        /// Funcion para agregar platos a la base de datos.
        /// </summary>
        /// <returns>1 se se añade con exito, 0 si hay algun error.</returns>
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
        /// <summary>
        /// Funcion para calcular la cantidad total de platos en la base de datos.
        /// </summary>
        /// <returns>El numero total de platos.</returns>
        public static int CantidadPlatos()
        {
            int cantidad = -1;
            string consulta = "SELECT COUNT(*) FROM platos";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) cantidad = reader.GetInt32(0);

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

            return lista;
        }
        /// <summary>
        /// Funcion para obtener todos los alimentos que contiene un plato.
        /// </summary>
        /// <returns>Una lista de alimentos con todos los alimentos del plato.</returns>
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
        /// <summary>
        /// Funcion para obtener las cantidad de cada ingrediente en un determinado plato.
        /// </summary>
        /// <returns>Un array de int con las cantidad en gramos.</returns>
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
