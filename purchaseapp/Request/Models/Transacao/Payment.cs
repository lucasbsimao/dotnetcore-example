using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Request.Models.Transacao{
    public class Payment{

        [Required(ErrorMessage="Provedor não preenchido!")]
        public string Provider { get; set; }

        public string Type { get; set; }

        public int Amount { get; set; }

        public string Country { get; set; }

        public bool Capture { get; set; }

        [Range(1,99, ErrorMessage = "Parcelas devem ser entre 1 e 99.")]
        public int Installments { get; set; }

        public CreditCard CreditCard { get; set; }

        public Payment(){
            this.CreditCard = new CreditCard();
            this.Provider = "Simulado";
            this.Type = "CreditCard";
            this.Capture = true;
        }

    }
}