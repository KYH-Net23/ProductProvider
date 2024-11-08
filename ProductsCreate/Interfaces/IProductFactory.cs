using Shared.Models;

namespace ProductsCreate.Interfaces
{
    public interface IProductFactory
    {
        ProductEntity Create(ProductModel model);
    }
}
