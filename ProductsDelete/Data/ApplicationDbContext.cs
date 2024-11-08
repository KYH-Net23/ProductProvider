using Microsoft.EntityFrameworkCore;
using ProductsDelete.Models;


namespace ProductsDelete.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductsModel> products { get; set; }
    }

}