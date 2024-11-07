using ProductsDelete.Data;
using ProductsDelete.Models;

namespace ProductsDelete.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return false;
            }

            _context.products.Remove(product);
            _context.SaveChanges();
            return true; 
        }
    }
}