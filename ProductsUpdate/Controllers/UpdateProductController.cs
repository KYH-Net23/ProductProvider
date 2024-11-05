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
    public class UpdateProductController : ControllerBase
    {
        private readonly ProductRepository _repository;
        private readonly ProductFactory _factory;
        private readonly ILogger<UpdateProductController> _logger;
        public UpdateProductController(ProductRepository repository, ILogger<UpdateProductController> logger, ProductFactory factory)
        {
            _repository = repository;
            _logger = logger;
            _factory = factory;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModel updateProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _repository.GetProduct(id);
            if (product == null) return NotFound();
            product.Brand = updateProduct.Brand;
            product.Model = updateProduct.Model;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            product.Category = updateProduct.Category;
            product.Image = updateProduct.Image;
            product.Stock = updateProduct.Stock;
            product.Size = updateProduct.Size;
            product.AddedDate = updateProduct.AddedDate;
            var result = await _repository.SaveAsync();
            if (!result)
                return StatusCode(500, "Error updating the product OR no changes were made.");

            return Ok("Product updated successfully.");
        }
    }
}