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

        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest();
            // }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id },
                product);
        }
        
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p=>p.Id == id))
                {
                    return NotFound();
                }

                throw;
            }
            
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            
            return Ok(product);
        }
        
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultiple([FromQuery]int[] ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                products.Add(product);
            }

            
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
            
            return Ok(products);
        }

    }
    

}