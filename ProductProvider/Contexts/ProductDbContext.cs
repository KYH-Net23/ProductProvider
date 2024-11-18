using Microsoft.EntityFrameworkCore;
using ProductProvider.Enums;
using ProductProvider.Models;
using System.Collections.Generic;

namespace ProductProvider.Contexts
{
    public class ProductDbContext : DbContext
    {
        protected ProductDbContext()
        {

        }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductSize> Sizes { get; set; } = null!;
        public virtual DbSet<ProductCategory> Categories { get; set; } = null!;


    }
}
