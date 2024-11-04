using Microsoft.EntityFrameworkCore;


namespace ProductsDelete.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Products> projects { get; set; }
    }

}