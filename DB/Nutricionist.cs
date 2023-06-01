using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DB
{
    public class Nutricionist
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Nombre { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Email { get; set; } = null!;
        public List<Client>? Clients { get; set; } = new List<Client>();
        public List<Diet>? Diets { get; set; } = new List<Diet>();
    }
}
