using ProductsRead.Models;
using Shared.Models;

namespace ProductsRead.Factories
{
    public static class ProductReadFactory
    {
        public static ProductsDetailsModel CreateProduct(ProductEntity productEntity)
        {
            return new ProductsDetailsModel
            {
                 Brand = productEntity.Brand,
                 Model = productEntity.Model,
                 Description = productEntity.Description,
                 Price = productEntity.Price,
                 Category = productEntity.Category,
                 Image = productEntity.Image,
                 Stock = productEntity.Stock,
                 Size = productEntity.Size,
                 AddedDate = productEntity.AddedDate,
            };
        }
    }
}
