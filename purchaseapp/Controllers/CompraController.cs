using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;

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
                comprarViewModel.DadosComprador = new DadosCompra();

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
        public IActionResult Comprar(ComprarViewModel comprarViewModel){
            _logger.LogWarning("Arue aruo: "+ comprarViewModel.DadosComprador.NomeCompleto );
            return View();
        }

    }
}