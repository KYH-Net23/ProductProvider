using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProvider.Factories;
using ProductProvider.Interfaces;
using ProductProvider.Models;

namespace ProductProvider.Controllers;

[Route("api/getproducts")]
[ApiController]
public class GetProductsController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var productEntities = await _service.GetAllProductsAsync();

        if (productEntities == null)
            return BadRequest();

        var productViewModels = ProductFactory.GetProducts(productEntities);

        return Ok(productViewModels);
    }
}