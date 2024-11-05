using CreateProducts.Interfaces;
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

        public async Task SaveAsync(ProductEntity entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
