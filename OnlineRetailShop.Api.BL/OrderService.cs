using OnlineRetailShop.Api.Contracts.Entities;
using OnlineRetailShop.Api.Contracts.Interfaces;
using System.Threading.Tasks;

namespace OnlineRetailShop.Api.BL
{
    public class OrderService:IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public async Task<int> OrderProduct(Order orderRequest)
        {
            return await _orderRepository.OrderProduct(orderRequest);
        }
    }
}
