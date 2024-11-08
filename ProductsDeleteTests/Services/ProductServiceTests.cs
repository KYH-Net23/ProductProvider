using Moq;
using ProductsDelete.Data;
using ProductsDelete.Models;
using ProductsDelete.Services;
using ProductsDelete.Tests.TestData;
using Xunit;

namespace ProductsDelete.Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void DeleteProduct_ProductExists_ReturnsTrue()
        {

            using var context = ApplicationDbContextFactory.CreateInMemoryDbContext();
            var service = new ProductService(context);

  
            var result = service.DeleteProduct(1); 


            Assert.True(result);
            Assert.Null(context.products.Find(1));
        }

        [Fact]
        public void DeleteProduct_ProductDoesNotExist_ReturnsFalse()
        {

            using var context = ApplicationDbContextFactory.CreateInMemoryDbContext();
            var service = new ProductService(context);


            var result = service.DeleteProduct(99); 

 
            Assert.False(result);
        }
    }
}
