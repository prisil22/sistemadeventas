using Sistema.Datos;
using Sistema.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NUsuario
    {    // Listar Usuarios.
        public static DataTable Listar()
        {
            DUsuario Datos = new DUsuario();
            return Datos.Listar();

        }

        //login
        public static DataTable Login(string email, string clave)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Login(email, clave);

        }

        

        //Buscar
        public static DataTable Buscar(string valor)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Buscar(valor);

        }

        public static string Crear(int idRol, string nombre, string tipo_Documento, string num_Documento,
            string direccion, string telefono, string email, string clave)
        {
            DUsuario Datos = new DUsuario();
            Usuario usuario = new Usuario();
            //antes debo verificar si existe el usuario.
            string existe = Datos.Existe(email);
            if (existe == "1")
            {
                return "El usuario ya existe";
            }
            else
            {     //Constuir un usuario para enviarlo a datos y su metodo insertar 
                usuario.IdRol = idRol;
                usuario.Nombre = nombre;
                usuario.Tipo_Documento = tipo_Documento;
                usuario.Num_Documento = num_Documento;
                usuario.Direccion = direccion;
                usuario.Telefono = telefono;
                usuario.Email = email;
                usuario.Clave = clave;
               // usuario.Estado = estado;

                return Datos.Crear(usuario);
            }

        }
        // Actualizar un usuario.
        public static string Actualizar(int idusuario, int idRol, string nombre, string num_Documento, string tipo_Documento,
           string direccion, string telefono, string email, string clave)
        {
            DUsuario Datos = new DUsuario();
            Usuario usuario = new Usuario();

            usuario.IdUsuario = idusuario;
            usuario.IdRol = idRol;
            usuario.Nombre = nombre;
            usuario.Tipo_Documento = tipo_Documento;
            usuario.Num_Documento = num_Documento;
            usuario.Direccion = direccion;
            usuario.Telefono = telefono;
            usuario.Email = email;
            usuario.Clave = clave;
            //usuario.Estado = estado;

            return Datos.Actualizar(usuario);


        }
        // Activar un usuario.
        public static string Activar(int id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Activar(id);
        }
        //Desactivar un usuario

        public static string Desactivar(int id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Desactivar(id);
        }

        public static string Eliminar(int id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Eliminar(id);
        }
        // Eliminar un usuario

       





        
















    }




}
