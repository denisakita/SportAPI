using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportAPI.Models;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // [HttpGet]
        // public IEnumerable<Product> GetAllProducts()
        // {
        //     return _context.Products.ToArray();
        // }


        // [HttpGet]
        // public ActionResult GetAllProducts()
        // {
        //     var products = _context.Products.ToList();
        //     return Ok(products);
        // }

        // [HttpGet]
        // public async Task<IEnumerable<Product>> GetAllProducts()
        // {
        //     return await _context.Products.ToListAsync();
        // }
        //
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        
        // [HttpGet]
        // public async Task<IActionResult> GetAllProducts()
        // {
        //     var products = await _context.Products.ToListAsync();
        //     return Ok(products);
        // }

        //
        // [HttpGet("{id}")]
        // public ActionResult GetProduct(int id)
        // {
        //     var product = _context.Products.Find(id);
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(product);
        // }
        
        [HttpGet("{id}")]
        public async Task<ActionResult>GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}