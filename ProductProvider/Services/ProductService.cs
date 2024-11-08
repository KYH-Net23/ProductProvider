using ProductProvider.Factories;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        public async Task<ProductEntity?> GetProductById(int id)
        {
            return await _repository.GetProduct(id);
        }
        public async Task<List<ProductEntity>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }
        public async Task<int> UpdateProductAsync(int id, ProductModel model)
        {
            try
            {
                int statusCode = -1; // Not Found
                var existingProductEntity = await _repository.GetProduct(id);

                if (existingProductEntity != null)
                {
                    ProductFactory.MapExistingEntityFromModel(ref existingProductEntity, model);
                    var result = await _repository.SaveAsync();
                    if (result)
                    {
                        statusCode = 1; // Found product and successfully updated
                    }
                    else
                    {
                        statusCode = 0; // Found product but no changes
                    }
                }
                return statusCode;
            }
            catch
            {
                return 2; // Error
            }
        }
        public async Task<string> CreateNewProduct(ProductModel model)
        {
            try
            {
                var entity = ProductFactory.Create(model);

                try
                {
                    var result = await _repository.SaveAsync(entity);
                    return ResultResponse.ResultResponse.Success;
                }
                catch
                {
                    return ResultResponse.ResultResponse.Failed;
                }
            }
            catch
            {
                return ResultResponse.ResultResponse.Failed;
            }
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _repository.GetProduct(id);
            if (product == null)
            {
                return false;
            }
            var result = await _repository.DeleteAsync(product);
            return result;
        }
    }
}
