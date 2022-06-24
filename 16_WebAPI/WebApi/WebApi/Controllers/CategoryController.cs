using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController
    {
        private ShopContext _context;

        public CategoryController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/categories/")]
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToArray();
        }

        [HttpGet]
        [Route("api/categories/{id}")]
        public Product GetCategory(int id)
        {
            return _context.Products.Find(id);
        }

        [HttpPut]
        [Route("api/categories")]
        public void UpdateCategory([FromBody] Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        [HttpPost]
        [Route("api/categories")]
        public void CreateProduct([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("api/categories/{id}")]
        public void DeleteCategory(int id)
        {
            _context.Categories.Remove(_context.Categories.Find(id));
            _context.SaveChanges();
        }
    }
}
