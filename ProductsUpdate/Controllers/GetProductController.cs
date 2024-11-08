using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsUpdate.Interfaces;
using Shared.Models;

namespace ProductsUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductController(IProductRepository repository) : ControllerBase
    {
        private readonly IProductRepository _repository = repository;

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetOneAsync(int id)
        {
            try
            {
                var entity = await _repository.GetProduct(id);
                if (entity != null) return Ok(entity);
                else return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
