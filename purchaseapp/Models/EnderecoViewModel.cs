using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Request.Models;

namespace purchaseapp.Models{
    public class EnderecoViewModel{
        public DadosPedido DadosPedido { get; set; }

        public List<SelectListItem> ListaNacoes { get; set; }
    }
}