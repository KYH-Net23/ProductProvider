using Microsoft.EntityFrameworkCore;
using ProductsDelete.Data;
using ProductsDelete.Models;

namespace ProductsDelete.Tests.TestData
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new ApplicationDbContext(options);


            context.products.AddRange(
                new ProductsModel { Id = 1, Brand = "BrandA", Model = "ModelA", Price = 100 },
                new ProductsModel { Id = 2, Brand = "BrandB", Model = "ModelB", Price = 200 }
            );
            context.SaveChanges();

            return context;
        }
    }
}
