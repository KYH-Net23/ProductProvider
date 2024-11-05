using ProductsUpdate.Models;
using Shared.Models;

namespace ProductsUpdate.Factories
{
    public class ProductFactory
    {
        public ProductEntity Create(ProductModel model)
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
        public ProductModel Create(ProductEntity entity)
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
    }
}
