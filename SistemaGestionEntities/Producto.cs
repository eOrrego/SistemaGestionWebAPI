namespace SistemaGestionEntities
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Descripciones { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
