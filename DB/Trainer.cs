using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public string Password { get; set; } = null!;
        public  List<Client>? Clients { get; set; } = new List<Client>();
        public List<Training> Training { get; set; } = new List<Training>();
    }
}
