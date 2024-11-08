using ProductProvider.Models;

namespace ProductProvider.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> DeleteAsync(ProductEntity entity);
        Task<ProductEntity?> GetProduct(int id);
        Task<List<ProductEntity>> GetAllProducts();
        Task<bool> SaveAsync();
        Task<string> SaveAsync(ProductEntity entity);
    }
}
