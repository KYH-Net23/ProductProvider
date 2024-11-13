using Microsoft.EntityFrameworkCore;
using ProductProvider.Contexts;
using ProductProvider.Factories;
using ProductProvider.Interfaces;
using ProductProvider.Models;
using ProductProvider.Responses;
using System.Linq.Expressions;
namespace ProductProvider.Repositories
{
    public class ProductRepository(ProductDbContext context) : IProductRepository
    {
        private readonly ProductDbContext _context = context;

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<ProductEntity?> GetProductAsync(int id)
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
        public async Task<ProductModel> GetProductById(Expression<Func<ProductEntity, bool>> expression)
        {

            var entity = await _context.Products.FirstOrDefaultAsync(expression);
            return (entity != null) ? ProductFactory.Create(entity) : null!;
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
        public async Task<string> SaveAsync(ProductEntity entity)
        {
            try
            {
                entity.AddedDate = DateOnly.FromDateTime(DateTime.Now);
                await _context.Products.AddAsync(entity);
                await _context.SaveChangesAsync();
                return ResultResponse.Success;
            }
            catch
            {
                return ResultResponse.Failed;
            }
        }

        public async Task<bool> DeleteAsync(ProductEntity entity)
        {
            if (entity == null) return false;
            _context.Products.Remove(entity);
            var result = await SaveAsync();
            return result;
        }
    }
}
