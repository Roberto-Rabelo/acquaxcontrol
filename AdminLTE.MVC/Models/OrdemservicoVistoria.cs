using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    [Table("OrdemservicoVistoria")]
    public class OrdemservicoVistoria
    {
        public int OrdemservicoVistoriaId { get; set; }

        [Required]
        [Display(Name = "Data da solicitação")]
        [DataType(DataType.Date)]
        public DateTime dt_solicitacao { get; set; }

        [Display(Name = "Data de execução")]
        [DataType(DataType.Date)]
        public DateTime dt_agendada { get; set; }

        [Display(Name = "Data de execução")]
        [DataType(DataType.Date)]
        public DateTime dt_execucao { get; set; }

        [Display(Name = "Novo Cliente")]
        public string condominioNovo { get; set; }

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

        // Check list 
        [Display(Name = "Hidrometro vencido")]
        public string hidrometroVencido { get; set; }

        [Display(Name = "Teste de baixa Vazao ")]
        public string baixaVazao { get; set; }

        [Display(Name = "Vazamento torneira cozinha? ")]
        public string torneiraCozinha { get; set; }

        [Display(Name = "Vazamento torneira Tanque? ")]
        public string torneiraTanque { get; set; }
        [Display(Name = "Vazamento torneira Lavabo? ")]
        public string torneiraLavabo { get; set; }

        [Display(Name = "Vazamento Descarga Lavabo? ")]
        public string descargaLavabo { get; set; }

        //Banheiro 01
        [Display(Name = " Vazamento chuveiro Banheiro 01 ?")]
        public string chuveiroBanheiro01 { get; set; }

        [Display(Name = "Vazamento torneira Banheiro 01 ?")]
        public string torneiraBanheiro01 { get; set; }

        [Display(Name = "Vazamento descarga Banheiro 01 ?")]
        public string descargaBanheiro01 { get; set; }

        //Banheiro 02
        [Display(Name = "Vazamento chuveiro Banheiro 02 ?")]
        public string chuveiroBanheiro02 { get; set; }

        [Display(Name = "Vazamento torneira Banheiro 02 ?")]
        public string torneiraBanheiro02 { get; set; }

        [Display(Name = "Vazamento descarga Banheiro 02 ?")]
        public string descargaBanheiro02 { get; set; }

        //Banheiro 03
        [Display(Name = "Vazamento chuveiro Banheiro 03 ?")]
        public string chuveiroBanheiro03 { get; set; }

        [Display(Name = "Vazamento torneira Banheiro 03 ?")]
        public string torneiraBanheiro03 { get; set; }

        [Display(Name = "Vazamento descarga Banheiro 03 ?")]
        public string descargaBanheiro03 { get; set; }

        //Banheiro 04
        [Display(Name = "Vazamento chuveiro Banheiro 04 ?")]
        public string chuveiroBanheiro04 { get; set; }

        [Display(Name = "Vazamento torneira Banheiro 04 ?")]
        public string torneiraBanheiro04 { get; set; }

        [Display(Name = "Vazamento descarga Banheiro 04 ?")]
        public string descargaBanheiro04 { get; set; }



        //considerações finais 

        [Display(Name = "Anexa Foto 0")]
        public string FotoPath { get; set; }

        [Display(Name = "anexa Foto 1")]
        public string FotoPath1 { get; set; }


        [Display(Name = "Anexa Foto 2")]
        public string FotoPath3 { get; set; }


        [Display(Name = "Anexa Foto 3")]
        public string FotoPath4 { get; set; }

        [Display(Name = "Observações sobre vistoria")]
        public string observacao { get; set; }

        [Display(Name = "Responsavél técnico pela vistoria")]
        public string IdAspNetUsers { get; set; }

        [Display(Name = "Assinatura cliente")]
        public string assinaturaCliente { get; set; }

        [Display(Name = "Status do serviço")]
        public string status { get; set; }

        [Display(Name = "Conclusão da vistoria")]
        public string conclusao { get; set; }
        public string tipoVistoria { get; set; }

        [Display(Name = "Cliente já cadastrado")]
        public int condominioId { get; set; }
        public virtual Condominio Condominio { get; set; }


    }
}
