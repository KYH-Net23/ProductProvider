using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController : ControllerBase
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
        //    product.Title = updateProduct.Title;
        //    product.Description = updateProduct.Description;
        //    product.Price = updateProduct.Price;
        //    product.Category = updateProduct.Category;
        //    product.Image = updateProduct.Image;
        //    product.Stock = updateProduct.Stock;
        //    product.Size = updateProduct.Size;

        //    var result = await _productRepository.UpdateProductAsync(product);
        //    if (!result)
        //        return StatusCode(500, "Error updating the product.");

        //    return Ok("Product updated successfully.");
    }
}
