using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using purchaseapp.Models;

namespace purchaseapp.Controllers
{
    public class HomeController : Controller{
    
        private readonly ILogger<HomeController> _logger;
    
        private List<Produto> _listaProdutos;
    
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
            _listaProdutos = new List<Produto>{
                new Produto { Id = 0, Nome = "Produto 1", Preco = 21.20F},
                new Produto { Id = 1, Nome = "Produto 2", Preco = 41.99F}
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

            return View("Comprar");
        }

        [HttpGet]
        public IActionResult Comprar(){
            return View();
        }

    }
}