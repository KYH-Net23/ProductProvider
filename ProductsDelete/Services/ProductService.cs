using ProductsDelete.Data;

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
            var product = _context.products.FirstOrDefault(p => p.Id == id && !p.IsDeleted); 
            if (product == null)
            {
                return false;  
            }

            product.IsDeleted = true;  
            _context.SaveChanges();
            return true;
        }
    }
}
