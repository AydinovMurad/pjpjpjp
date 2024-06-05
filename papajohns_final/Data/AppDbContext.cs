
using Microsoft.EntityFrameworkCore;
using papajohns_final.Models;

namespace papajohns_final.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductsImage { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
        //    base.OnModelCreating(modelBuilder);
        //}
        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}
    }
}
