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

namespace ProductReadOne.Test.Services
{
    
    public class ReadOneServiceTest
    {
        private readonly IProductReadRepository _productReadRepository;
        public ReadOneServiceTest(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }


        //[Fact]

        //public  async Task Get_Product_By_Id_Returns_Correct_Product()
        //{
        //    //Arrange
        //    var productService = new Mock<IProductReadService>(); 
            
        //    var expectedProduct = new ProductsDetailsModel {Id = 1};
        //    await productService.Setup(service => service.GetProductById(1)).ReturnsAsync(expectedProduct);  

        //    var pro = new ProductReadService(productService.Object);
            
            
        //    //Act
        //    var result = await productService.GetProductById(1);

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(1, result.Id);   
            

        //}

    }
}
