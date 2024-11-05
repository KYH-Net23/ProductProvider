using CreateProducts.Models;
using CreateProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateProducts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateProductController : ControllerBase
    {
        private readonly ProductService _productService = null!;

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductModel model)
        {
           await _productService.CreateNewProduct(model);
           return Ok();
        }
    }
}