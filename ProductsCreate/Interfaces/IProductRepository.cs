using Shared.Models;

namespace CreateProducts.Interfaces
{
    public interface IProductRepository
    {
        Task<string> SaveAsync(ProductEntity entity);
    }
}