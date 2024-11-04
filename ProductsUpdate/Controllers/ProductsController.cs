using Microsoft.AspNetCore.Mvc;

namespace ProductsUpdate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        ////private readonly IProductRepository _productRepository;
        ////public ProductsController(IProductRepository productRepository)
        ////{
        ////    _productRepository = productRepository;
        ////}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductEntity updateProduct)
        //{
        //    if (!ModelState.IsValid) 
        //        return BadRequest(ModelState);

        //    var product = await _productRepository.GetProductByIdAsync(id);
        //    if (product == null)
        //        return NotFound();

        //    product.Name = updateProduct.Name;
        //    product.Price = updateProduct.Price;
        //    product.Description = updateProduct.Description;

        //    var result = await _productRepository.UpdateProductAsync(product);
        //    if (!result)
        //        return StatusCode(500, "Error updating the product.");

        //    return Ok("Product updated successfully.");
        } 
    }

