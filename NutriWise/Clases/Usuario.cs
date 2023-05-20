using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System;

namespace NutriWise.Clases
{
    internal class Usuario
    {
        private int id;
        private string correo;
        private string contra;
        private string nombre;
        private string apellidos;
        private decimal altura;
        private decimal peso;
        private int intolerancia;
        private decimal actividad;
        private int objetivo;
        private bool administrador;
        private static Usuario usuarioActual;
        private static Dietas dietaActual;

        public int Id { get { return id; } }
        public string Correo { get { return correo; } }
        public string Contra { get { return contra; } }
        public string Nombre { get { return nombre; } }
        public string Apellidos { get { return apellidos; } }
        public decimal Altura { get { return altura; } }
        public decimal Peso { get { return peso; } }
        public int Intolerancia { get { return intolerancia; } }
        public decimal Actividad { get { return actividad; } }
        public int Objetivo { get { return objetivo; } }
        public bool Administrador { get { return administrador; } }
        public static Usuario UsuarioActual { get { return usuarioActual; } set { usuarioActual = value; } }
        public static Dietas DietaActual { get { return dietaActual; } set { dietaActual = value; } }
        
        public Usuario(string correo)
        {
            this.correo = correo;
        }

        public Usuario(int idusu, string mail, string pass, string name, string ape, decimal alt, decimal pes, int into, decimal act, int obj, bool admin)
        {
            id = idusu;
            correo = mail;
            contra = pass;
            nombre = name;
            apellidos = ape;
            altura = alt;
            peso = pes;
            intolerancia = into;
            actividad = act;
            objetivo = obj;
            administrador = admin;
        }

        public Usuario(string mail, string pass, string name, string ape, decimal alt, decimal pes, int into, decimal act, int obj)
        {

            contra = pass;
            nombre = name;
            correo = mail;
            apellidos = ape;
            altura = alt;
            peso = pes;
            intolerancia = into;
            actividad = act;
            objetivo = obj;
            administrador = false;
        }
        public Usuario() { }
        /// <summary>
        /// Funcion para buscar la dieta que le corresponde a cada usuario.
        /// </summary>
        /// <param name="ob">Objetivo del usuario.</param>
        /// <param name="into">Intolerancia del usuario.</param>
        /// <returns>El ID de la dieta en formato int.</returns>
        public static int BuscarDieta(int ob, int into)
        {
            string tipo = TipoDieta(into);
            string consulta = string.Format("SELECT * FROM dietas WHERE objetivoUsu ='{0}' AND tipoDieta ='{1}'", ob, tipo);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                int ret = reader.GetInt32(0);
                reader.Close();
                return ret;
            }
            else
            {
                reader.Close();
                return -1;
            }
        }
        /// <summary>
        /// Funcion para agregar usuario a la base de datos.
        /// </summary>
        /// <param name="idDieta">id de la dieta que tiene el usuario.</param>
        /// <returns>1 se se añade con exito, 0 si hay algun error.</returns>
        public int AgregarUsuario(int idDieta)
        {
            int retorno;
            string consulta = string.Format("INSERT INTO usuario (correo,clave,nombre,apellidos,altura,peso,tipoIntolencia,cantActividad,objetivo,administrador,idDieta) VALUES " +
                "(@correo,@contra,@nom,@ape,@alt,@peso,@intolerancia,@act,@obj,@admin,@idDieta);");

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
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
            comando.Parameters.AddWithValue("idDieta", idDieta);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        /// <summary>
        /// Funcion para eliminar un usuario de la base de datos.
        /// </summary>
        /// <param name="correo">Correo del usuario que queremos eliminar.</param>
        /// <returns>1 se se elimina con exito, 0 si hay algun error.</returns>
        public static int EliminarUsuario(string correo)
        {
            int retorno;
            string consulta = string.Format("DELETE FROM usuario WHERE correo='{0}'", correo);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        /// <summary>
        /// Funcion para comprobar si un usuario existe en la base de datos.
        /// </summary>
        /// <param name="correo">Correo del usuario.</param>
        /// <returns>True si se encuentra el usuario en la base de datos, false si no lo encuentra.</returns>
        public static bool YaEstaUsuario(string correo)
        {
            string consulta = string.Format("SELECT * FROM usuario WHERE correo='{0}'", correo);
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
        /// Funcion para obtener los datos de un usuario de la base de datos.
        /// </summary>
        /// <param name="correo">Correo del usuario.</param>
        /// <returns>Un usuario con los datos cargados.</returns>
        public static Usuario BuscarUsuario(string correo)
        {
            Usuario user = new Usuario();
            string consulta = string.Format("SELECT * FROM usuario WHERE correo='{0}'", correo);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.Read() && reader.HasRows)
            {
                user.id = reader.GetInt32(0);
                user.correo = reader.GetString(1);
                user.contra = reader.GetString(2);
                user.nombre = reader.GetString(3);
                user.apellidos = reader.GetString(4);
                user.altura = (decimal)reader.GetDouble(5);
                user.peso = (decimal)reader.GetDouble(6);
                user.intolerancia = reader.GetInt16(7);
                user.actividad = reader.GetInt16(8);
                user.objetivo = reader.GetInt16(9);
                user.administrador = reader.GetBoolean(10);
            }
            reader.Close();
            return user;
        }
        /// <summary>
        /// Funcion para comprobar que el correo tiene el formato correcto.
        /// </summary>
        /// <returns>True si el correo es correcto, false si es incorrecto.</returns>
        public bool ComprobarCorreo()
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;

            try
            {
                correo = Regex.Replace(correo, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /// <summary>
        /// Funcion para comprobar que el correo tiene el formato correcto.
        /// </summary>
        /// <returns>True si el correo es correcto, false si es incorrecto.</returns>
        public static bool ComprobarCorreoEstatico(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;

            try
            {
                correo = Regex.Replace(correo, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /// <summary>
        /// Funcion para comprobar que la contraseña coincide con el correo indicado.
        /// </summary>
        /// <param name="correo">Correo del usuario.</param>
        /// <param name="clave">Contraseña del usuario.</param>
        /// <returns>True si coincide, false si no.</returns>
        public static bool ComprobarClaveEstatica(string correo, string clave)
        {
            string consulta = string.Format("SELECT clave FROM usuario WHERE correo='{0}' AND clave='{1}'", correo, clave);
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
        public int ActualizarInfo(string nom, string ape, decimal alt, decimal pes, string correo, int into, int act, int obj)
        {
            this.nombre = nom;
            this.apellidos = ape;
            this.altura = alt;
            this.peso = pes;
            this.correo = correo;
            this.intolerancia = into;
            this.actividad = act;
            this.objetivo = obj;
            int compro = ActualizarEnBD();
            return compro;
        }
        private int ActualizarEnBD()
        {
            int retorno;
            string consulta = String.Format("UPDATE usuario SET correo = @correo, nombre = @nom, apellidos = @ape, altura = @alt, peso = @peso,  tipoIntolencia = @intolerancia, cantActividad = @act, objetivo = @obj, idDieta = @dieta WHERE idUsuario = @user;");
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("correo", this.correo);
            comando.Parameters.AddWithValue("nom", this.nombre);
            comando.Parameters.AddWithValue("ape", this.apellidos);
            comando.Parameters.AddWithValue("alt", this.altura);
            comando.Parameters.AddWithValue("peso", this.peso);
            comando.Parameters.AddWithValue("intolerancia", this.intolerancia);
            comando.Parameters.AddWithValue("act", this.actividad);
            comando.Parameters.AddWithValue("obj", this.objetivo);
            comando.Parameters.AddWithValue("user", this.id);
            comando.Parameters.AddWithValue("Dieta", BuscarDieta(this.objetivo, this.intolerancia));
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        private static string TipoDieta(int indice)
        {
            switch (indice)
            {
                case 0:
                    return "Lactosa";
                case 1:
                    return "Gluten";
                case 2:
                    return "Vegana";
                case 3:
                    return "Vegetariano";
                case 4:
                    return "Sin_Intolerancia";
                default:
                    return "";

            }
        }
    }
}