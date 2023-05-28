using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Meal
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public List<Diet> Diets { get; set; } = new List<Diet>();
       
    }
}
