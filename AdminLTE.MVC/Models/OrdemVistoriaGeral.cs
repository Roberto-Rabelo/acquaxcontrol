using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    public class OrdemVistoriaGeral
    {
        public int OrdemVistoriaGeralId { get; set; }
        [Required]
        [Display(Name = "Data da solicitação")]
        [DataType(DataType.Date)]
        public DateTime dt_solicitacao { get; set; }

        [Required]
        [Display(Name = "Data Agendada")]
        [DataType(DataType.Date)]
        public DateTime dt_agendada { get; set; }

        [Display(Name = "Data de execução")]
        [DataType(DataType.Date)]
        public DateTime dt_execucao { get; set; }


        
        [Display(Name = "Qual Especificação?")]
       
        public string especificacao { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Bairro do condominio")]
        public string bairro { get; set; }
        [Required]
        [Display(Name = "Email do Cliente")]
        public string emailCliente { get; set; }

        [Display(Name = "Nome Completo do cliente")]
        public string nomeCliente { get; set; }
        [Required]
        [Display(Name = "Documento de identificação do cliente")]
        public double documento { get; set; }

        [Required]
        [Display(Name = "Qual bloco ?")]
        public int bloco { get; set; }
        
        [Required]
        [Display(Name = "Qual unidade ?")]
        public int unidade { get; set; }


        [Display(Name = "Observações sobre execução")]
        public string observacao { get; set; }

        [Display(Name = "Responsavél técnico pela vistoria")]
        public string IdAspNetUsers { get; set; }

        [Display(Name = "Assinatura cliente")]
        public string assinaturaCliente { get; set; }

        [Display(Name = "Forma de pagamento")]
        public string formaPagamento { get; set; }

        [Display(Name = "Valor da Serviço")]
        public double valor { get; set; }

        [Display(Name = "Recebeu em mãos ?")]
        public string pago { get; set; }

        [Display(Name = "Status do serviço")]
        public string status { get; set; }

        [Display(Name = "Anexa Foto 01")]
        public string FotoPath01 { get; set; }

        [Display(Name = "Conclusao da vistoria")]
        public string conclusao { get; set; }
        public string tipoVistoria { get; set; }

        [Display(Name = "Cliente já cadastrado")]
        public int condominioId { get; set; }
        public virtual Condominio Condominio { get; set; }
    }
}
