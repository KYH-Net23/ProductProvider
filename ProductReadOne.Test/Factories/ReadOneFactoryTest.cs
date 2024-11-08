using ProductsRead.Factories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReadOne.Test.Factories
{
    
    public class ReadOneFactoryTest
    {
        [Fact]
        public void CreateProduct_ShouldMapAllProperties()
        {
            //Arrange
            var productEntity = new ProductEntity()
            {
                Brand = "TestBrand",
                Model = "TestModel",
                Description = "Description",
                Price = 100.0m,
                Category = "Category",
                Image = "testimage.jpg",
                Stock = 10,
                Size = "M",
                AddedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            //Act
            var result = ProductReadFactory.CreateProduct(productEntity);

            //Assert

            Assert.Equal(productEntity.Brand, result.Brand);
            Assert.Equal(productEntity.Model, result.Model);
            Assert.Equal(productEntity.Description, result.Description);
            Assert.Equal(productEntity.Price, result.Price);
            Assert.Equal(productEntity.Category, result.Category);
            Assert.Equal(productEntity.Image, result.Image);
            Assert.Equal(productEntity.Stock, result.Stock);
            Assert.Equal(productEntity.Size, result.Size);
            Assert.Equal(productEntity.AddedDate, result.AddedDate);
        }


        [Fact]
        public void CreateProduct_ShouldHandleNullValues()
        {
            //Arrange
            var productEntity = new ProductEntity()
            {
                Brand = null,
                Model = null,
                Description = null,
                Price = 0,
                Category = null,
                Image = null,
                Stock = 0,
                Size = null,
                AddedDate = DateOnly.MinValue, 
            };

            //Act
            var result = ProductReadFactory.CreateProduct(productEntity);

            //Assert

            Assert.Null(result.Brand);
            Assert.Null(result.Model);
            Assert.Null(result.Description);
            Assert.Equal(0, result.Price);
            Assert.Null(result.Category);
            Assert.Null(result.Image);
            Assert.Equal(0, result.Stock);
            Assert.Null(result.Size);
            Assert.Equal(result.AddedDate, productEntity.AddedDate);
        }

    }
}
