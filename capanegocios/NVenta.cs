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
    public class NVenta
    {
        public static DataTable Listar()
        {
            DVenta Datos = new DVenta();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DVenta Datos = new DVenta();
            return Datos.Buscar(Valor);
        }

        public static DataTable ListarDetalle(int Id)
        {
            DVenta Datos = new DVenta();
            return Datos.ListarDetalle(Id);
        }

        public static string Insertar(int IdCliente, int IdUsuario, string TipoComprobante, string SerieComprobante, string NumComprobante, decimal Impuesto, decimal Total, DataTable Detalles)
        {
            DVenta Datos = new DVenta();
            Ventas Obj = new Ventas();
            Obj.IdCliente  = IdCliente;
            Obj.IdUsuario = IdUsuario;
            Obj.TipoComprobante = TipoComprobante;
            Obj.SerieComprobante = SerieComprobante;
            Obj.NumComprobante = NumComprobante;
            Obj.Impuesto = Impuesto;
            Obj.Total = Total;
            Obj.Detalles = Detalles;
            return Datos.Insertar(Obj);
        }
        public static string Anular(int Id)
        {
            DVenta Datos = new DVenta();
            return Datos.Anular(Id);
        }


    }
}
