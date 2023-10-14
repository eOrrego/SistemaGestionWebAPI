using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class VentaData
    {
        //conexion a la base de datos
        private static string connectionString = "Data Source=FO\\SQLEXPRESS;Initial Catalog=SistemaGestion;User ID=SA;Password=enterprise;";

        //Listar ventas
        public static List<Venta> ListarVentas()
        {
            List<Venta> ventas = new List<Venta>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Comentarios, IdUsuario FROM Venta";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Comentarios = reader["Comentarios"].ToString(),
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                                };

                                ventas.Add(venta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar ventas: " + ex.Message);
            }

            return ventas;
        }

        //Obtener venta por id
        public static Venta ObtenerVentaPorId(int id)
        {
            Venta venta = new Venta();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                venta = new Venta
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Comentarios = reader["Comentarios"].ToString(),
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener venta por ID: " + ex.Message);
            }

            return venta;
        }

        //Crear venta
        public static void CrearVenta(Venta venta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear venta: " + ex.Message);
            }
        }

        //Modificar venta
        public static void ModificarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", venta.Id);
                        command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar venta: " + ex.Message);
            }
        }

        //Eliminar venta
        public static void EliminarVenta(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Venta WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar venta: " + ex.Message);
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
