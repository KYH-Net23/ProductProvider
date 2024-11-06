using CreateProducts.Factories;
using CreateProducts.Interfaces;
using CreateProducts.Models;
using CreateProducts.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductsCreate.Interfaces;

namespace CreateProducts.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductFactory _factory;
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository, IProductFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task CreateNewProduct(ProductModel model)
        {
           var entity = _factory.Create(model);
           await _repository.SaveAsync(entity);
        }
    }
}