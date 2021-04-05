using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    [Table("Bloco")]
    public class Blocos
    {
        public int BlocosId { get; set; }

        [Display(Name = "Bloco")]
        [Required]
        [StringLength(50)]
        public string Bloco { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(50)]
        public string Descricao { get; set; }
       
       
        [Display(Name = "Condominio")]
        public int CondominioId { get; set; }
        public virtual Condominio Condominio { get; set; }

        public virtual List<Apartamento> Apartamentos { get; set; }
        public virtual List<AguaCondominio> AguaCondominios { get; set; }
    }
}
