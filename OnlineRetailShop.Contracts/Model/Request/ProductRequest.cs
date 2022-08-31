using System;

namespace OnlineRetailShop.Api.Contracts.Model
{
    public class SaveProductRequest
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
