using Microsoft.AspNetCore.Mvc;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Controllers
{
    [Route("api/searchproducts")]
    [ApiController]
    public class SearchProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> SearchProducts([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query cannot be empty.");
            }

            var products = await _productService.ProductSearchAsync(query);
            return Ok(products);
        }
    }
    }
