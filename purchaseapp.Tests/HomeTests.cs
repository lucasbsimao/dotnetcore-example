using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using purchaseapp.Controllers;
using purchaseapp.Models;
using Xunit;

namespace purchaseapp.Tests
{
    public class HomeTests
    {
        [Fact]
        public void TesteDeSelecaoDeProduto()
        {
            var mock = new Mock<ILogger<HomeController>>();

            ILogger<HomeController> logger = Mock.Of<ILogger<HomeController>>();

            var homeController = new HomeController(logger);

            ProdutosViewModel produtosViewModel = new ProdutosViewModel();
            var resultProds = homeController.Produtos(produtosViewModel);

            Assert.IsType<ViewResult>(resultProds);
        }
    }
}
