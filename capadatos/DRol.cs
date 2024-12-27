using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DRol
    {
        //listar roles
        public DataTable Listar()
        {
            // Variables necesarias para la conexión y el resultado
            SqlDataReader Resultado; // Objeto que trae la información de la BD
            DataTable Tabla = new DataTable(); // Almacena la tabla
            SqlConnection SqlCon = new SqlConnection(); // Objeto para realizar la conexión

            try
            {
                // Obtener la cadena de conexión
                SqlCon = Conexiones.GetInstancia().CrearConexiones(); // Se tiene la cadena

                // Necesitamos un objeto que ejecute el comando SQL
                SqlCommand Comando = new SqlCommand("rol_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                // Abrimos la conexión
                SqlCon.Open();

                // Ejecutamos el comando y cargamos los resultados en la tabla
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);

                // Retornamos la tabla con los datos
                return Tabla;
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción de alguna manera (log, rethrow, etc.)
                throw new Exception("Error al listar los roles", ex);
            }
            finally
            {
                // Nos aseguramos de cerrar la conexión en caso de que esté abierta
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }



        }
        public DataTable ListarRolesUsuarios()
        {
            // Variables necesarias para la conexión y el resultado
            SqlDataReader Resultado; // Objeto que trae la información de la BD
            DataTable Tabla = new DataTable(); // Almacena la tabla
            SqlConnection SqlCon = new SqlConnection(); // Objeto para realizar la conexión

            try
            {
                // Obtener la cadena de conexión
                SqlCon = Conexiones.GetInstancia().CrearConexiones(); // Se tiene la cadena

                // Necesitamos un objeto que ejecute el comando SQL
                SqlCommand Comando = new SqlCommand("rol_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                // Abrimos la conexión
                SqlCon.Open();

                // Ejecutamos el comando y cargamos los resultados en la tabla
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);

                // Retornamos la tabla con los datos
                return Tabla;
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción de alguna manera (log, rethrow, etc.)
                throw new Exception("Error al listar los roles", ex);
            }
            finally
            {
                // Nos aseguramos de cerrar la conexión en caso de que esté abierta
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }



        }






































































    }
}
