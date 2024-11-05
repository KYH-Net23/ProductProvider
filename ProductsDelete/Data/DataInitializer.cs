using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Models;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductsDelete.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void MigrateData()
        {
            if (_dbContext.Database.CanConnect())
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();
            }
            else
            {
                _dbContext.Database.Migrate();
            }

            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.products.Any())
            {
                _dbContext.AddRange(
                    new Products { Name = "Abdin", Title = "Title"},
                    new Products { Name = "Anton", Title = "Title" },
                    new Products { Name = "Jonas", Title = "Title" }
                );
            }
        }
    }

}