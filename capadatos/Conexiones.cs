using System;
using System.Data.SqlClient;

namespace Sistema.Datos
{
    public class Conexiones
    {
        // Atributos de la clase
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexiones Con = null;

        // Constructor de la clase 
        private Conexiones()
        {
            this.Base = "base_dato_ieesl";
            this.Servidor = "LAPTOP-4P5UKAEA\\SQLEXPRESS";
            this.Usuario = "LAPTOP-4P5UKAEA\\PC";
            this.Clave = "";
            this.Seguridad = true;
        }

        // Método para crear conexiones
        public SqlConnection CrearConexiones()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                // Crear la cadena de conexión básica
                Cadena.ConnectionString = "Server=" + this.Servidor + ";Database=" + this.Base + ";";

                // Verificar si se usará la seguridad integrada de Windows o autenticación por usuario
                if (this.Seguridad)
                {
                    Cadena.ConnectionString += "Integrated Security=SSPI;";
                }
                else
                {
                    Cadena.ConnectionString += "User Id=" + this.Usuario + ";Password=" + this.Clave + ";";
                }

               
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw new Exception("Error al crear la conexion: + ex.Message");
            }

            return Cadena;
        }

        // Método para obtener una única instancia de la conexión (patrón Singleton)
        public static Conexiones GetInstancia()
        {
            if (Con == null)
            {
                Con = new Conexiones();
            }
            return Con;
        }
    }
}




