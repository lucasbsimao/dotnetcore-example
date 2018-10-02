using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Request.Models;
using purchaseapp.Request.Models.Transacao;

namespace purchaseapp.Models{
    public class EnderecoViewModel{

        public Produto ProdutoSelecionado { get; set; }

        public Address Address { get; set; }

        public List<SelectListItem> ListaNacoes { get; set; }

        public List<SelectListItem> ListaUf { get; set; }
    }
}