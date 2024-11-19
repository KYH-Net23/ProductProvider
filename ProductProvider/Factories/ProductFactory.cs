using ProductProvider.Models;

namespace ProductProvider.Factories
{
    public static class ProductFactory
    {
        public static List<ProductViewModel> GetProducts(List<ProductEntity> products)
        {
            return products.Select(GetProduct).ToList();
        }

        public static ProductViewModel GetProduct(ProductEntity product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Brand = product.Brand,
                Model = product.Model,
                Price = product.Price,
                Image = product.Image
            };
        }
        public static ProductEntity Create(ProductModel model)
        {
            return new ProductEntity
            {
                Brand = model.Brand,
                Model = model.Model,
                Image = model.Image,
                Price = model.Price,
                Description = model.Description,
                Category = model.Category,
                AddedDate = model.AddedDate,
            };
        }
        public static ProductModel Create(ProductEntity productEntity)
        {
            return new ProductModel
            {
                Brand = productEntity.Brand,
                Model = productEntity.Model,
                Description = productEntity.Description,
                Price = productEntity.Price,
                Category = productEntity.Category,
                Image = productEntity.Image,
                AddedDate = productEntity.AddedDate,
            };
        }
        public static void MapExistingEntityFromModel(ref ProductEntity entity, ProductModel model)
        {
            entity.Brand = model.Brand;
            entity.Model = model.Model;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Category = model.Category;
            entity.Image = model.Image;
        }

    }
}
