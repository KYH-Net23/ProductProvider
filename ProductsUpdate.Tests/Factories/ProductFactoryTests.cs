using ProductsUpdate.Factories;
using ProductsUpdate.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsUpdate.Tests.Factories
{
    public class ProductFactoryTests
    {
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
        public void Create_ReturnsProductModel_WhenGivenProductEntity()
        {
            // Arrange
            var entity = new ProductEntity
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
            var model = ProductFactory.Create(entity);

            // Assert
            Assert.That(model, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(model.Brand, Is.EqualTo(entity.Brand));
                Assert.That(model.Model, Is.EqualTo(entity.Model));
                Assert.That(model.Image, Is.EqualTo(entity.Image));
                Assert.That(model.Price, Is.EqualTo(entity.Price));
                Assert.That(model.Size, Is.EqualTo(entity.Size));
                Assert.That(model.Stock, Is.EqualTo(entity.Stock));
                Assert.That(model.Description, Is.EqualTo(entity.Description));
                Assert.That(model.Category, Is.EqualTo(entity.Category));
                Assert.That(model.AddedDate, Is.EqualTo(entity.AddedDate));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(existingEntity.Brand, Is.EqualTo(model.Brand));
                Assert.That(existingEntity.Model, Is.EqualTo(model.Model));
                Assert.That(existingEntity.Image, Is.EqualTo(model.Image));
                Assert.That(existingEntity.Price, Is.EqualTo(model.Price));
                Assert.That(existingEntity.Size, Is.EqualTo(model.Size));
                Assert.That(existingEntity.Stock, Is.EqualTo(model.Stock));
                Assert.That(existingEntity.Description, Is.EqualTo(model.Description));
                Assert.That(existingEntity.Category, Is.EqualTo(model.Category));
                Assert.That(existingEntity.AddedDate, Is.EqualTo(model.AddedDate));
            });
        }
    }
}
