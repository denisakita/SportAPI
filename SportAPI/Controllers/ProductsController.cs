using Microsoft.AspNetCore.Mvc;
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


        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            return Ok(product);
        }
    }
}