using CreateProducts.Models;
using Shared.Models;

namespace CreateProducts.Factories
{
    public class ProductFactory
    {
        public ProductEntity Create(ProductModel model)
        {
            var productEntity = new ProductEntity
            {
                Brand = model.Brand,
                Model = model.Model,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category,
                Image = model.Image,
                Stock = model.Stock,
                Size = model.Size,
                AddedDate = model.AddedDate
            };

            return productEntity;
        }

    }
}
