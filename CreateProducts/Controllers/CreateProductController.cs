using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateProduct()
        {

            return null!;



        }
    }
}
