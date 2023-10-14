using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class ProductoBusiness
    {

        //listar productos
        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        //obtener producto por id
        public static Producto ObtenerProductoPorId(int id)
        {
            return ProductoData.ObtenerProductoPorId(id);
        }

        //crear producto
        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        //modificar producto
        public static void ModificarProducto(Producto producto)
        {
            ProductoData.ModificarProducto(producto);
        }

        //eliminar producto
        public static void EliminarProducto(int id)
        {
            ProductoData.EliminarProducto(id);
        }

    }
}
