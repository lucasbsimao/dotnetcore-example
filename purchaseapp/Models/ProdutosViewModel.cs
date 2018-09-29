using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Models{
    public class ProdutosViewModel{

        [Required(ErrorMessage="Necessário selecionar uma opção para executar a compra!")]
        public string ProdutoSelecionado { get; set; }

        public List<Produto> ListaProdutos { get; set; }
    }
}