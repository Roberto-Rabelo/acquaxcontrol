using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    public class HidroAutoSigfox
    {

        
        public int HidroAutoSigfoxId { get; set; }

        [Display(Name = "Data")]
        
        public DateTime data { get; set; }

        [Display(Name = "Dispositivo")]
        [Required]
        [StringLength(150)]

        public string device { get; set; }

        [Display(Name = "Nome dispostivo")]
        [StringLength(150)]
        public string nome { get; set; }

        [Display(Name = "rawdata")]
        [StringLength(150)]
        public string rawdata { get; set; }


        [Display(Name = "Bateria")]
        public UInt16 battery { get; set; }

        [Display(Name = "Temperatura")]
        public UInt16 temperature { get; set; }

        [Display(Name = "Humidade")]
        public UInt16 humidity { get; set; }

        [Display(Name = "counter01")]
        public UInt16 counter01 { get; set; }

        [Display(Name = "counter02")]
        public UInt16 counter02 { get; set; }

        [Display(Name = "counter03")]
        public UInt16 counter03 { get; set; }

        [Display(Name = "email")]
        public string email { get; set; }

        [Display(Name = "email convidado")]
        public string emailConvidado { get; set; }
    }
}
