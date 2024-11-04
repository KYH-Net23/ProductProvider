using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared.Contexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }


    }
}
