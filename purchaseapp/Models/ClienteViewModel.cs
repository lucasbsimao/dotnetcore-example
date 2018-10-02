using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Request.Models;
using purchaseapp.Request.Models.Transacao;

namespace purchaseapp.Models{
    public class ClienteViewModel{

        public Produto ProdutoSelecionado { get; set; }

        public Customer Customer { get; set; }

        public List<SelectListItem> ListaIdentidades { get; set; }
    
    }
}