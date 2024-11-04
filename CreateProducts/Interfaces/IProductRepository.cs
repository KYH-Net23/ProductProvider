using Shared.Models;

namespace CreateProducts.Interfaces
{
    public interface IProductRepository
    {
        Task SaveAsync();
        Task SaveAsync(ProductEntity entity);
    }
}
