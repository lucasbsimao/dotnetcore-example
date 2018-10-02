using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;
using purchaseapp.Request.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using purchaseapp.Util;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System;

namespace purchaseapp.Controllers
{
    public class CartaoController : Controller{
    
        private readonly ILogger<HomeController> _logger;

        private ClientRequest _clientPost;
    
        public CartaoController(ILogger<HomeController> logger) {
            _logger = logger;
            _clientPost = new ClientRequest("https://apisandbox.braspag.com.br");
        }

        [HttpGet]
        public IActionResult Cartao()
        {
            var cartaoViewModel = new CartaoViewModel();
            var dadosCompra = HttpContext.Session.GetString("dadosCompra");

            if(dadosCompra != null){
            
                cartaoViewModel.ProdutoSelecionado = JsonConvert.DeserializeObject<Produto>(HttpContext.Session.GetString("produtoSelecionado"));

                cartaoViewModel.ListaQtdParcelas = this.PopularListaParcelas();
                cartaoViewModel.ListaBandeiras = this.PopularListaBandeiras();

                return View("~/Views/Compra/Cartao.cshtml",cartaoViewModel);
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
            var dadosCompra = this.PreencherDadosCompra(cartaoViewModel);
            _logger.LogWarning("TRETA 3: " + JsonConvert.SerializeObject(dadosCompra).ToString());
            var respostaCompra = _clientPost.RealizarAutorizacao(dadosCompra);

            var obj = JObject.Parse(respostaCompra);
            _logger.LogWarning(respostaCompra);
            return Autorizar((string)obj["Payment"]["PaymentId"]);
        }

        private Transaction PreencherDadosCompra(CartaoViewModel cartaoViewModel)
        {
            var produtoSelecionado = JsonConvert.DeserializeObject<Produto>(HttpContext.Session.GetString("produtoSelecionado"));
            var dadosCompra = JsonConvert.DeserializeObject<Transaction>(HttpContext.Session.GetString("dadosCompra"));
            
            dadosCompra.Payment = cartaoViewModel.Payment;
            dadosCompra.MerchantOrderId = produtoSelecionado.Id.ToString();
            dadosCompra.Payment.Amount = (int)(produtoSelecionado.Preco*100);
            dadosCompra.Payment.Country = dadosCompra.Customer.Address.Country;
            return dadosCompra;
        }

        [HttpGet]
        public IActionResult Autorizar(string purchaseId){
            _clientPost.RealizarCompra(purchaseId);

            AutorizarViewModel.PaymentId = purchaseId;

            _logger.LogWarning("Treta 4");

            return View("~/Views/Compra/Autorizar.cshtml",AutorizarViewModel.PaymentId);
        }

        [HttpPost]
        public IActionResult Cancelar(){
            _clientPost.RealizarCancelamento(AutorizarViewModel.PaymentId);

            return RedirectToAction("Produtos", "Home");
        }

    }
}