namespace DB
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Set { get; set; }
        public int Repeticiones { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; } = null!;

    }
}
