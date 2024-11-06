using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsUpdate.Factories;
using ProductsUpdate.Models;
using ProductsUpdate.Repositories;
using ProductsUpdate.Services;
using Shared.Models;

namespace ProductsUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController(ProductService service) : ControllerBase
    {
        private readonly ProductService _service = service;

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModel updateProduct)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _service.UpdateProductAsync(id, updateProduct);

                if (result == 1) return Ok(new { Message = "Product updated successfully.", Result = updateProduct });
                else if (result == 0) return NotFound(new { Message = "Product was not found" });
                else if (result == -1) return StatusCode(500, new { Message = "Error updating the product OR no changes were made." });
                return BadRequest(new { Message = "Something went wrong " });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}