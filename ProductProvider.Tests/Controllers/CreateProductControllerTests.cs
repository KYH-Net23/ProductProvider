using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductProvider.Controllers;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Tests.Controllers
{
    public class CreateProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly CreateProductController _controller;
        public CreateProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new CreateProductController(_mockProductService.Object);
        }

        [Test]
        public async Task CreateProduct_ReturnsOkResult_WhenProductCreatedSuccessfully()
        {
            // Arrange
            var model = new ProductModel();
            _mockProductService
                .Setup(service => service.CreateProductAsync(model))
                .Returns(Task.FromResult("Operation was successful."));

            // Act
            var result = await _controller.CreateProduct(model);

            // Assert
            var actionResult = (OkObjectResult)result;

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                Assert.That(actionResult.StatusCode, Is.EqualTo(200));
                Assert.That(actionResult.Value, Is.EqualTo("Operation was successful."));
            });
        }

        [Test]
        public async Task CreateProduct_ReturnsBadRequest_WhenProductCreationFails()
        {
            // Arrange
            var model = new ProductModel();
            _mockProductService
                .Setup(service => service.CreateProductAsync(model))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.CreateProduct(model);

            // Assert
            var actionResult = (BadRequestResult)result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<BadRequestResult>());
                Assert.That(actionResult.StatusCode, Is.EqualTo(400));
            });
        }
    }
}