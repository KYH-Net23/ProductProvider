using Microsoft.AspNetCore.Mvc;
using ProductsDelete.Services;

namespace ProductsDelete
{
    [Route("[controller]")]
    [ApiController]
    public class ProductDeleteController : Controller
    {
        private readonly IProductService _productService;

        public ProductDeleteController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var success = _productService.DeleteProduct(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
