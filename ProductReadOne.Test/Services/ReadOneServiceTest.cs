using ProductsRead.Repositories;
using Moq;
using ProductsRead.Services;
using Shared.Contexts;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsRead.Models;
using System.Linq.Expressions;

namespace ProductReadOne.Test.Services
{
    
    public class ReadOneServiceTest
    {
        private readonly Mock<IProductReadRepository> _moqRepo;

        public ReadOneServiceTest()
        {
            _moqRepo = new Mock<IProductReadRepository>();
        }


        [Fact]
        
        public async Task Get_Product_By_Id_Product_Correct_Id()
        {
            //Arrange
            var productService = new ProductReadService(_moqRepo.Object);
            var expectedProduct = new ProductsDetailsModel { Id = 1 };

            _moqRepo.Setup(repo => repo.GetProductById(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
                    .ReturnsAsync(expectedProduct);

            var pro = new ProductReadService(_moqRepo.Object);

            //Act
            var result = await productService.GetProductById(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task Get_Product_By_Id_Returns_Null_When_Product_Not_Found()
        {
            // Arrange
            _moqRepo.Setup(repo => repo.GetProductById(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
                    .ReturnsAsync((ProductsDetailsModel)null);

            var productService = new ProductReadService(_moqRepo.Object);

            // Act
            var result = await productService.GetProductById(999); 

            // Assert
            Assert.Null(result);
        }


    }
}
