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
    public class NArticulo
    {
        public static DataTable Listar()
        {
            DArticulo Datos = new DArticulo();
            return Datos.Listar();

        }
        // Buscar una o varios articulos 
        public static DataTable Buscar(string valor)
        {
            DArticulo Datos = new DArticulo();
            return Datos.Buscar(valor);

        }
        public static DataTable BuscarCodigo(string valor)
        {
            DArticulo Datos = new DArticulo();
            return Datos.BuscarCodigo(valor);

        }



        // Insertar una o varios articulos
        public static string Insertar(int idCategoria, string codigo, string nombre,decimal precioVenta, int stock, string descripcion, string imagen )
        {
            DArticulo Datos = new DArticulo();
            Articulo articulo = new Articulo();
            //antes debo verificar si existe el articulo
            string existe = Datos.Existe(nombre);
            if (existe == "1")
            {
                return "El articulo ya existe";
            }
            else
            {     //Constuir un articulo para enviarlo a datos y su metodo insertar 
                articulo.IdCategoria = idCategoria;
                articulo.Codigo = codigo;
                articulo.Nombre = nombre;
                articulo.PrecioVenta = precioVenta;
                articulo.Stock = stock;
                articulo.Descripcion = descripcion;
                articulo.Imagen = imagen;
                return Datos.Insertar(articulo);
            }


        }
        public static string Actualizar( int idArticulo, int idCategoria, string codigo, string nombre, decimal precioVenta, int stock, string descripcion, string imagen)
        {
            DArticulo Datos = new DArticulo();
            Articulo articulo = new Articulo();

            articulo.IdArticulo = idArticulo;
            articulo.IdCategoria = idCategoria;
            articulo.Codigo = codigo;
            articulo.Nombre = nombre;
            articulo.PrecioVenta = precioVenta;
            articulo.Stock = stock;
            articulo.Descripcion = descripcion;
            articulo.Imagen = imagen;
           

            return Datos.Actualizar(articulo);


        }
        public static string Eliminar(int id)
        {
            DArticulo Datos = new DArticulo();
            return Datos.Eliminar(id);


        }
        public static string Activar(int id)
        {
            DArticulo Datos = new DArticulo();
            return Datos.Activar(id);
        }
        public static string Desactivar(int id)
        {
            DArticulo Datos = new DArticulo();
            return Datos.Desactivar(id);
        }
    }
}
