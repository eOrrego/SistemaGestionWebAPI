using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class ProductoVendidoBusiness
    {
        //listar productos vendidos
        public static List<ProductoVendido> ListarProductosVendidos()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }

        //obtener producto vendido por id
        public static ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendidoPorId(id);
        }

        //crear producto vendido
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.CrearProductoVendido(productoVendido);
        }

        //modificar producto vendido
        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        //eliminar producto vendido
        public static void EliminarProductoVendido(int id)
        {
            ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}
