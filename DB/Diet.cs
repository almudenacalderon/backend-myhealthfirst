namespace DB
{
    public class Diet
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public  List<Meal>? Meals { get; set; } = new List<Meal>();
        public List<Nutricionist>? Nutricionists { get; set; } = new List<Nutricionist>();
    }
}
