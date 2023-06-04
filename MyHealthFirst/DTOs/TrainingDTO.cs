using DB;

namespace MyHealthFirst.DTOs
{
    public class TrainingDTO
    {
        public string Nombre { get; set; } = null!;
        public List<int> Exercises { get; set; } = new List<int>();
    }
}
