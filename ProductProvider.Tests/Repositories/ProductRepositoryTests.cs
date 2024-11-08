using Moq;
using ProductProvider.Contexts;
using ProductProvider.Models;
using ProductProvider.Repositories;

namespace ProductProvider.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private Mock<ProductDbContext> _mockContext;
        private ProductRepository _repository;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<ProductDbContext>();
            _repository = new ProductRepository(_mockContext.Object);
        }

        [Test]
        public async Task GetProduct_ProductExists_ReturnsProduct()
        {
            // Arrange
            var product = new ProductEntity { Id = 1, Brand = "Prada" };
            _mockContext.Setup(c => c.Products.FindAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _repository.GetProductAsync(product.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Brand, Is.EqualTo("Prada"));
        }

        [Test]
        public async Task GetProduct_ProductDoesNotExists_ReturnsNull()
        {
            // Arrange
            var productId = 1;
            _mockContext.Setup(c => c.Products.FindAsync(productId)).ReturnsAsync((ProductEntity)null!);

            // Act
            var result = await _repository.GetProductAsync(productId);

            // Assert
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task SaveAsync_SuccessfulChanges_ReturnsTrue()
        {
            // Arrange
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _repository.SaveAsync();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task SaveAsync_NoChanges_Or_Error_ReturnsFalse()
        {
            // Arrange
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            // Act
            var result = await _repository.SaveAsync();

            // Assert
            Assert.That(result, Is.False);
        }
    }
}