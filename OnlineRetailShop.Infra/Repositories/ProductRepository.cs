using OnlineRetailShop.Api.Contracts.Entities;
using OnlineRetailShop.Api.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = OnlineRetailShop.Api.Contracts.Entities;
namespace OnlineRetailShop.Api.DAL
{
    public class ProductRepository : GenericRepository<Entities.Product>, IProductRepository
    {
        private OnlineRetalilDBContext _retailDBContext;
        public ProductRepository(OnlineRetalilDBContext retalilDBContext) : base(retalilDBContext)
        {
            _retailDBContext = retalilDBContext;
        }
        public async Task<Product> GetProductById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await GetAllAsync();
        }

        public async Task<int> AddProduct(Entities.Product productRequest)
        {
            productRequest.CreatedDate = DateTime.Now;
            productRequest.ModifiedDate = DateTime.Now;
            await InsertAsync(productRequest, true);

            return productRequest.Product_Id;
        }

        public async Task UpdateProduct(Entities.Product productRequest)
        {
            //Get entity to be updated
            Entities.Product updEt = GetProductById(productRequest.Product_Id).Result;

            if (!string.IsNullOrEmpty(productRequest.Product_Name)) updEt.Product_Name = productRequest.Product_Name;

            updEt.Price = productRequest.Price;

            updEt.ModifiedDate = DateTime.Now;
            await UpdateAsync(updEt, true);
        }

        public async Task DeleteProduct(int id)
        {
            await DeleteAsync(id, true);
        }

        public async Task<int> AvailableStock(int productId)
        {
            var product = await _retailDBContext.Products.FindAsync(productId);

            return (int)(product?.Stock);
        }
    }
}
