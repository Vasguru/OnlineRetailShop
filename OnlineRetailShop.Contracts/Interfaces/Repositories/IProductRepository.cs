using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailShop.Api.Contracts.Interfaces
{
    public interface IProductRepository : IGenericRepository<Entities.Product>
    {
        Task<IList<Entities.Product>> GetProducts();
        Task<Entities.Product> GetProductById(int id);
        Task<int> AddProduct(Entities.Product productRequest);
        Task UpdateProduct(Entities.Product productRequest);
        Task DeleteProduct(int id);

        Task<int> AvailableStock(int productId);

    }
}
