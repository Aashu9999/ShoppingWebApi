using Microsoft.EntityFrameworkCore;

namespace ShoppingWebApi.EfCore
{
    public class EF_Data_Context:DbContext
    {
        public EF_Data_Context(DbContextOptions<EF_Data_Context> options) : base(options) {
        
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
