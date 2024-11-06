using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsRead.Services;

namespace ProductsRead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadService _productReadService;

        public ProductsController(IProductReadService productReadService)
        {
            _productReadService = productReadService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            try
            {
                var result = await _productReadService.GetProductById(id);

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }          
        }
    }
}
