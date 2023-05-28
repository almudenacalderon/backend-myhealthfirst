using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
