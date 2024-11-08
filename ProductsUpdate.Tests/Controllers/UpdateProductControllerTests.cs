using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProductsUpdate.Controllers;
using ProductsUpdate.Interfaces;
using ProductsUpdate.Models;
using System;
using System.Threading.Tasks;

namespace ProductsUpdate.Tests.Controllers
{
    [TestFixture]
    public class UpdateProductControllerTests
    {
        private Mock<IProductService> _mockService;
        private UpdateProductController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IProductService>();
            _controller = new UpdateProductController(_mockService.Object);
        }

        [Test]
        public async Task UpdateProduct_Success_ReturnOk()
        {
            // Arrange
            int productId = 1;
            var productModel = new ProductModel { Brand = "Test Brand", Model = "Test Model" };
            _mockService.Setup(s => s.UpdateProductAsync(productId, productModel)).ReturnsAsync(1);

            // Act
            var result = await _controller.UpdateProduct(productId, productModel) as OkObjectResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Access 
            var messageProperty = result.Value?.GetType().GetProperty("Message")?.GetValue(result.Value, null);
            Assert.That(messageProperty, Is.EqualTo("Product updated successfully."));
        }

        [Test]
        public async Task UpdateProduct_ProductNotFound_ReturnsNotFound()
        {
            // Arrange
            int productId = 1;
            var productModel = new ProductModel();
            _mockService.Setup(s => s.UpdateProductAsync(productId, productModel)).ReturnsAsync(-1);

            // Act
            var result = await _controller.UpdateProduct(productId, productModel) as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);

            // Access
            var messageProperty = result.Value?.GetType().GetProperty("Message")?.GetValue(result.Value, null);
            Assert.That(messageProperty, Is.EqualTo("Product was not found"));
        }

        [Test]
        public async Task UpdateProduct_SaveError_ReturnsInternalServerError()
        {
            // Arrange
            int productId = 1;
            var productModel = new ProductModel();
            _mockService.Setup(s => s.UpdateProductAsync(productId, productModel)).ReturnsAsync(0);

            // Act
            var result = await _controller.UpdateProduct(productId, productModel) as ObjectResult;

            // Assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);

            // Access
            var messageProperty = result.Value?.GetType().GetProperty("Message")?.GetValue(result.Value, null);
            Assert.That(messageProperty, Is.EqualTo("Error updating the product OR no changes were made."));
        }

        [Test]
        public async Task UpdateProduct_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Brand", "Brand is required");
            int productId = 1;
            var productModel = new ProductModel();

            // Act
            var result = await _controller.UpdateProduct(productId, productModel) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.That(result.Value, Is.TypeOf<SerializableError>());
        }

        [Test]
        public async Task UpdateProduct_ServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            int productId = 1;
            var productModel = new ProductModel();
            _mockService.Setup(s => s.UpdateProductAsync(productId, productModel)).ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.UpdateProduct(productId, productModel) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);

            // Access
            var exceptionMessage = ((Exception)result.Value)?.Message;
            Assert.That(exceptionMessage, Is.EqualTo("Unexpected error"));
        }
    }
}
