namespace DB
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Set { get; set; }
        public int Repeticiones { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();

    }
}
