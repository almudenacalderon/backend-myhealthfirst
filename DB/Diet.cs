namespace DB
{
    public class Diet
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public int NutricionistId { get; set; }
        public Nutricionist Nutricionists { get; set; } = null!;
        public string? Comentarios { get; set; }
    }
}
