using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        private static string connectionString = "Data Source=FO\\SQLEXPRESS;Initial Catalog=SistemaGestion;User ID=SA;Password=enterprise;";

        //Listar productos
        public static List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Descripciones = reader["Descripciones"].ToString(),
                                    Costo = Convert.ToDecimal(reader["Costo"]),
                                    PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                                };

                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar productos: " + ex.Message);
            }

            return productos;
        }

        //Obtener producto por id
        public static Producto ObtenerProductoPorId(int id)
        {
            Producto producto = new Producto();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                producto = new Producto
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Descripciones = reader["Descripciones"].ToString(),
                                    Costo = Convert.ToDecimal(reader["Costo"]),
                                    PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener producto por ID: " + ex.Message);
            }

            return producto;
        }

        //Crear producto
        public static void CrearProducto(Producto producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        command.Parameters.AddWithValue("@Costo", producto.Costo);
                        command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear producto: " + ex.Message);
            }
        }

        //Modificar producto
        public static void ModificarProducto(Producto producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", producto.Id);
                        command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        command.Parameters.AddWithValue("@Costo", producto.Costo);
                        command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar producto: " + ex.Message);
            }
        }

        //Eliminar producto
        public static void EliminarProducto(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Producto WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto: " + ex.Message);
            }
        }

        //Cerrar Conexion con la base de datos
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
