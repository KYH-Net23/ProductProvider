using CreateProducts.Models;
using CreateProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateProductController : ControllerBase
    {
        private readonly ProductService _productService;

        [HttpPost]
        public async Task CreateProduct(ProductModel model)
        {
           await _productService.CreateNewProduct(model);
        }
    }
}