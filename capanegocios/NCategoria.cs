using Sistema.Entidad;
using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{

    public class NCategoria
    {
        public static DataTable Listar()
        {
            DCategoria Datos = new DCategoria();
            return Datos.Listar();

        }
        // Buscar una o varias categoria 
        public static DataTable Buscar(string valor)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Buscar(valor);

        }
        // Insertar una o varias categoria 
        public static String Insertar(string nombre, string descripcion)
        {
            DCategoria Datos = new DCategoria();
            Categoria categoria = new Categoria();
            //antes debo verificar si existe la categoria 
            string existe = Datos.Existe(nombre);
            if (existe == "1")
            {
                return "La categoria ya existe";
            }
            else
            {
                categoria.Nombre = nombre;
                categoria.Descripcion = descripcion;
                return Datos.Insertar(categoria);
            }


        }
        public static string Actualizar(int id, string nombre, string descripcion)
        {
            DCategoria Datos = new DCategoria();
            Categoria categoria = new Categoria();

            categoria.IdCategoria = id;
            categoria.Nombre = nombre.Trim();
            categoria.Descripcion = descripcion.Trim();

            return Datos.Actualizar(categoria);


        }
        public static string Eliminar(int id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Eliminar(id);


        }
        public static string Activar(int id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Activar(id);
        }
        public static string Desactivar(int id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Desactivar(id);
        }
        public static DataTable ListarCategoriasArticulos()
        {
            DCategoria Datos = new DCategoria();
            return Datos.ListarCategoriasArticulos();


        }
    }

}
