using CreateProducts.Interfaces;
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
        private readonly IProductService _productService;

        public CreateProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductModel model)
        {
           await _productService.CreateNewProduct(model);
           return Ok();
        }
    }
}