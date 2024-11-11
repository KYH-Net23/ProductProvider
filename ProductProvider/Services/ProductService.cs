using Bogus;
using ProductProvider.Factories;
using ProductProvider.Interfaces;
using ProductProvider.Models;
using ProductProvider.Responses;
using System;

namespace ProductProvider.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<List<ProductEntity>> ProductSearchAsync(string search)
        {
            try
            {
                return await _repository.SearchProductAsync(search);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProductEntity>();
            }
        }
        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            return await _repository.GetProductAsync(id);
        }
        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }
        public async Task<int> UpdateProductAsync(int id, ProductModel model)
        {
            try
            {
                int statusCode = -1; // Not Found
                var existingProductEntity = await _repository.GetProductAsync(id);

                if (existingProductEntity != null)
                {
                    ProductFactory.MapExistingEntityFromModel(ref existingProductEntity, model);
                    var result = await _repository.SaveAsync();
                    if (result)
                    {
                        statusCode = 1;
                    }
                    else
                    {
                        statusCode = 0; 
                    }
                }
                return statusCode;
            }
            catch
            {
                return 2; 
            }
        }
        public async Task<string> CreateProductAsync(ProductModel model)
        {
            try
            {
                var entity = ProductFactory.Create(model);
                entity.AddedDate = DateOnly.FromDateTime(DateTime.Now);
                try
                {
                    var result = await _repository.SaveAsync(entity);
                    return ResultResponse.Success;
                }
                catch
                {
                    return ResultResponse.Failed;
                }
            }
            catch
            {
                return ResultResponse.Failed;
            }
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);
            if (product == null)
            {
                return false;
            }
            var result = await _repository.DeleteAsync(product);
            return result;
        }
    }
}
