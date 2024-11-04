using Microsoft.AspNetCore.Mvc;

namespace ProductsDelete.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductDeleteController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //
        //public ProductDeleteController()
        //{
        //    //_context = context;
        //}
        //
        //[HttpDelete("{id}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    var project = _context.products.Find(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.products.Remove(project);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
