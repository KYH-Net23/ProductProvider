//using ProductsReadAll.Factories;
//using Shared.Models;

//namespace ProductsReadAll.Test
//{
//    public class ProductViewModelFactoryTests
//    {
//        [Fact]
//        public void GetProduct_ShouldMapProductEntityToProductViewModel()
//        {
//            var productEntity = new ProductEntity
//            {
//                Id = 1,
//                Brand = "TestBrand",
//                Model = "TestModel",
//                Price = 99.99m,
//                Image = "testImage.jpg"
//            };

//            var productViewModel = ProductViewModelFactory.GetProduct(productEntity);

//            Assert.Equal(productEntity.Id, productViewModel.Id);
//            Assert.Equal(productEntity.Brand, productViewModel.Brand);
//            Assert.Equal(productEntity.Model, productViewModel.Model);
//            Assert.Equal(productEntity.Price, productViewModel.Price);
//            Assert.Equal(productEntity.Image, productViewModel.Image);
//        }

//        [Fact]
//        public void GetProducts_ShouldMapListOfProductEntitiesToListOfProductViewModels()
//        {
//            var productEntities = new List<ProductEntity>
//            {
//                new ProductEntity { Id = 1, Brand = "Brand1", Model = "Model1", Price = 50.00m, Image = "image1.jpg" },
//                new ProductEntity { Id = 2, Brand = "Brand2", Model = "Model2", Price = 75.00m, Image = "image2.jpg" }
//            };

//            var productViewModels = ProductViewModelFactory.GetProducts(productEntities);

//            Assert.Equal(productEntities.Count, productViewModels.Count);
//            for (int i = 0; i < productEntities.Count; i++)
//            {
//                Assert.Equal(productEntities[i].Id, productViewModels[i].Id);
//                Assert.Equal(productEntities[i].Brand, productViewModels[i].Brand);
//                Assert.Equal(productEntities[i].Model, productViewModels[i].Model);
//                Assert.Equal(productEntities[i].Price, productViewModels[i].Price);
//                Assert.Equal(productEntities[i].Image, productViewModels[i].Image);
//            }
//        }
//    }
//}
