using ProductsUpdate.Models;
using Shared.Models;

namespace ProductsUpdate.Factories
{
    public static class ProductFactory
    {
        public static ProductEntity Create(ProductModel model)
        {
            var entity = new ProductEntity
            {
                Brand = model.Brand,
                Model = model.Model,
                Image = model.Image,
                Price = model.Price,
                Size = model.Size,
                Stock = model.Stock,
                Description = model.Description,
                Category = model.Category,
                AddedDate = model.AddedDate,
            };
            return entity;
        }
        public static ProductModel Create(ProductEntity entity)
        {
            var model = new ProductModel
            {
                Brand = entity.Brand,
                Model = entity.Model,
                Image = entity.Image,
                Price = entity.Price,
                Size = entity.Size,
                Stock = entity.Stock,
                Description = entity.Description,
                Category = entity.Category,
                AddedDate = entity.AddedDate,
            };
            return model;
        }
        public static void MapExistingEntityFromModel(ref ProductEntity entity, ProductModel model)
        {
            entity.Brand = model.Brand;
            entity.Model = model.Model;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Category = model.Category;
            entity.Image = model.Image;
            entity.Stock = model.Stock;
            entity.Size = model.Size;
            entity.AddedDate = model.AddedDate;
        }
    }
}
