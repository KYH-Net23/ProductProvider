using Microsoft.AspNetCore.Mvc;
using ProductProvider.Enums;
using ProductProvider.Interfaces;

namespace ProductProvider.Controllers
{
    [Route("api/sortproducts")]
    [ApiController]
    public class SortProductsController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;
        [HttpGet]
        public async Task<IActionResult> SortProducts([FromQuery] SortOption sortOption)
        {
            var sortedProducts = await _service.SortProductsAsync(sortOption);

            if (sortedProducts == null || sortedProducts.Count == 0)
                return BadRequest("No products available to sort.");

            return Ok(sortedProducts);
        }

    }
}
