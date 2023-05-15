using MySql.Data.MySqlClient;
using NutriWise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases
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

        public Usuario()
        {
        }

        public static int EliminarUsuario(string nombre)
        {
            int registrosAfectados;
            string consulta = string.Format("DELETE FROM usuario WHERE nombre='{0}'", nombre);
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.Conexion);
            registrosAfectados = comando.ExecuteNonQuery();

            return registrosAfectados;
        }
    }
}
