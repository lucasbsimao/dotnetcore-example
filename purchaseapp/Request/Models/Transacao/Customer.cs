using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Request.Models.Transacao{
    public class Customer{
        [Required(ErrorMessage="Nome não preenchido!")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres!")]
        public string Name { get; set; }

        public string Identity { get; set; }

        public string IdentityType { get; set; }

        public string Email { get; set; }

        public string Birthdate { get; set; }

        public Address Address { get; set; }
    }
}