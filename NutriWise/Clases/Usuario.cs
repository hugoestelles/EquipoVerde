using MySql.Data.MySqlClient;

namespace NutriWise.Clases
{
    internal class Usuario
    {
        private int id;
        private string correo;
        private string contra;
        private string nombre;
        private string apellidos;
        private double altura;
        private double peso;
        private int intolerancia;
        private int actividad;
        private int objetivo;
        private bool administrador;

        public int Id { get { return id; } }
        public string Correo { get { return correo; } }
        public string Contra { get { return contra; } }
        public string Nombre { get { return nombre; } }
        public string Apellidos { get { return apellidos; } }
        public double Altura { get { return altura; } }
        public double Peso { get { return peso; } }
        public int Intolerancia { get { return intolerancia; } }
        public int Actividad { get { return actividad; } }
        public int Objetivo { get { return objetivo; } }
        public bool Administrador { get { return administrador; } }

        public Usuario(int idusu, string mail, string pass, string name, string ape, double alt, double pes, int into, int act, int obj, bool admin)
        {
            id = idusu;
            correo = mail;
            contra = pass;
            nombre = name;
            apellidos = ape;
            altura = alt;
            peso = pes;
            altura = alt;
            intolerancia = into;
            actividad = act;
            objetivo = obj;
            administrador = admin;
        }

        public Usuario() { }


        public int AgregarUsuario()
        {
            int retorno;
            string consulta = string.Format("INSERT INTO usuarios (id,correo,contra,nombre,apellidos,altura,peso,intolerancia,actividad,objetivo,administrador) VALUES " +
                "(@id,@correo,@contra,@nom,@ape,@alt,@peso,@intolerancia,@act,@obj,@admin);");

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("id", id);
            comando.Parameters.AddWithValue("correo", correo);
            comando.Parameters.AddWithValue("contra", contra);
            comando.Parameters.AddWithValue("nom", nombre);
            comando.Parameters.AddWithValue("ape", apellidos);
            comando.Parameters.AddWithValue("alt", altura);
            comando.Parameters.AddWithValue("peso", peso);
            comando.Parameters.AddWithValue("intolerancia", intolerancia);
            comando.Parameters.AddWithValue("act", actividad);
            comando.Parameters.AddWithValue("obj", objetivo);
            comando.Parameters.AddWithValue("admin", administrador);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int EliminarUsuario()
        {
            int retorno;
            string consulta = string.Format("DELETE FROM usuarios WHERE id='{0}'", id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static bool YaEstaUsuario(int id)
        {
            string consulta = string.Format("SELECT * FROM usuarios WHERE id='{0}'", id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) return true;
            return false;
        }

        public static Usuario BuscarUsuario(int id)
        {
            Usuario user = new Usuario();
            string consulta = string.Format("SELECT * FROM usuarios WHERE id='{0}'", id);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                user.id = reader.GetInt32(0);
                user.correo = reader.GetString(1);
                user.contra = reader.GetString(2);
                user.nombre = reader.GetString(3);
                user.apellidos = reader.GetString(4);
                user.altura = reader.GetDouble(5);
                user.peso = reader.GetDouble(6);
                user.intolerancia = reader.GetInt16(7);
                user.actividad = reader.GetInt16(8);
                user.objetivo = reader.GetInt16(9);
                user.administrador = reader.GetBoolean(10);
            }

            return user;
        }
    }
}
