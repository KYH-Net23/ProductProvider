using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProvider.Factories;
using ProductProvider.Interfaces;

namespace ProductProvider.Controllers;

[Route("api/getproducts")]
[ApiController]
public class GetProductController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync(int id)
    {
        try
        {
            var productEntity = await _service.GetProductAsync(id);

            if (productEntity == null)
                return BadRequest();

            var productViewModel = ProductFactory.GetProduct(productEntity);

            return Ok(productViewModel);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
}