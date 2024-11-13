using Microsoft.AspNetCore.Mvc;
using ProductProvider.Interfaces;

namespace ProductProvider.Controllers
{
    [Route("api/getpagination")]
    [ApiController]
    public class GetPaginationController : Controller
    {
        private readonly IProductService _productService;

        public GetPaginationController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPages([FromQuery] int page = 1, [FromQuery] int limit = 20)
        {
            var paginatedResult = await _productService.GetPaginatedProductsAsync(page, limit);

            if (paginatedResult == null)
            {
                return NotFound("No products found");
            }

            return Ok(paginatedResult);
        }
    }
}
