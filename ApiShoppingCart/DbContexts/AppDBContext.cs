using ApiShoppingCart.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiShoppingCart.DbContexts
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() {}
        public AppDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
    }
}
