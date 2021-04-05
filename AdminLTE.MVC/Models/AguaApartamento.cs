using AdminLTE.MVC.Areas.Identity.Pages.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace AdminLTE.MVC.Models
{
    [Table("AguaApartamento")]
    public class AguaApartamento
    {
        public int AguaApartamentoId { get; set; }
        [DataType(DataType.Date)]
        //public DateTime dt_leitura_ant { get; set; }
        [Display(Name = "Data da leitura atual ")]
        public DateTime dt_leitura_atual { get; set; }
        [DataType(DataType.Date)]
        //public DateTime dt_leitura_ant { get; set; }
        [Display(Name = "Data da leitura anterior")]
        public DateTime dt_leitura_anterior { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data da proxima leitura")]
        public DateTime dt_leitura_proxima { get; set; }

        [Display(Name = "Bloco")]
        public string bloco { get; set; }

        [Display(Name = "Unidade")]
        public int Unidade { get; set; }

        [Display(Name = "Leitura anterior")]
        public double mes_anterior { get; set; }

        [Display(Name = "Leitura atual")]
        public double mes_atual { get; set; }

        [Display(Name = "Volume Consumido")]
        public double volume_consumido{ get; set; }

        [Display(Name = "Valor agua")]
        public double vlr_agua { get; set; }

        [Display(Name = "Valor esgoto")]
        public double vlr_esgoto { get; set; }

        [Display(Name = "Area comum")]
        public double area_comum { get; set; }

        [Display(Name = "Total unidade")]
        public double total_unidade { get; set; }

        [Display(Name = "Total unidade condominio")]
        public double total_unidade_condominio { get; set; }

        [Display(Name = "Total valor agua condominio")]
        public double total_valor_condominio { get; set; }

        [Display(Name = "Tarifa aplicada")]
        public string tarifa { get; set; }

        [Display(Name = "Foto")]
        public string FotoPath { get; set; }

        

        [Display(Name = "Nome do hóspede")]
        public int ApartamentoId { get; set; }
        public virtual Apartamento Apartamento { get; set; }


       

       /// public virtual List<LoginModel> AspNetUsers { get; set; }
    }
}
