using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using purchaseapp.Models;
using purchaseapp.Request.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

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
            var dadosCompra = HttpContext.Session.GetString("dadosCompra");

            if(dadosCompra != null){
                var enderecoViewModel = new EnderecoViewModel();
            
                enderecoViewModel.ProdutoSelecionado = JsonConvert.DeserializeObject<Produto>(HttpContext.Session.GetString("produtoSelecionado"));
                
                enderecoViewModel.ListaNacoes = this.PopularListaNacoes();
                enderecoViewModel.ListaUf = this.PopularListaUfs();

                return View("~/Views/Compra/Endereco.cshtml",enderecoViewModel);
            }else{
                return RedirectToAction("Produtos", "Home");
            }
        }

        private List<SelectListItem> PopularListaNacoes()
        {
            var listaNacoes = new List<SelectListItem>();
            listaNacoes.Add(new SelectListItem {Value = "BRA" , Text = "BRASIL" });

            return listaNacoes;
        }

        private List<SelectListItem> PopularListaUfs()
        {
            var listaUfs = new List<SelectListItem>();
            listaUfs.Add(new SelectListItem {Value = "RJ" , Text = "Rio de Janeiro" });
            listaUfs.Add(new SelectListItem {Value = "SP" , Text = "São Paulo" });
            listaUfs.Add(new SelectListItem {Value = "ES" , Text = "Espírito Santo" });
            listaUfs.Add(new SelectListItem {Value = "MG" , Text = "Minas Gerais" });
            return listaUfs;
        }

        [HttpPost]
        public IActionResult Endereco(EnderecoViewModel enderecoViewModel)
        {
            var dadosCompra = JsonConvert.DeserializeObject<Transaction>(HttpContext.Session.GetString("dadosCompra"));
            dadosCompra.Customer.Address = enderecoViewModel.Address;

            HttpContext.Session.SetString("dadosCompra",JsonConvert.SerializeObject(dadosCompra));
            _logger.LogWarning("TRETA 2: " + JsonConvert.SerializeObject(dadosCompra).ToString());
            return RedirectToAction("Cartao", "Cartao");
        }

    }
}