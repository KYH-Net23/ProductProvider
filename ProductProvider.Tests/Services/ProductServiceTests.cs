using Microsoft.EntityFrameworkCore;
using Moq;
using ProductProvider.Enums;
using ProductProvider.Factories;
using ProductProvider.Interfaces;
using ProductProvider.Models;
using ProductProvider.Responses;
using ProductProvider.Services;

namespace ProductProvider.Tests.Services
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _mockRepo;
        private ProductService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }

        // Create

        [Test]
        public async Task CreateProductAsync_WhenSaveIsSuccessful_ReturnsSuccess()
        {
            // Arrange
            var productModel = new ProductModel(); // Initialize with necessary properties
            var productEntity = ProductFactory.Create(productModel);
            productEntity.AddedDate = DateOnly.FromDateTime(DateTime.Now);
            _mockRepo
                .Setup(repo => repo.SaveAsync(It.IsAny<ProductEntity>()))
                .ReturnsAsync("Success"); // Simulating a successful save

            // Act
            var result = await _service.CreateProductAsync(productModel);

            // Assert
            Assert.That(result, Is.EqualTo(ResultResponse.Success));
            _mockRepo.Verify(repo => repo.SaveAsync(It.IsAny<ProductEntity>()), Times.Once);
        }

        // Read One
        [Test]
        public async Task Get_Product_By_Id_Product_Correct_Id()
        {
            // Arrange
            var expectedProduct = new ProductEntity { Id = 1 };

            _mockRepo.Setup(repo => repo.GetProductAsync(It.IsAny<int>())).ReturnsAsync(expectedProduct);

            // Act
            var result = await _service.GetProductAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetProductById_ProductNotFound_ReturnsNull()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetProductAsync(It.IsAny<int>())).ReturnsAsync((ProductEntity?)null!);

            // Act
            var result = await _service.GetProductAsync(999);

            // Assert
            Assert.That(result, Is.Null);
        }

        // Delete
        [Test]
        public async Task DeleteProductAsync_ProductExistsAndDeleted_ReturnsTrue()
        {
            // Arrange
            var product = new ProductEntity { Id = 1 };
            _mockRepo.Setup(repo => repo.GetProductAsync(1)).ReturnsAsync(product);
            _mockRepo.Setup(repo => repo.DeleteAsync(product)).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteProductAsync(1);

            // Assert
            Assert.That(result, Is.True);

        }

        [Test]
        public async Task DeleteProductAsync_ProductDoesNotExist_ReturnsFalse()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetProductAsync(1)).ReturnsAsync((ProductEntity?)null);

            // Act
            var result = await _service.DeleteProductAsync(1);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DeleteProductAsync_DeleteOperationFails_ReturnsFalse()
        {
            // Arrange
            var product = new ProductEntity { Id = 1 };
            _mockRepo.Setup(repo => repo.GetProductAsync(1)).ReturnsAsync(product);
            _mockRepo.Setup(repo => repo.DeleteAsync(product)).ReturnsAsync(false);

            // Act
            var result = await _service.DeleteProductAsync(1);

            // Assert
            Assert.That(result, Is.False);
        }

        // Update
        [Test]
        public async Task UpdateProductAsync_ProductUpdatedSuccessfully_ReturnsOne()
        {
            //Arrange
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

            _mockRepo.Setup(repo => repo.GetProductAsync(It.IsAny<int>())).ReturnsAsync(existingProductEntity);
            _mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(true);

            //Act
            var result = await _service.UpdateProductAsync(1, productModel);

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateProductAsync_ProductNotFound_ReturnsZero()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetProductAsync(It.IsAny<int>())).ReturnsAsync((ProductEntity?)null);

            //Act
            var result = await _service.UpdateProductAsync(1, new ProductModel());

            //Assert
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public async Task UpdateProductAsync_SaveAsyncFails_ReturnZero()
        {
            //Arrange
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

            _mockRepo.Setup(repo => repo.GetProductAsync(It.IsAny<int>())).ReturnsAsync(existingProductEntity);
            _mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(false);

            //Act 
            var result = await _service.UpdateProductAsync(1, productModel);

            //Assert 
            Assert.That(result, Is.EqualTo(0));
        }

        // sorting

        [Test]
        public async Task SortProductsAsync_ShouldSortByPriceAscending()
        {
            // Arrange
            var products = new List<ProductEntity>
            {
            new ProductEntity { Id = 1, Model = "Product A", Price = 200 },
            new ProductEntity { Id = 2, Model = "Product B", Price = 100 },
            new ProductEntity { Id = 3, Model = "Product C", Price = 300 }
            };

            _mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.SortProductsAsync(SortOption.PriceAscending);

            // Assert
            Assert.That(result.First().Price, Is.EqualTo(100));
            Assert.That(result[1].Price, Is.EqualTo(200));
            Assert.That(result.Last().Price, Is.EqualTo(300));
        }

        [Test]
        public async Task SortProductsAsync_ShouldSortByPriceDescending()
        {
            // Arrange
            var products = new List<ProductEntity>
            {
            new ProductEntity { Id = 1, Model = "Product A", Price = 200 },
            new ProductEntity { Id = 2, Model = "Product B", Price = 100 },
            new ProductEntity { Id = 3, Model = "Product C", Price = 300 }
            };

            _mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.SortProductsAsync(SortOption.PriceDescending);

            // Assert
            Assert.That(result.First().Price, Is.EqualTo(300));
            Assert.That(result[1].Price, Is.EqualTo(200));
            Assert.That(result.Last().Price, Is.EqualTo(100));
        }

        [Test]
        public async Task SortProductsAsync_ShouldSortByAlphabetical_IntegrationTest()
        {
            // Arrange
            var products = new List<ProductEntity>
            {
            new ProductEntity { Id = 1, Model = "Apple", Price = 200 },
            new ProductEntity { Id = 2, Model = "Banana", Price = 100 },
            new ProductEntity { Id = 3, Model = "Cherry", Price = 300 }
            };

            _mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.SortProductsAsync(SortOption.Alphabetical);

            // Assert
            Assert.That(result.First().Model, Is.EqualTo("Apple"));
            Assert.That(result[1].Model, Is.EqualTo("Banana"));
            Assert.That(result.Last().Model, Is.EqualTo("Cherry"));
        }

        [Test]
        public async Task SortProductsAsync_ShouldSortByAlphabeticalDescending_IntegrationTest()
        {
            // Arrange
            var products = new List<ProductEntity>
            {
            new ProductEntity { Id = 1, Model = "Apple", Price = 200 },
            new ProductEntity { Id = 2, Model = "Banana", Price = 100 },
            new ProductEntity { Id = 3, Model = "Cherry", Price = 300 }
            };

            _mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.SortProductsAsync(SortOption.AlphabeticalDescending);

            // Assert
            Assert.That(result.First().Model, Is.EqualTo("Cherry"));
            Assert.That(result[1].Model, Is.EqualTo("Banana"));
            Assert.That(result.Last().Model, Is.EqualTo("Apple"));
        }
    }
}