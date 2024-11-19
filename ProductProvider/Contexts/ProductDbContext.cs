using Microsoft.EntityFrameworkCore;
using ProductProvider.Models;

namespace ProductProvider.Contexts;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<ProductSize> Sizes { get; set; }
    public virtual DbSet<ProductCategory> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductCategory>(x =>
        {
            x.HasIndex(cat => cat.CategoryName).IsUnique();
        });
    }
}