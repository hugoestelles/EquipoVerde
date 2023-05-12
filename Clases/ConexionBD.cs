using MySql.Data.MySqlClient;

namespace AEV7
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
                        string server = "server=127.0.0.1;";
                        string database = "database=aev7;";
                        string usuario = "uid=root;";
                        string password = "pwd=;";
                        instancia.ConnectionString = server + database + usuario + password;
                    }
                    return instancia;
                }
            }
        }

        public static void AbrirConexion()
        {
            if (instancia != null)
                instancia.Open();
        }

        public static void CerrarConexion()
        {
            if (instancia != null)
                instancia.Close();
        }

    }
}
