using System.Threading.Tasks;
using CreateProducts.Controllers;
using CreateProducts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsCreate;
using Xunit;

namespace CreateProducts.Tests
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


        [Fact]
        public async Task CreateProduct_ReturnsOkResult_WhenProductCreatedSuccessfully()
        {
            // Arrange
            var model = new ProductModel();
            _mockProductService
                .Setup(service => service.CreateNewProduct(model))
                .Returns(Task.FromResult("Operation was successful."));

            // Act
            var result = await _controller.CreateProduct(model);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, actionResult.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ReturnsBadRequest_WhenProductCreationFails()
        {
            // Arrange
            var model = new ProductModel();
            _mockProductService
                .Setup(service => service.CreateNewProduct(model))
                .ThrowsAsync(new System.Exception());

            // Act
            var result = await _controller.CreateProduct(model);

            // Assert
            var actionResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, actionResult.StatusCode);
        }
    }
}
