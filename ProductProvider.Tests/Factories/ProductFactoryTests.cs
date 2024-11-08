using ProductProvider.Factories;
using ProductProvider.Models;

namespace ProductProvider.Tests.Factories
{
    public class ProductFactoryTests
    {
        [Test]
        public void Create_ShouldMapAllProperties()
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
            var result = ProductFactory.Create(productEntity);
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(result.Brand, Is.EqualTo(productEntity.Brand));
                Assert.That(result.Model, Is.EqualTo(productEntity.Model));
                Assert.That(result.Description!, Is.EqualTo(productEntity.Description));
                Assert.That(result.Price, Is.EqualTo(productEntity.Price));
                Assert.That(result.Category!, Is.EqualTo(productEntity.Category));
                Assert.That(result.Image, Is.EqualTo(productEntity.Image));
                Assert.That(result.Stock, Is.EqualTo(productEntity.Stock));
                Assert.That(result.Size!, Is.EqualTo(productEntity.Size));
                Assert.That(result.AddedDate, Is.EqualTo(productEntity.AddedDate));
            });
        }

        [Test]
        public void Create_ReturnsProductEntity_WhenGivenProductModel()
        {
            // Arrange
            var model = new ProductModel
            {
                Brand = "BrandX",
                Model = "ModelY",
                Image = "imageurl.com",
                Price = 199.99M,
                Size = "M",
                Stock = 10,
                Description = "A great product.",
                Category = "Electronics",
                AddedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            // Act
            var entity = ProductFactory.Create(model);

            // Assert
            Assert.That(entity, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(entity.Brand, Is.EqualTo(model.Brand));
                Assert.That(entity.Model, Is.EqualTo(model.Model));
                Assert.That(entity.Image, Is.EqualTo(model.Image));
                Assert.That(entity.Price, Is.EqualTo(model.Price));
                Assert.That(entity.Size, Is.EqualTo(model.Size));
                Assert.That(entity.Stock, Is.EqualTo(model.Stock));
                Assert.That(entity.Description, Is.EqualTo(model.Description));
                Assert.That(entity.Category, Is.EqualTo(model.Category));
                Assert.That(entity.AddedDate, Is.EqualTo(model.AddedDate));
            });
        }

        [Test]
        public void Create_ShouldHandleNullValues()
        {
            //Arrange
            var productEntity = new ProductEntity()
            {
                Brand = null!,
                Model = null!,
                Description = null,
                Price = 0,
                Category = null,
                Image = null!,
                Stock = 0,
                Size = null,
                AddedDate = DateOnly.MinValue,
            };

            //Act
            var result = ProductFactory.Create(productEntity);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Brand, Is.Null);
                Assert.That(result.Model, Is.Null);
                Assert.That(result.Description, Is.Null);
                Assert.That(result.Category, Is.Null);
                Assert.That(result.Image, Is.Null);
                Assert.That(result.Price, Is.EqualTo(0));
                Assert.That(result.Stock, Is.EqualTo(0));
                Assert.That(result.Size, Is.Null);
                Assert.That(productEntity.AddedDate, Is.EqualTo(result.AddedDate));
            });
        }

        [Test]
        public void GetProducts_ShouldMapListOfProductEntitiesToListOfProductViewModels()
        {
            var productEntities = new List<ProductEntity>
            {
                new() { Id = 1, Brand = "Brand1", Model = "Model1", Price = 50.00m, Image = "image1.jpg" },
                new() { Id = 2, Brand = "Brand2", Model = "Model2", Price = 75.00m, Image = "image2.jpg" }
            };

            var productViewModels = ProductFactory.GetProducts(productEntities);

            Assert.That(productViewModels.Count, Is.EqualTo(productEntities.Count));
            for (int i = 0; i < productEntities.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(productViewModels[i].Id, Is.EqualTo(productEntities[i].Id));
                    Assert.That(productViewModels[i].Brand, Is.EqualTo(productEntities[i].Brand));
                    Assert.That(productViewModels[i].Model, Is.EqualTo(productEntities[i].Model));
                    Assert.That(productViewModels[i].Price, Is.EqualTo(productEntities[i].Price));
                    Assert.That(productViewModels[i].Image, Is.EqualTo(productEntities[i].Image));
                });
            }
        }

        [Test]
        public void MapExistingEntityFromModel_UpdatesEntity_WhenGivenProductModel()
        {
            // Arrange
            var existingEntity = new ProductEntity
            {
                Brand = "OldBrand",
                Model = "OldModel",
                Image = "oldimage.com",
                Price = 100M,
                Size = "S",
                Stock = 5,
                Description = "Old description.",
                Category = "OldCategory",
            };

            var model = new ProductModel
            {
                Brand = "BrandX",
                Model = "ModelY",
                Image = "newimage.com",
                Price = 199.99M,
                Size = "M",
                Stock = 10,
                Description = "A great product.",
                Category = "Electronics",
            };

            // Act
            ProductFactory.MapExistingEntityFromModel(ref existingEntity, model);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(existingEntity.Brand, Is.EqualTo(model.Brand));
                Assert.That(existingEntity.Model, Is.EqualTo(model.Model));
                Assert.That(existingEntity.Image, Is.EqualTo(model.Image));
                Assert.That(existingEntity.Price, Is.EqualTo(model.Price));
                Assert.That(existingEntity.Size, Is.EqualTo(model.Size));
                Assert.That(existingEntity.Stock, Is.EqualTo(model.Stock));
                Assert.That(existingEntity.Description, Is.EqualTo(model.Description));
                Assert.That(existingEntity.Category, Is.EqualTo(model.Category));
            });
        }
    }
}
