using ProductsCreate;
using ProductsCreate.Interfaces;
using Shared.Models;

namespace CreateProducts.Factories
{
    public class ProductFactory : IProductFactory
    {
        public ProductEntity Create(ProductModel model)
        {
            var productEntity = new ProductEntity
            {
                Brand = model.Brand,
                Model = model.Model!,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category,
                Image = model.Image,
                Stock = model.Stock,
                Size = model.Size
            };
            return productEntity;
        }
    }
}