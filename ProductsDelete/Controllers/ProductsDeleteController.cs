using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsDelete.Data;

namespace ProductsDelete
{

    [Route("[controller]")]
    [ApiController]
    public class ProductDeleteController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductDeleteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}