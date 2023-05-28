namespace MyHealthFirst.DTOs
{
    public class TrainerDTO
    {
        public string Nombre { get; set; } = null!;
        public string ? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
    }
}
