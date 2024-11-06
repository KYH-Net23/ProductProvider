using ProductsUpdate.Models;

namespace ProductsUpdate.Interfaces
{
    public interface IProductService
    {
        Task<int> UpdateProductAsync(int id, ProductModel model);
    }
}
