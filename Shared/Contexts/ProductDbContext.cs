using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared.Contexts
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


    }
}