using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProvider.Interfaces;

namespace ProductProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            try
            {
                var result = await _service.GetProductById(id);

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
