using ProductProvider.Models;
using System.Globalization;

namespace ProductProvider.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> DeleteAsync(ProductEntity entity);
        Task<ProductEntity?> GetProductAsync(int id);
        Task<List<ProductEntity>> GetAllProductsAsync();
        Task<bool> SaveAsync();
        Task<string> SaveAsync(ProductEntity entity);
        Task<List<ProductEntity>> SearchProductAsync(string search);
    }
}
