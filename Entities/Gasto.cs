namespace FinanzasPersonales.Entities
{
    public class Gasto
    {
        public int Id { get; set; }       // Clave primaria
        public required string Categoria { get; set; }  // Categoría del gasto
        public string Nombre { get; set; }
        public decimal Monto { get; set; }  // Monto del gasto
        public required DateTime Fecha { get; set; }  // Fecha del gasto
        public required string Descripción { get; set; }
    }
}
