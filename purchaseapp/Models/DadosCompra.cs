using System;
using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Models{
    public class DadosCompra{

        public Guid MerchantId { get; } = new Guid("");

        public string MerchantKey { get; } = "";

        [Required(ErrorMessage="Nome não preenchido!")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage="Provedor não preenchido!")]
        public string Provedor { get; set; } = "Simulado";

        public string TipoPagamento { get; set; } = "CreditCard";

        public float ValorProduto { get; set; }

        [Range(1,99, ErrorMessage = "Parcelas devem ser entre 1 e 99.")]
        public int QtdParcelas { get; set; }

        [Required(ErrorMessage="Número do cartão não preenchido!")]
        [DisplayFormat(DataFormatString="{####-####-####-####}", ApplyFormatInEditMode = true)]
        public string NumCartao { get; set; }

        [StringLength(25, ErrorMessage = "Nome no cartão deve ter no máximo 25 caracteres!")]
        public string NomeCartao { get; set; }

        [DisplayFormat(DataFormatString="{##/##/####}", ApplyFormatInEditMode = true)]
        public string DataValidade { get; set; }

        [Range(1,4, ErrorMessage = "Código de segurança deve ser entre 1 e 4 dígitos.")]
        public int CodSeguranca { get; set; }

        [Required(ErrorMessage="Bandeira do cartão não preenchida!")]
        public string BandeiraCartao { get; set; }

    }
}