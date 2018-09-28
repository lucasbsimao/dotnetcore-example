using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using purchaseapp.Models;

namespace purchaseapp.Controllers
{
    public class HomeController : Controller{

        public IActionResult Index(){
            var produtos = new List<Produto>{
                new Produto { Id = 1, Nome = "Produto 1", Preco = 21.20F},
                new Produto { Id = 2, Nome = "Produto 2", Preco = 41.99F}
            };

            return View(produtos);
        }

    }
}