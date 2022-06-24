using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public ShopContext()
        {
        }
    }
}
