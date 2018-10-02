using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Request.Models;

namespace purchaseapp.Models{
    public class CartaoViewModel{
        public DadosPedido DadosPedido { get; set; }

        public List<SelectListItem> ListaQtdParcelas { get; set; }

        public List<SelectListItem> ListaBandeiras { get; set; }
    }
}