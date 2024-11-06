using ProductsRead.Models;
using Shared.Models;

namespace ProductsRead.Services
{
    public interface IProductReadService
    {
        Task <ProductsDetailsModel> GetProductById(int id);
    }
}
