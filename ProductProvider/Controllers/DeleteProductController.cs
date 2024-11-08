using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProvider.Interfaces;

namespace ProductProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _service.DeleteProduct(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
