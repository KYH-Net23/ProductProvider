using CreateProducts.Interfaces;
using ProductsCreate.ResultResponse;
using Shared.Contexts;
using Shared.Models;

namespace CreateProducts.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<string> SaveAsync(ProductEntity entity)
        {
            try
            {
                await _context.Products.AddAsync(entity);
                await _context.SaveChangesAsync();
                return ResultResponse.Success;
            }
            catch
            {
                return ResultResponse.Failed;
            }

        }
    }
}
