using Microsoft.EntityFrameworkCore;
using ProductsRead.Factories;
using ProductsRead.Models;
using Shared;
using Shared.Contexts;
using Shared.Models;
using System.Linq.Expressions;

namespace ProductsRead.Repositories
{
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly ProductDbContext _context;

        public ProductReadRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsDetailsModel> GetProductById(Expression <Func<ProductEntity, bool  >> expression) 
        {

            var entity = await _context.Products.FirstOrDefaultAsync(expression);
            return (entity != null) ? ProductReadFactory.CreateProduct(entity) : null!;
        }
    }
}