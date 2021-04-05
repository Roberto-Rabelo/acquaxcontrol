using AdminLTE.MVC.Areas.Identity.Pages.Account;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE.MVC.Models
{
    [Table("Apartamento")]
    public class Apartamento
    {
        public int ApartamentoId { get; set; }

        [Required]
        [Display(Name = "Nome")]

        public string Nome { get; set; }

        [Required]
        [Display(Name = "Numero do apt")]
        public int apartamentos { get; set; }

        
        

        public string IdAspNetUsers { get; set; }

        

        [Display(Name = "Bloco")]
        public int BlocosId { get; set; }
        public virtual Blocos Blocos { get; set; }

        // public virtual List<LoginModel> AspNetUsers { get; set; }
        public virtual List<AguaApartamento> AguaApartamento
        {
            get; set;
        }
    }
}
