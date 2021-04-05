using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    [Table("Hidrometro")]
    public class Hidrometro
    {
        public int HidrometroId { get; set; }
        public double NumeroHidrometro { get; set; }
        public double? pulsoHidrometro { get; set; }
        public double? Acumulador { get; set; }
        public string Device { get; set; }
    }
}
