using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductProvider.Contexts;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Controllers
{
    [Route("api/createproduct")]
    [ApiController]
    public class CreateProductController(IProductService service, ProductDbContext context) : ControllerBase
    {
        private readonly IProductService _service = service;
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductModel model)
        {
            var productCategory = await context.Categories
                .FirstOrDefaultAsync(x => x.CategoryName == model.Category);
            if (productCategory == null)
            {
                return BadRequest(new {ModelState});
            }
            try
            {
                var result = await _service.CreateProductAsync(model, productCategory);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new {ModelState});
            }
        }
    }
}
