namespace FinanzasPersonales.DTOs
{
    public class GastoDto
    {
        public int Id { get; set; }
        public required string Categoria { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public required string Detalle { get; set; }
    }
}
