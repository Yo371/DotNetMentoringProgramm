using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/products/")]
        public IEnumerable<Product> GetAllProducts([FromQuery]int pageNumber = 0, [FromQuery] int pageSize = 10, [FromQuery] int? categoryId = null)
        {
            var products = _context.Products.AsQueryable();

            if (categoryId != null)
                products = products.Where(p => p.CategoryID == categoryId);

            return products.Skip(pageSize * pageNumber).Take(pageSize).ToList();
            
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        [HttpPut]
        [Route("api/products")]
        public void UpdateProduct([FromBody]Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        [HttpPost]
        [Route("api/products")]
        public void CreateProduct([FromBody] Product product)
        {
             _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("api/products")]
        public void CreateProduct(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges();
        }
    }
}
