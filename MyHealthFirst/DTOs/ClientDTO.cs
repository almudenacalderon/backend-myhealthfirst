using DB;

namespace MyHealthFirst.DTOs
{
    public class ClientDTO
    {
        public string Nombre { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public int ? Peso { get; set; } 
        public int ? Altura { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? Fecha_asignacion_dieta { get; set; }
        public DateTime? Fecha_asignacion_entrenamiento { get; set; }
        public int? TrainerId { get; set; }
        public int? NutricionistId { get; set; }

    }
}
