using Microsoft.AspNetCore.Identity;

namespace DB
{
    public class Trainer
    {
  
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Nombre { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Email { get; set; } = null!;
        public int? ClientId { get; set; }
        public  List<Client>? Clients { get; set; } = new List<Client>();
        public int? TrainingId { get; set; }
        public List<Training>? Training { get; set; } = new List<Training>();
    }
}
