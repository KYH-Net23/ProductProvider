using ProductsUpdate.Factories;
using ProductsUpdate.Models;
using ProductsUpdate.Repositories;

namespace ProductsUpdate.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> UpdateProductAsync(int id, ProductModel model)
        {
            try
            {
                int statusCode = -1;
                var existingProductEntity = await _repository.GetProduct(id);

                if (existingProductEntity == null)
                {
                    Console.WriteLine("Product not found");
                }
                else
                {
                    ProductFactory.MapExistingEntityFromModel(ref existingProductEntity, model);
                    var result = await _repository.SaveAsync();
                    if (result)
                    {
                        statusCode = 1;
                        Console.WriteLine("Product updated successfully");
                    }
                    else
                    {
                        statusCode = 0;
                        Console.WriteLine("Product was not updated due to no changes or an error.");
                    }
                }
                return statusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return 0;
            }
        }
    }
}
