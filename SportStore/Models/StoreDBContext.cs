using Microsoft.EntityFrameworkCore;
namespace SportStore.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}
