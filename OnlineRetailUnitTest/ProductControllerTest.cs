
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineRetailShop.Api.Contracts;
using OnlineRetailShop.Api.Contracts.Entities;
using OnlineRetailShop.Api.Contracts.Interfaces;
using OnlineRetailShop.Api.Contracts.Model;
using OnlineRetailShop.API.Web;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailUnitTest
{
    public class ProductControllerTest
    {
        private readonly ProductController _controller;
        private readonly Mock<IProductService> _service;
        private readonly Mock<ILogger<ProductController>> _logger;
        private readonly Mock<IAutoMapConverter<SaveProductRequest, OnlineRetailShop.Api.Contracts.Entities.Product>> _autoMapConverter;

        public ProductControllerTest()
        {
            _service = new Mock<IProductService>();
            _logger = new Mock<ILogger<ProductController>>();
            _autoMapConverter = new Mock<IAutoMapConverter<SaveProductRequest, OnlineRetailShop.Api.Contracts.Entities.Product>>();
            _controller = new ProductController(_logger.Object, _service.Object, _autoMapConverter.Object);
        }
        [Fact]
        public async Task GetProduct_ShouldReturn200StatusAsync()
        {
            _service.Setup(_ => _.GetProducts()).ReturnsAsync(ProductServiceFake.GetProducts());
            var result = (OkObjectResult)await _controller.GetProduct();
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public async Task AddProduct_ShouldReturnResponseHasCreatedId()
        {
            var product = new SaveProductRequest
            {
                Product_Name = "TestProductName3",
                Price = 120
            };

            var result = (OkObjectResult)await _controller.AddProduct(product);

            _service.Verify(_ => _.AddProduct(_autoMapConverter.Object.ConvertObject(product)), Times.Exactly(1));
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturnResponse()
        {
            var product = new SaveProductRequest
            {
                Product_Id = 1,
                Product_Name = "TestProductName4",
                Price = 120
            };

            var result = (OkResult)await _controller.UpdateProduct(product);

            _service.Verify(_ => _.UpdateProduct(_autoMapConverter.Object.ConvertObject(product)), Times.Exactly(1));
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnResponse()
        {
            int id = 1;
            await _controller.DeleteProduct(id);

            _service.Verify(_ => _.DeleteProduct(id), Times.Exactly(1));
        }
    }
}
