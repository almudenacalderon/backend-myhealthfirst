namespace MyHealthFirst.DTOs
{
    public class ClientDTO
    {
        public string Nombre { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int ? Peso { get; set; } 
        public int ? Altura { get; set; }
   
    }
}
