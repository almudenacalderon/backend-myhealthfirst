namespace DB
{
    public class Training
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public int TrainerId { get; set; }
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
