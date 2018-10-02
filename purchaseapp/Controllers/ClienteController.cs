using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private ClientRequest _clientPost;

        public ClienteController(ILogger<ClienteController> logger) {
            _logger = logger;
            _clientPost = new ClientRequest("https://apisandbox.braspag.com.br");
        }

        [HttpGet]
        public IActionResult Cliente(){
            var clienteViewModel = new ClienteViewModel();
            var prodSelecionado = TempData["produtoSelecionado"];

            if(prodSelecionado != null){
                var produto = JsonConvert.DeserializeObject<Produto>(TempData["produtoSelecionado"].ToString());
            
                clienteViewModel.DadosPedido.ProdutoSelecionado = produto;
                clienteViewModel.DadosPedido.DadosComprador = new Transaction();
                
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
            TempData["dadosPedido"] = JsonConvert.SerializeObject(clienteViewModel.DadosPedido);

            return RedirectToAction("Endereco", "Endereco");
        }

        // [HttpPost]
        // public IActionResult Cartao(ComprarViewModel comprarViewModel)
        // {
        //     comprarViewModel.DadosComprador.MerchantOrderId = "000000000";
            
        //     var respostaCompra = _clientPost.RealizarAutorizacao(comprarViewModel.DadosComprador);

        //     var obj = JObject.Parse(respostaCompra);
        //     _logger.LogWarning(respostaCompra);
        //     return Autorizar((string)obj["Payment"]["PaymentId"]);
        // }

        // [HttpGet]
        // public IActionResult Autorizar(string purchaseId){
        //     _clientPost.RealizarCompra(purchaseId);

        //     return View(purchaseId);
        // }

        // [HttpPost]
        // public IActionResult Cancelar(string purchaseId){
        //     _clientPost.RealizarCancelamento(purchaseId);

        //     return View(purchaseId);
        // }

    }
}