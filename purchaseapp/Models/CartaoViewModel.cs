using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Request.Models;
using purchaseapp.Request.Models.Transacao;

namespace purchaseapp.Models{
    public class CartaoViewModel{
        public Produto ProdutoSelecionado { get; set; }

        public Payment Payment { get; set; }

        public List<SelectListItem> ListaQtdParcelas { get; set; }

        public List<SelectListItem> ListaBandeiras { get; set; }
    }
}