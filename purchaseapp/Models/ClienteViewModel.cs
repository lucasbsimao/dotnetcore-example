using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Request.Models;

namespace purchaseapp.Models{
    public class ClienteViewModel{
        public DadosPedido DadosPedido { get; set; }

        public List<SelectListItem> ListaIdentidades { get; set; }
    
        public ClienteViewModel(){
            this.DadosPedido = new DadosPedido(); 
        }
    }
}