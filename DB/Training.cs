using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Training
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
