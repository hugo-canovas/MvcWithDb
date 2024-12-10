using FirstMvcWithDb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMvcWithDb.Data
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Livre> Livres { get; set; }
    }
}
