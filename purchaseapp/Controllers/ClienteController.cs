using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using purchaseapp.Models;
using purchaseapp.Request.Models;
using purchaseapp.Util;

namespace purchaseapp.Controllers{
    public class ClienteController : Controller{

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Cliente(){
            var clienteViewModel = new ClienteViewModel();
            var prodSelecionado = HttpContext.Session.GetString("produtoSelecionado");

            if(prodSelecionado != null){
                var produto = JsonConvert.DeserializeObject<Produto>(prodSelecionado.ToString());
                
                clienteViewModel.ProdutoSelecionado = produto;

                clienteViewModel.ListaIdentidades = this.PopularListaIdentidades();

                return View("~/Views/Compra/Cliente.cshtml",clienteViewModel);
            }else{
                return RedirectToAction("Produtos", "Home");
            }
        }

        private List<SelectListItem> PopularListaIdentidades()
        {
            var listaBandeiras = new List<SelectListItem>();
            listaBandeiras.Add(new SelectListItem {Value = "RG" , Text = "RG" });
            listaBandeiras.Add(new SelectListItem {Value = "CPF" , Text = "CPF" });

            return listaBandeiras;
        }

        [HttpPost]
        public IActionResult Cliente(ClienteViewModel clienteViewModel)
        {
            var dadosCompra = new Transaction();
            dadosCompra.Customer = clienteViewModel.Customer;

            HttpContext.Session.SetString("dadosCompra", JsonConvert.SerializeObject(dadosCompra));
            _logger.LogWarning("TRETA: " + JsonConvert.SerializeObject(dadosCompra).ToString());
            return RedirectToAction("Endereco", "Endereco");
        }
    }
}