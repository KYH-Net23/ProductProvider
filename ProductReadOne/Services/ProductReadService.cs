using ProductsRead.Models;
using ProductsRead.Repositories;
using Shared.Models;

namespace ProductsRead.Services
{
    public class ProductReadService : IProductReadService
    {
        private readonly IProductReadRepository _productRepository;

        public ProductReadService(IProductReadRepository productReadRepository) 
        {
            _productRepository = productReadRepository;
        }

        public async Task<ProductsDetailsModel> GetProductById(int id)
        {
            return await _productRepository.GetProductById(x => x.Id == id);
        }
    }
}
