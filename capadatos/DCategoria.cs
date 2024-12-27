using System.Data.SqlClient;
using System.Data;
using System;
using Sistema.Entidad;
using Sistema.Datos;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Contracts;



namespace Sistema.Datos
{

    public class DCategoria
    {
        // Listar las categorías existentes
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
                SqlCommand Comando = new SqlCommand("categoria_listar", SqlCon);
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
                throw new Exception("Error al listar las categorías", ex);
            }
            finally
            {
                // Nos aseguramos de cerrar la conexión en caso de que esté abierta
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }



        }
        // Buscar una categoria
        public DataTable Buscar(string valor)
        {
            // obtener la cadena de conexion a la base de datos 
            SqlDataReader Resultado; // trae la informacion a la base de dato
            DataTable Tabla = new DataTable(); //Almacenar la tabla que sera devuelta 
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // OBTENER LA CADEMA DE CONEXION 
                SqlCon = Conexiones.GetInstancia().CrearConexiones(); //se tiene la cadena
                //NECESITAMOS UN OBJETO QUE EJECUTE EL COMANDO SQL 
                SqlCommand Comando = new SqlCommand("categoria_buscar", SqlCon);
                // Le decimos que va a ejecutar un procedmiento almacenado 
                Comando.CommandType = CommandType.StoredProcedure;
                //le indicamos el o los parametros que el store procedure necesita
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                // abrimos la conexion
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                //convertir el SqlDataReader (Resultado) a una Tabla
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //cerrar la conexion a la BD
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }

            }

        }
        // Determinar si una categoria existe
        public string Existe(string valor)
        {
            //obtener la cadena de conexion a la base de datos
            SqlDataReader Resultado; //Trea la informacion a la DB
            string Respuesta = ""; //Devolver la repuesta
            SqlConnection SqlCon = new SqlConnection(); //Objeto para realizar la conexion a la BD
            try
            {
                //obtener la cadena de conexion
                SqlCon = Conexiones.GetInstancia().CrearConexiones();//se tiene la cadena
                //necesitamos un objeto que ejecute el comando SQL
                SqlCommand Comando = new SqlCommand("categoria_existe", SqlCon);
                //le decimos que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //Indicamos parametross
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                // Parametros de Salida
                SqlParameter existe = new SqlParameter();
                existe.ParameterName = "@existe";
                existe.SqlDbType = SqlDbType.Int;
                existe.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(existe);
                //abrimos  la conexion 
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Respuesta = existe.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;

        }// FIN DEL METODO EXISTE

        // Metodo para registrar o insertar una cuenta 
        public string Insertar(Categoria obj)
        {
            string Respuesta = ""; // obtener string para conectar a la base de datos 
            SqlConnection SqlCon = new SqlConnection();//conectar a la base de datos
            try
            {
                //obtener la cadena de conexion
                SqlCon = Conexiones.GetInstancia().CrearConexiones(); //SE TIENE LA CADENA 
                SqlCommand Comando = new SqlCommand("categoria_insertar", SqlCon);// OBJETO QUE EJECUTA LA CONEXION 
                Comando.CommandType = CommandType.StoredProcedure;// VA A EJECUTAR UN PROCEDIMIENTO ALAMACENADO
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre; //PARAMETROS
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
                //ABRIR CONEXION
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;
        }
        //Fin del metodo Insertar
        //Actualizar una categoria
        public string Actualizar(Categoria obj)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexiones.GetInstancia().CrearConexiones();//se tiene la cadena
                SqlCommand Comando = new SqlCommand("categoria_actualizar", SqlCon);//necesitamos un objeto que ejecute el comando SQL
                Comando.CommandType = CommandType.StoredProcedure;//le decimos que va a ejecutar un procedimiento almacenado
                //le indicamos el o los parametros que el store procedure necesita
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = obj.IdCategoria;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
                //abrir conecion 
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo actualizar la categoria";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }

            }
            return Respuesta;
        }
        // fIN DEL METODO ACTUALIZAR 
        //  Metodo Eliminar una categoria
        public string Eliminar(int id)
        {
            string Respuesta = "";//obtener la cadena de conexion a la base de datos
            SqlConnection SqlCon = new SqlConnection();//objeto para realizar la conexion a la BD
            try
            {
                SqlCon = Conexiones.GetInstancia().CrearConexiones(); //cadena
                SqlCommand Comando = new SqlCommand("categoria_eliminar", SqlCon);//objeto para base de datos
                Comando.CommandType = CommandType.StoredProcedure; // el comando es procedimiento almacenada
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;//parametro
                //abrir conexion
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion 
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;

        }
        // fin del metodo eliminar
        //Activar una categoria
        public string Activar(int id)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexiones.GetInstancia().CrearConexiones();
                SqlCommand Comando = new SqlCommand("categoria_activar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                //ABRIMOS LA CONEXION
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "Ok" : "No se puede activar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;
        }
        //FINALIZAMOS METODO ACTIVAR
        public string Desactivar(int id)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexiones.GetInstancia().CrearConexiones();
                SqlCommand Comando = new SqlCommand("categoria_desactivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                //ABRIMOS LA CONEXION
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "Ok" : "No se puede desactivar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;

        }
        //fin de la clase desactivar

        //Listar la categoria para llevarla a la capa de articulos.

        public DataTable ListarCategoriasArticulos()
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
                SqlCommand Comando = new SqlCommand("categoria_seleccionar", SqlCon);
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
                throw new Exception("Error al listar las categorías", ex);
            }
            finally
            {
                // Nos aseguramos de cerrar la conexión en caso de que esté abierta
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }



        }
        // Buscar una categoria





























    }
}
   
    
  
 
    
   