using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;
using purchaseapp.Request.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace purchaseapp.Controllers
{
    public class EnderecoController : Controller{
    
        private readonly ILogger<HomeController> _logger;
    
        public EnderecoController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Endereco()
        {
            var enderecoViewModel = new EnderecoViewModel();
            var modeloCompra = TempData["dadosPedido"];

            if(modeloCompra != null){
                var dadosPedido = JsonConvert.DeserializeObject<DadosPedido>(TempData["dadosPedido"].ToString());
            
                enderecoViewModel.DadosPedido = dadosPedido;
                enderecoViewModel.ListaNacoes = this.PopularListaIdentidades();

                return View("~/Views/Compra/Endereco.cshtml",enderecoViewModel);
            }else{
                return RedirectToAction("Produtos", "Home");
            }
        }

        private List<SelectListItem> PopularListaIdentidades()
        {
            var listaNacoes = new List<SelectListItem>();
            listaNacoes.Add(new SelectListItem {Value = "BRA" , Text = "BRASIL" });

            return listaNacoes;
        }

        [HttpPost]
        public IActionResult Endereco(EnderecoViewModel enderecoViewModel)
        {
            TempData["dadosPedido"] = JsonConvert.SerializeObject(enderecoViewModel.DadosPedido);

            return RedirectToAction("Cartao", "Cartao");
        }

    }
}