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