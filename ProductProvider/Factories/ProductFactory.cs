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
                Brand = product.BrandName,
                Model = product.ModelName,
                Description = product.Description ?? "Description missing",
                Price = product.Price,
                Image = product.Image,
                Category = product.Category.CategoryName,
                Sizes = product.Category.Sizes.Select(x => x.SizeName).ToList()
            };
        }
        public static ProductEntity Create(ProductModel model, ProductCategory category)
        {
            return new ProductEntity
            {
                BrandName = model.Brand,
                ModelName = model.Model,
                Image = model.Image,
                Price = model.Price,
                Description = model.Description,
                Category = category,
                AddedDate = model.AddedDate
            };
        }
        public static ProductModel Create(ProductEntity productEntity, ProductCategory category)
        {
            return new ProductModel
            {
                Brand = productEntity.BrandName,
                Model = productEntity.ModelName,
                Description = productEntity.Description,
                Price = productEntity.Price,
                Category = null,
                Image = productEntity.Image,
                AddedDate = productEntity.AddedDate,
            };
        }
        public static void MapExistingEntityFromModel(ref ProductEntity entity, ProductModel model, ProductCategory category)
        {
            entity.BrandName = model.Brand;
            entity.ModelName = model.Model;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Category = category;
            entity.Image = model.Image;
        }

    }
}
