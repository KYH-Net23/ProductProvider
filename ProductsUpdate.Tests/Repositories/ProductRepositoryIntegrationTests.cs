using Microsoft.EntityFrameworkCore;
using ProductsUpdate.Repositories;
using Shared.Contexts;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsUpdate.Tests.Repositories
{
    public class ProductRepositoryIntegrationTests
    {
        private ProductDbContext _context;
        private ProductRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseSqlServer("Server=tcp:rika-solutions.database.windows.net,1433;Initial Catalog=ProductDB;PersistSecurityInfo=False;User ID=product-rika;Password=kyh23net!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;").Options;
            _context = new ProductDbContext(options);
            _repository = new(_context);
        }
        [TearDown]
        public void Teardown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task GetProduct_ProductExists_ReturnsProduct()
        {
            // Arrange
            var productId = 3;


            // Act
            var result = await _repository.GetProduct(productId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Id, Is.EqualTo(productId));

        }

        [Test]
        public async Task GetProduct_ProductDoesNotExists_ReturnsNull()
        {
            // Arrange
            var productId = 0;

            // Act
            var result = await _repository.GetProduct(productId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task SaveAsync_SuccessfulChanges_ReturnsTrue()
        {
            // Arrange
            var productId = 3;
            var oldPrice = 399.90m;
            var newPrice = 299.90m;
            var product = await _repository.GetProduct(productId);

            // Act
            if (product!.Price == oldPrice)
                product!.Price = newPrice;
            else
                product!.Price = oldPrice;

            var result = await _repository.SaveAsync();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(oldPrice, Is.Not.EqualTo(newPrice));
            });
        }
        [Test]
        public async Task SaveAsync_NoChanges_Or_Error_ReturnsFalse()
        {
            // Act
            var result = await _repository.SaveAsync();

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
