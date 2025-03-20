using Microsoft.EntityFrameworkCore;

namespace DeviceEcommerceWeb.Models
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
    }
}
