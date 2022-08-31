using OnlineRetailShop.Api.Contracts.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = OnlineRetailShop.Api.Contracts.Entities;
namespace OnlineRetailShop.Api.BL
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<IList<Entities.Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Entities.Product> GetProductById(int id)
        {
            return await this._productRepository.GetProductById(id);
        }

        public async Task<int> AddProduct(Entities.Product produtRequest)
        {
            return await this._productRepository.AddProduct(produtRequest);
        }
        public async Task UpdateProduct(Entities.Product produtRequest)
        {
            await this._productRepository.UpdateProduct(produtRequest);
        }
        public async Task DeleteProduct(int id)
        {
            await this._productRepository.DeleteAsync(id);
        }


    }
}
