using ProductsReadAll.ViewModels;
using Shared.Models;

namespace ProductsReadAll.Factories
{
    public static class ProductViewModelFactory
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
    }
}
