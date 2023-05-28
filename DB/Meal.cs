﻿namespace DB
{
    public class Meal
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Desayuno { get; set; }
        public string Comida { get; set; }
        public string Media_mañana { get; set; }
        public string Cena { get; set; }
        public string Merienda { get; set; }
        public string ? Otros { get; set; }
        public string ? Post_entreno { get; set; }
        public string? Pre_entreno { get; set; }
        public int? DietId { get; set; }
        public List<Diet>? Diets { get; set; } = new List<Diet>();
       
    }
}
