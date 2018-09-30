using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace purchaseapp.Models{
    public class ComprarViewModel{
        public Produto ProdutoSelecionado { get; set; }

        public DadosCompra DadosComprador {get; set;}

        public List<SelectListItem> ListaQtdParcelas { get; set; }

        public List<SelectListItem> ListaBandeiras { get; set; }
    }
}