using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Request.Models.Transacao{
    public class CreditCard{

        [Required(ErrorMessage="Número do cartão não preenchido!")]
        public string CardNumber { get; set; }

        [StringLength(25, ErrorMessage = "Nome no cartão deve ter no máximo 25 caracteres!")]
        public string Holder { get; set; }

        [DisplayFormat(DataFormatString="{##/##/####}", ApplyFormatInEditMode = true)]
        public string ExpirationDate { get; set; }

        [Range(1,4, ErrorMessage = "Código de segurança deve ser entre 1 e 4 dígitos.")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage="Bandeira do cartão não preenchida!")]
        public string Brand { get; set; }

    }
}