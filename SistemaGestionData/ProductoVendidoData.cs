using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {
        //conexion a la base de datos
        private static string connectionString = "Data Source=FO\\SQLEXPRESS;Initial Catalog=SistemaGestion;User ID=SA;Password=enterprise;";

        //Listar productos vendidos
        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                    IdVenta = Convert.ToInt32(reader["IdVenta"])
                                };

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar productos vendidos: " + ex.Message);
            }

            return productosVendidos;
        }

        //Obtener producto vendido por id
        public static ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            ProductoVendido productoVendido = new ProductoVendido();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productoVendido = new ProductoVendido
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                    IdVenta = Convert.ToInt32(reader["IdVenta"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener producto vendido por ID: " + ex.Message);
            }

            return productoVendido;
        }

        //Crear producto vendido
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@Stock, @IdProducto, @IdVenta)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                        command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                        command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear producto vendido: " + ex.Message);
            }
        }

        //Modificar producto vendido
        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE ProductoVendido SET Stock = @Stock, IdProducto = @IdProducto, IdVenta = @IdVenta WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", productoVendido.Id);
                        command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                        command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                        command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar producto vendido: " + ex.Message);
            }
        }

        //Eliminar producto vendido
        public static void EliminarProductoVendido(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM ProductoVendido WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto vendido: " + ex.Message);
            }
        }

        //Cerrar conexion
        public static void CerrarConexion()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar conexion: " + ex.Message);
            }
        }
    }
}
