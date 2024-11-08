using CreateProducts.Interfaces;
using ProductsCreate;
using ProductsCreate.Interfaces;
using ProductsCreate.ResultResponse;

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

        public async Task<string> CreateNewProduct(ProductModel model)
        {
            try
            {
                var entity = _factory.Create(model);

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
    }
}