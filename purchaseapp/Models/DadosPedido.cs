using System.ComponentModel.DataAnnotations;
using purchaseapp.Request.Models;

namespace purchaseapp.Models{
    public class DadosPedido{

        public Produto ProdutoSelecionado { get; set; }

        public Transaction DadosComprador { get; set;}
    }
}