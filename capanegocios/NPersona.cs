using Sistema.Datos;
using Sistema.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocios
{
    public class NPersona
    {
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar();

        }
        // Listar proveedores
        public static DataTable ListarProveedores()
        {
            DPersona Datos = new DPersona();
            return Datos.ListarProveedores();

        }

        //Listar clientes 
        public static DataTable ListarClientes()
        {
            DPersona Datos = new DPersona();
            return Datos.ListarClientes();

        }


        // Buscar una o varios articulos 
        public static DataTable Buscar(string valor)
        {
            DPersona Datos = new DPersona();
            return Datos.Buscar(valor);

        }

        //Buscar proveedores 
        public static DataTable BuscarProveedores(string valor)
        {
            DPersona Datos = new DPersona();
            return Datos.BuscarProveedores(valor);

        }
        //Buscar clientes 
        public static DataTable BuscarClientes(string valor)
        {
            DPersona Datos = new DPersona();
            return Datos.BuscarClientes(valor);

        }

        // Insertar una o variaas persona 
        public static string Insertar( string nombre, string tipoPersona, string tipoDocumento,decimal num_Documento, string direccion, string telefono, string email)
        {
            DPersona Datos = new DPersona();
            Persona persona = new Persona();
            //antes debo verificar si existe el articulo
            string existe = Datos.Existe(nombre);
            if (existe == "1")
            {
                return "La Persona ya existe";
            }
            else
            {     //Constuir un articulo para enviarlo a datos y su metodo insertar 
                Persona obj = new Persona();
               // persona.TipoPersona = tipoPersona;
                persona.Nombre = nombre;
                persona.TipoPersona = tipoPersona;
                persona.TipoDocumento = tipoDocumento;
                persona.NumeroDocumento = num_Documento;
                persona.Direccion = direccion;
                persona.Telefono = telefono;
                persona.Email = email;
                return Datos.Insertar(persona);
            }


        }

        public static string Actualizar(int idPersona,string tipoPersona, string nombre, string tipoDocumento, decimal num_Documento, string direccion, string telefono, string email)
        {
            DPersona Datos = new DPersona();
            Persona persona = new Persona();
            //antes debo verificar si existe el articulo
            string existe = Datos.Existe(nombre);
           
              //Constuir un articulo para enviarlo a datos y su metodo insertar 
                Persona obj = new Persona();
                persona.IdPersona = idPersona;
                persona.TipoPersona = tipoPersona;
                persona.Nombre = nombre;
                persona.TipoDocumento = tipoDocumento;
                persona.NumeroDocumento= num_Documento;
                persona.Direccion = direccion;
                persona.Telefono = telefono;
                persona.Email = email;
                return Datos.Actualizar(persona);
            

        }
        public static string Eliminar(int id)
        {
            DPersona Datos = new DPersona();
            return Datos.Eliminar(id);


        }
    }
}
