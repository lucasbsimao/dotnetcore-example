using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Request.Models.Transacao{
    public class Customer{
        [Required(ErrorMessage="Nome não preenchido!")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres!")]
        public string Name { get; set; }
    }
}