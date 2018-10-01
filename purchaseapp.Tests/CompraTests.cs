using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using purchaseapp.Controllers;
using purchaseapp.Models;
using Xunit;

namespace purchaseapp.Tests
{
    public class CompraTests
    {
        [Fact]
        public void TesteDeSelecaoDeProdutoParaCompra()
        {
            var mock = new Mock<ILogger<CompraController>>();

            ILogger<CompraController> logger = Mock.Of<ILogger<CompraController>>();

            var compraController = new CompraController(logger);

            var resultProds = compraController.Comprar();

            Assert.IsType<ViewResult>(resultProds);
        }
    }
}