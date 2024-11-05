using Microsoft.EntityFrameworkCore;
using Shared.Contexts;
using Shared.Models;

namespace ProductsUpdate.Repositories
{
    public class ProductRepository(ProductDbContext context)
    {
        private readonly ProductDbContext _context = context;

        public async Task<ProductEntity?> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public void Attach(ProductEntity entity)
        {
            _context.Products.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
