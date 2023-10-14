using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class VentaBusiness
    {
        //listar ventas
        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }

        //obtener venta por id
        public static Venta ObtenerVentaPorId(int id)
        {
            return VentaData.ObtenerVentaPorId(id);
        }

        //crear venta
        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }

        //modificar venta
        public static void ModificarVenta(Venta venta)
        {
            VentaData.ModificarVenta(venta);
        }

        //eliminar venta
        public static void EliminarVenta(int id)
        {
            VentaData.EliminarVenta(id);
        }
    }
}
