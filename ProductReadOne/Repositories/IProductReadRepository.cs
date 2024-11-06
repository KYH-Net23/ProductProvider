using ProductsRead.Models;
using Shared.Models;
using System.Linq.Expressions;

namespace ProductsRead.Repositories
{
    public interface IProductReadRepository
    {
        Task<ProductsDetailsModel?> GetProductById(Expression<Func<ProductEntity, bool>> expression);
    }
}
