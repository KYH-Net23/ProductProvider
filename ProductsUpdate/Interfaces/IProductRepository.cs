using Shared.Models;

namespace ProductsUpdate.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity?> GetProduct(int id);
        Task<bool> SaveAsync();
    }
}
