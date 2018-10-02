using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;
using purchaseapp.Request.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace purchaseapp.Controllers
{
    public class CartaoController : Controller{
    
        private readonly ILogger<HomeController> _logger;
    
        public CartaoController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Cartao()
        {
            var cartaoViewModel = new CartaoViewModel();
            var modeloCompra = TempData["dadosPedido"];

            if(modeloCompra != null){
                var dadosPedido = JsonConvert.DeserializeObject<DadosPedido>(TempData["dadosPedido"].ToString());
            
                cartaoViewModel.DadosPedido = dadosPedido;
                cartaoViewModel.ListaQtdParcelas = this.PopularListaParcelas();
                cartaoViewModel.ListaBandeiras = this.PopularListaBandeiras();

                return View("~/Views/Compra/Endereco.cshtml",cartaoViewModel);
            }else{
                return RedirectToAction("Produtos", "Home");
            }
        }

         private List<SelectListItem> PopularListaParcelas()
        {
            var listaParcelas = new List<SelectListItem>();
            for(int i = 1; i <= 12; i++){
                listaParcelas.Add(new SelectListItem {Value = i.ToString() , Text = i.ToString() });
            }

            return listaParcelas;
        }

        private List<SelectListItem> PopularListaBandeiras()
        {
            var listaBandeiras = new List<SelectListItem>();
            listaBandeiras.Add(new SelectListItem {Value = "Visa" , Text = "Visa" });
            listaBandeiras.Add(new SelectListItem {Value = "MasterCard" , Text = "MasterCard" });

            return listaBandeiras;
        }

        [HttpPost]
        public IActionResult Cartao(CartaoViewModel cartaoViewModel)
        {
            TempData["dadosPedido"] = JsonConvert.SerializeObject(cartaoViewModel.DadosPedido);

            return RedirectToAction("Cartao", "Cartao");
        }

    }
}