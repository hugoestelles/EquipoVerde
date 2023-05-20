using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        public List<Platos> Platos { get { return platos; } set { platos = value; } }


        public Dietas(string nombre, int objetivo, string tipo, int cantPlatos, int cantAlim)
        {
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
                    reader.Close();
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
                    reader.Close();
                }
            }
            ConexionBD.CerrarConexion();
            return retorno;
        }

        public void ObtenerDatosDieta(int idDieta)
        {

            string consulta = String.Format("SELECT * FROM dietas WHERE idDieta = {0};", idDieta);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                    this.id = reader.GetInt32(0);
                    this.nombre = reader.GetString(1);
                    this.objetivo = reader.GetInt32(2);
                    this.tipo = reader.GetString(3);
                    this.cantPlatos = reader.GetInt32(4);
                    this.cantAlim = reader.GetInt32(5);      
                
                reader.Close();
            }
            //this.platos = BuscarPlatos();
            reader.Close();
        }
        /// <summary>
        /// Funccion para obtener todos los platos de una dieta.
        /// </summary>
        /// <returns>Una lista de platos que contiene todos los platos de la dieta.</returns>
        public List<Platos> BuscarPlatos()
        {
            List<Platos> lista = new List<Platos>();
            string consulta = String.Format("SELECT * FROM platos WHERE idDieta = '{0}';", this.id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Platos p1 = new Platos(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(3));
                    lista.Add(p1);
                }
            }
            reader.Close();
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

        public bool PlatosRepetidos(ComboBox[] comboBoxes)
        {
            for (int i = 0; i < comboBoxes.Length; i++)
            {
                for (int j = i + 1; j < comboBoxes.Length; j++)
                {
                    if (comboBoxes[i].SelectedIndex == comboBoxes[j].SelectedIndex && comboBoxes[i].SelectedIndex != -1) return true;
                }
            }
            return false;
        }

        public static bool CantPlatosEspecificos(int obj, int into)
        {
            string consulta = string.Format("SELECT COUNT(*) FROM platos WHERE objetivo={0} AND intolerancia={1};", obj, into);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(0) >= 21)
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            reader.Close();
            return false;
        }

        public static int CantPlatosSeleccionados(ComboBox[] comboBoxes)
        {
            int cantidad = 0;
            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.SelectedIndex != -1) cantidad++;
            }
            return cantidad;
        }

        public static List<int> ObtenerIdPlatos(ComboBox[] platos)
        {
            List<int> listaId = new List<int>();
            for (int i = 0; i < platos.Length; i++)
            {
                if (platos[i].SelectedIndex != -1)
                {
                    string consulta = string.Format("SELECT idPlato FROM platos WHERE nombre='{0}';", platos[i].SelectedItem.ToString());
                    MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        listaId.Add(reader.GetInt16(0));
                    }
                    reader.Close();
                }
            }

            return listaId;
        }

        public static int CantAlimentosPlatos(List<int> idPlatos)
        {
            int cantidad = 0;
            foreach (int id in idPlatos)
            {
                string consulta = string.Format("SELECT SUM(cantida) FROM aliPlato WHERE idPlatos = {0};", id);
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cantidad += reader.GetInt32(0);
                }
                reader.Close();
            }

            return cantidad;
        }
    }
}
