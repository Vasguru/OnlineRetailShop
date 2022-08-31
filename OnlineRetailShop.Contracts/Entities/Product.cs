using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRetailShop.Api.Contracts.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }

    }
}
