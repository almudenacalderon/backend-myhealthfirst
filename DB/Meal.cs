namespace DB
{
    public class Meal
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Desayuno { get; set; } = null!;
        public string Comida { get; set; } = null!;
        public string Media_mañana { get; set; } = null!;
        public string Cena { get; set; } = null!;
        public string Merienda { get; set; } = null!;
        public string ? Otros { get; set; }
        public string ? Post_entreno { get; set; }
        public string? Pre_entreno { get; set; }
        public int DietId { get; set; }
        public Diet Diet { get; set; } = null!;
       
    }
}
