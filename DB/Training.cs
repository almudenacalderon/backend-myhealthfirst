namespace DB
{
    public class Training
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public string? Comentarios { get; set; }
    }
}
