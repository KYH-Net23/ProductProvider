using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsUpdate.Factories;
using ProductsUpdate.Models;
using ProductsUpdate.Repositories;
using Shared.Models;

namespace ProductsUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController(ProductRepository repository) : ControllerBase
    {
        private readonly ProductRepository _repository = repository;

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModel updateProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = await _repository.GetProduct(id);
            if (product == null) return NotFound();

            ProductFactory.MapExistingEntityFromModel(ref product, updateProduct);
            var result = await _repository.SaveAsync();
            if (!result) return StatusCode(500, "Error updating the product OR no changes were made.");

            return Ok("Product updated successfully.");
        }

    }
}