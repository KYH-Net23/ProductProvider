using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModel updateProduct)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _service.UpdateProductAsync(id, updateProduct);

                if (result == 1) return Ok(new { Message = "Product updated successfully.", Result = updateProduct });
                else if (result == 2) return BadRequest(new { Message = "Something went wrong " });
                else if (result == 0) return StatusCode(500, new { Message = "Error updating the product OR no changes were made." });
                else return NotFound(new { Message = "Product was not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
