using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;

namespace purchaseapp.Controllers
{
    public class HomeController : Controller{
    
        private readonly ILogger<HomeController> _logger;
    
        private List<Produto> _listaProdutos;
    
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
            _listaProdutos = new List<Produto>{
                new Produto { Id = 0, Nome = "PS4", Preco = 2100.20F},
                new Produto { Id = 1, Nome = "XBox One", Preco = 2500.00F}
            };
        }

        [HttpGet]
        public IActionResult Produtos(){

            ProdutosViewModel produtosModel = new ProdutosViewModel{
                ListaProdutos = _listaProdutos
            };

            return View(produtosModel);
        }

        [HttpPost]
        public IActionResult Produtos(ProdutosViewModel produtosModel){
              
            int idProd = int.Parse(produtosModel.ProdutoSelecionado);

            Produto produto = _listaProdutos[idProd];
            
            TempData["produtoSelecionado"] = JsonConvert.SerializeObject(produto);

            return RedirectToAction("Comprar", "Compra");
        }

    }
}