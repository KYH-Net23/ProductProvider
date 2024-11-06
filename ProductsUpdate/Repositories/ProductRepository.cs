using Microsoft.EntityFrameworkCore;
using ProductsUpdate.Interfaces;
using Shared.Contexts;
using Shared.Models;

namespace ProductsUpdate.Repositories
{
    public class ProductRepository(ProductDbContext context) : IProductRepository
    {
        private readonly ProductDbContext _context = context;

        public async Task<ProductEntity?> GetProduct(int id)
        {
            try
            {
                return await _context.Products.FindAsync(id);
            }
            catch
            {
                return null!;
            }
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
