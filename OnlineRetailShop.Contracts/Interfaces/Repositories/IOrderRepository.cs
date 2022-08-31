using System.Threading.Tasks;

namespace OnlineRetailShop.Api.Contracts.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Entities.Order>
    {
        Task<int> OrderProduct(Entities.Order orderRequest);
    }
}
