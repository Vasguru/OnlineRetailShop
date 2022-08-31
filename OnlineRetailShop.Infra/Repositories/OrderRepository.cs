using OnlineRetailShop.Api.Contracts.Entities;
using OnlineRetailShop.Api.Contracts.Interfaces;
using System;
using System.Threading.Tasks;
using Entities = OnlineRetailShop.Api.Contracts.Entities;

namespace OnlineRetailShop.Api.DAL
{
    public class OrderRepository : GenericRepository<Entities.Order>, IOrderRepository
    {
        private OnlineRetalilDBContext _retailDBContext;
        public OrderRepository(OnlineRetalilDBContext retalilDBContext) : base(retalilDBContext)
        {
            _retailDBContext = retalilDBContext;
        }
        public async Task<int> OrderProduct(Order orderRequest)
        {

            var product = await _retailDBContext.Products.FindAsync(orderRequest.Product_Id);
            if (product != null && product.Stock >= orderRequest.Quantity)
            {
                await InsertAsync(orderRequest, true);
                product.Stock -= orderRequest.Quantity;
                product.ModifiedDate = System.DateTime.Now;
                _retailDBContext.Update(product);
                _ = _retailDBContext.SaveChangesAsync();
                return orderRequest.Order_Id;
            }
            else
            {
                throw new System.Exception("Product Unavailable");
            }



        }
    }
}
