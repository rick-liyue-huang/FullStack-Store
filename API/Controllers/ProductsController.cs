using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // https://localhost:5000/api/products
    public class ProductsController(StoreContext context) : ControllerBase
    {

      [HttpGet]
      public async Task<ActionResult<List<Product>>> GetProducts()
      {
        return await context.Products.ToListAsync();
      }

      [HttpGet("{id}")] // https://localhost:5000/api/products/1
      public async Task<ActionResult<Product>> GetProduct(int id)
      {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
          return NotFound();
        }
        return product;
      }
    }
}
