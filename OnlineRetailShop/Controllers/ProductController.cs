using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineRetailShop.Api.Contracts;
using OnlineRetailShop.Api.Contracts.Interfaces;
using OnlineRetailShop.Api.Contracts.Model;
using System.Threading.Tasks;
using Entities = OnlineRetailShop.Api.Contracts.Entities;

namespace OnlineRetailShop.API.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private IAutoMapConverter<SaveProductRequest, Entities.Product> _mapModelToEntity;
        public ProductController(ILogger<ProductController> logger, IProductService productService,
               IAutoMapConverter<SaveProductRequest, Entities.Product> mapModelToEntity)
        {
            _logger = logger;
            _productService = productService;
            _mapModelToEntity = mapModelToEntity;
        }

        [HttpGet("getproduct")]
        public async Task<ActionResult> GetProduct()
        {
            var reponse = await _productService.GetProducts();
            return Ok(reponse);
        }

        [HttpPost("addproduct")]
        public async Task<ActionResult> AddProduct(SaveProductRequest productRequest)
        {
            var product = _mapModelToEntity.ConvertObject(productRequest);
            var response = await _productService.AddProduct(product);
            return Ok(response);
        }

        [HttpPost("updateproduct")]
        public async Task<ActionResult> UpdateProduct(SaveProductRequest productRequest)
        {
            var product = _mapModelToEntity.ConvertObject(productRequest);
            await _productService.UpdateProduct(product);
            return Ok();
        }

        [HttpPost("deleteproduct")]
        public async Task DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
        }
    }
}
