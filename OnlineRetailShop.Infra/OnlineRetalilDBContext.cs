using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Api.Contracts.Entities;

namespace OnlineRetailShop.Api.DAL
{
    public class OnlineRetalilDBContext : DbContext
    {
        public OnlineRetalilDBContext(DbContextOptions<OnlineRetalilDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
