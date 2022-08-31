using System.Threading.Tasks;

namespace OnlineRetailShop.Api.Contracts.Interfaces
{
    public interface IOrderService
    {
        Task<int> OrderProduct(Entities.Order orderRequest);
    }
}
