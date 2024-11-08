using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProvider.Interfaces;

namespace ProductProvider.Controllers
{
    [Route("api/getproducts")]
    [ApiController]
    public class GetProductsController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAllProductsAsync();

            if (products != null && products.Count > 0)
            {
                return Ok(products);
            }
            return BadRequest();
        }
    }
}
