using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;
    public ProductsController(IProductRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id) => Ok(await _repo.GetByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product) => Ok(await _repo.AddAsync(product));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id) return BadRequest();
        await _repo.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return NotFound();
        await _repo.DeleteAsync(product);
        return NoContent();
    }
}
