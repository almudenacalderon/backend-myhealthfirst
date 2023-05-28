using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DB
{
    public class Client
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Nombre { get; set; } = null!;
        public string ? PhoneNumber { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Email { get; set; } = null!;
        public DateTime ? Fecha_asignacion_dieta { get; set; }
        public DateTime ? Fecha_asignacion_entrenamiento { get; set; }
        public int ? Peso { get; set; } 
        public int ? Altura { get; set; }
        public int? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        public int? NutricionistId { get; set; }
        public Nutricionist? Nutricionist { get; set; } 
       
    }
}
