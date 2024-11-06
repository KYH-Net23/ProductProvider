using ProductsUpdate.Factories;
using ProductsUpdate.Interfaces;
using ProductsUpdate.Models;
using ProductsUpdate.Repositories;

namespace ProductsUpdate.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

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
    }
}
