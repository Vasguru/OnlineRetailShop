using OnlineRetailShop.Api.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRetailUnitTest
{
    public class ProductServiceFake
    {
        public static readonly ProductServiceFake _obj = new ProductServiceFake();
        private static  IList<Product> _product;
        public ProductServiceFake()
        {
            _product = new List<Product>()
            {
                new Product{Product_Id =1, Product_Name="TestProduct1", Price=100,Stock=2},
                 new Product{Product_Id =2, Product_Name="TestProduct2", Price=100,Stock=0}
            };
        }
        public static int AddProduct(Product productRequest)
        {
            productRequest.Product_Id = 3;
            _product.Add(productRequest);
            return productRequest.Product_Id;
        }


        public static Product GetProductById(int id)
        {
            return _product.Where(p => p.Product_Id == id).FirstOrDefault();
        }

        public static IList<Product> GetProducts()
        {
            return _product;
        }

        public static void UpdateProduct(Product productRequest)
        {
            var producttoUpdate = _product.Where(p => p.Product_Id == productRequest.Product_Id).FirstOrDefault();
            producttoUpdate.Product_Name = productRequest.Product_Name;
            producttoUpdate.Stock = productRequest.Stock;
            producttoUpdate.Price = productRequest.Price;
        }
    }
}
