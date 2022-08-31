using System;

namespace OnlineRetailShop.Api.Contracts.Model
{
    public class CreateOrderRequest
    {
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
