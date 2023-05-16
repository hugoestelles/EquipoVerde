using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

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
            string consulta = string.Format("INSERT INTO usuario (correo,contra,nombre,apellidos,altura,peso,intolerancia,actividad,objetivo,administrador) VALUES " +
                "(@correo,@contra,@nom,@ape,@alt,@peso,@intolerancia,@act,@obj,@admin);");

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

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int EliminarUsuario(string correo)
        {
            int retorno;
            string consulta = string.Format("DELETE FROM usuario WHERE correo='{0}'", correo);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static bool YaEstaUsuario(string correo)
        {
            string consulta = string.Format("SELECT * FROM usuario WHERE correo='{0}'", correo);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) return true;
            return false;
        }

        public static Usuario BuscarUsuario(string correo)
        {
            Usuario user = new Usuario();
            string consulta = string.Format("SELECT * FROM usuario WHERE correo='{0}'", correo);
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

        public static bool ComprobarClaveEstatica(string correo, string clave)
        {
            string consulta = string.Format("SELECT clave FROM usuario WHERE correo='{0}' AND clave='{1}'", correo, clave);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) return true;
            return false;
        }

        public bool YaEstaCorreo()
        {
            string consulta = string.Format("SELECT correo FROM usuario WHERE correo='{0}'", correo);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) return true;
            return false;
        }
        public int ActualizarUsuario(string correo, string nombre, string apellidos, decimal altura, decimal peso, int intolerancia, decimal actividad, int objetivo)
        {
            int retorno;
            string consulta = string.Format("UPDATE usuario SET correo = @correo,clave = {2}, nombre = @nom, apellidos = @ape, altura = @alt, peso = @peso, tipoIntolencia = @intolerancia, cantActividad = @actividad, objetivo = @objetivo, administrador = '{0}' WHERE idUsuario = '{1}';", this.administrador, this.id, this.contra);

            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            comando.Parameters.AddWithValue("correo", correo);
            comando.Parameters.AddWithValue("nom", nombre);
            comando.Parameters.AddWithValue("ape", apellidos);
            comando.Parameters.AddWithValue("alt", altura);
            comando.Parameters.AddWithValue("peso", peso);
            comando.Parameters.AddWithValue("intolerancia", intolerancia);
            comando.Parameters.AddWithValue("act", actividad);
            comando.Parameters.AddWithValue("obj", objetivo);

            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

    }
}
