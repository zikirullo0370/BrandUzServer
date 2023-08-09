using BrandUzServer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BrandUzServer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Shoes> Shoe { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options) { }
    }
}
