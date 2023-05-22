using MySql.Data.MySqlClient;

namespace NutriWise
{
    // Clase que implementa el patrón Singleton para la conexión a la base de datos
    public class ConexionBD
    {
        private static MySqlConnection instancia = null;
        private static readonly object padlock = new object();

        private ConexionBD() { }

        // Propiedad pública y estática que devuelve la instancia única de la conexión a la base de datos
        public static MySqlConnection Conexion
        {
            get
            {
                lock (padlock)
                {
                    // Si la instancia no ha sido creada, se crea y se configura la cadena de conexión
                    if (instancia == null)
                    {
                        instancia = new MySqlConnection();
                        string server = "server=pruebabd.cusxbcc1yr4p.us-east-1.rds.amazonaws.com;";
                        string database = "database=nutriwise;";
                        string usuario = "uid=admin;";
                        string password = "pwd=12345678;";
                        instancia.ConnectionString = server + database + usuario + password;
                    }
                    return instancia;
                }
            }
        }
        /// <summary>
        /// Funcion para abrir conexion con la base de datos.
        /// </summary>
        public static void AbrirConexion()
        {
            if (instancia != null)
                instancia.Open();
        }
        /// <summary>
        /// Funcion para cerrar la conexion con la base de datos.
        /// </summary>
        public static void CerrarConexion()
        {
            if (instancia != null)
                instancia.Close();
        }

    }
}
