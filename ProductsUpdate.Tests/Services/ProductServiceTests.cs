using Moq;
using ProductsUpdate.Models;
using Shared.Models;
using ProductsUpdate.Services;
using ProductsUpdate.Interfaces;


namespace ProductsUpdate.Tests.Services
{
    public class ProductServiceTests
    {
        [Test]
        public async Task UpdateProductAsync_ProductUpdatedSuccessfully_ReturnsOne()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);

            var productModel = new ProductModel
            {
                Brand = "Test Brand",
                Model = "Test Model",
                Price = 100,
                Image = "test.jpg",
                Category = "Test Category",
                Stock = 10,
                Size = "M",
                AddedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            var existingProductEntity = new ProductEntity
            {
                Id = 1,
                Brand = "Old Brand",
            };

            mockRepo.Setup(repo => repo.GetProduct(It.IsAny<int>())).ReturnsAsync(existingProductEntity);
            mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(true);

            //Act
            var result = await service.UpdateProductAsync(1, productModel);

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task UpdateProductAsync_ProductNotFound_ReturnsZero()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);

            mockRepo.Setup(repo => repo.GetProduct(It.IsAny<int>())).ReturnsAsync((ProductEntity?)null);

            //Act
            var result = await service.UpdateProductAsync(1, new ProductModel());

            //Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public async Task UpdateProductAsync_SaveAsyncFails_ReturnZero()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);

            var productModel = new ProductModel
            {
                Brand = "Test Brand",
                Model = "Test Model",
                Price = 100,
                Image = "test.jpg",
                Category = "Test Category",
                Stock = 10,
                Size = "M",
                AddedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            var existingProductEntity = new ProductEntity
            {
                Id = 1,
                Brand = "Old Brand",
            };

            mockRepo.Setup(repo => repo.GetProduct(It.IsAny<int>())).ReturnsAsync(existingProductEntity);
            mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(false);

            //Act 
            var result = await service.UpdateProductAsync(1, productModel);

            //Assert 
            Assert.AreEqual(0, result);
        }
    }
}
