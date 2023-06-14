namespace MyHealthFirst.DTOs
{
    public class DietDTO
    {
        public string Nombre { get; set; } = null!;
        public string? Comentarios { get; set; }
        public int ClientId { get; set; }
    }
}
