using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;
using purchaseapp.Request.Models;
using purchaseapp.Util;

namespace purchaseapp.Controllers{
    public class CompraController : Controller{

        private readonly ILogger<CompraController> _logger;

        public CompraController(ILogger<CompraController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Comprar(){
            var comprarViewModel = new ComprarViewModel();
            var prodSelecionado = TempData["produtoSelecionado"];

            if(prodSelecionado != null){
                var produto = JsonConvert.DeserializeObject<Produto>(TempData["produtoSelecionado"].ToString());
            
                comprarViewModel.ProdutoSelecionado = produto;
                comprarViewModel.DadosComprador = new Transaction();

                comprarViewModel.ListaQtdParcelas = this.PopularListaParcelas();
                comprarViewModel.ListaBandeiras = this.PopularListaBandeiras();

                return View(comprarViewModel);
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
        public async Task<IActionResult> ComprarAsync(ComprarViewModel comprarViewModel){

            var clientPost = new ClientRequest("https://apisandbox.braspag.com.br");
            var taskCompra = clientPost.RealizarCompraAsync(comprarViewModel.DadosComprador);
            var respostaCompra = await taskCompra;

            _logger.LogWarning(respostaCompra);
            return View();
        }

    }
}