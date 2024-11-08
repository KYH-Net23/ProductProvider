using ProductProvider.Models;

namespace ProductProvider.Interfaces
{
    public interface IProductService
    {
        Task<string> CreateNewProduct(ProductModel model);
        Task<bool> DeleteProduct(int id);
        Task<ProductEntity?> GetProductById(int id);
        Task<List<ProductEntity>> GetAllProducts();
        Task<int> UpdateProductAsync(int id, ProductModel model);
    }
}