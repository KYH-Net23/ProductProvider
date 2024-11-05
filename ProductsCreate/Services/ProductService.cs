using CreateProducts.Factories;
using CreateProducts.Interfaces;
using CreateProducts.Models;
using CreateProducts.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CreateProducts.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductFactory _factory = null!;
        private readonly ProductRepository _repository = null!;

        public async Task CreateNewProduct(ProductModel model)
        {
           var entity = _factory.Create(model);
           await _repository.SaveAsync(entity);
        }
    }
}