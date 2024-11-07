using CreateProducts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProductsCreate;

namespace CreateProducts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public CreateProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductModel model)
        {
            try
            {
                var result = await _productService.CreateNewProduct(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
         
        }
    }
}