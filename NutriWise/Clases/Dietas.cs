using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NutriWise
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
            platos = new List<Platos>();
            this.cantPlatos = cantPlatos;
            this.cantAlim = cantAlim;
        }
        public Dietas(int id, string nom, int obj, string tip)
        {
            this.id = id;
            nombre = nom;
            objetivo = obj;
            tipo = tip;
            platos = BuscarPlatos();
            cantPlatos = platos.Count;
            cantAlim = ContarAlimentos();
        }
        public Dietas() { }
        /// <summary>
        /// Funcion para listar todos los alimentos de una dieta.
        /// </summary>
        /// <returns>Una lista de alimentos con todos los alimentos de la dieta.</returns>
        public List<Alimentos> ListaCompra()
        {
            ConexionBD.AbrirConexion();
            List<Alimentos> lista = new List<Alimentos>();
            string consulta = String.Format("SELECT a.idAlimento, a.nombre, a.valorNutricio FROM alimentos a INNER JOIN aliPlato ap ON a.idAlimento = ap.idAlimentos INNER JOIN platos p ON ap.idPlatos = p.idPlato INNER JOIN dietas d ON p.idDieta = d.idDieta WHERE d.idDieta = '{0}';", this.id);
            using (MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Alimentos a1 = new Alimentos(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2));
                            lista.Add(a1);
                        }
                    }
                }
            }
            ConexionBD.CerrarConexion();
            return lista;
        }

        public int ContarAlimentos()
        {
            ConexionBD.AbrirConexion();
            int retorno = 0;
            string consulta = String.Format("SELECT a.idAlimento, a.nombre, ap.cantida FROM alimentos a INNER JOIN aliPlato ap ON a.idAlimento = ap.idAlimentos INNER JOIN platos p ON ap.idPlatos = p.idPlato INNER JOIN dietas d ON p.idDieta = d.idDieta WHERE d.idDieta = '{0}';", this.id);
            using (MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            retorno++;
                        }
                    }
                }
            }
            ConexionBD.CerrarConexion();
            return retorno;
        }

        public static Dietas ObtenerDatosDieta(int idDieta)
        {
            Dietas d1 = null;
            string consulta = String.Format("SELECT * FROM dietas WHERE idDieta = '{0}';", idDieta);
            using (MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        d1 = new Dietas(idDieta, reader.GetString(1), reader.GetInt16(2), reader.GetString(3));
                    }
                }
            }
            return d1;
        }
        /// <summary>
        /// Funccion para obtener todos los platos de una dieta.
        /// </summary>
        /// <returns>Una lista de platos que contiene todos los platos de la dieta.</returns>
        public List<Platos> BuscarPlatos()
        {
            ConexionBD.CerrarConexion();
            ConexionBD.AbrirConexion();
            List<Platos> lista = new List<Platos>();
            string consulta = String.Format("SELECT * FROM platos WHERE idDieta = '{0}';", this.id);
            using (MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    List<object[]> platosData = new List<object[]>();
                    while (reader.Read())
                    {
                        object[] rowData = new object[reader.FieldCount];
                        reader.GetValues(rowData);
                        platosData.Add(rowData);
                    }

                    foreach (object[] rowData in platosData)
                    {
                        Platos p1 = new Platos(Convert.ToInt32(rowData[0]), Convert.ToString(rowData[1]), Convert.ToInt32(rowData[3]));
                        lista.Add(p1);
                    }
                }
            }

            ConexionBD.CerrarConexion();

            return lista;

        }

        /// <summary>
        /// Funcion para agregar dieta a la base de datos.
        /// </summary>
        /// <returns>1 si se añade con exito, 0 si hay algun error.</returns>
        public int AgregarDieta()
        {
            int retorno;
            string consulta = String.Format("INSERT INTO dietas (nombre, objetivoUsu, tipoDieta, cantidadPlatos, cantidadIngredientes) VALUES " +
                "(@nom,@objUsu,@tipoDieta,@cantPlatos,@cantIngredientes);");
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("nom", nombre);
            comando.Parameters.AddWithValue("objUsu", objetivo);
            comando.Parameters.AddWithValue("tipoDieta", tipo);
            comando.Parameters.AddWithValue("cantPlatos", cantPlatos);
            comando.Parameters.AddWithValue("cantIngredientes", cantAlim);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        /// <summary>
        /// Funcion para calcular el numero total de calorias de una determinada dieta.
        /// </summary>
        /// <returns>El numero total de calorias.</returns>
        public int ContarCalorias()
        {
            int calculo;
            int retorno = 0;
            for (int i = 0; i < this.platos.Count; i++)
            {
                for (int j = 0; j < this.platos[i].ListaAlimentos.Count; j++)
                {
                    calculo = (this.platos[i].ListaCantidades[j] / 100) * (int)this.platos[i].ListaAlimentos[j].ValorNutri;
                    retorno += calculo;
                }
            }
            return retorno;
        }

    }
}