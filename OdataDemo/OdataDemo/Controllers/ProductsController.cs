using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OdataDemo.Data.Entities;

namespace OdataDemo.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly StoreDbContext _dbContext;

        public ProductsController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Products.AsQueryable());
        }

        [EnableQuery]
        public IActionResult GetCategory([FromODataUri] int key)
        {
            var result = _dbContext.Products.Where(m => m.Id == key).Select(m => m.Category);
            return Ok(result);
        }
        
        [EnableQuery]
        public IActionResult GetRefToCategory([FromODataUri] int key)
        {
            var result = _dbContext.Products.Where(m => m.Id == key).Select(m => m.Category);
            return Ok(result);
        }
        
        public ActionResult CreateRefToCategory([FromRoute] int key, [FromRoute] int relatedKey)
        {
            var product = _dbContext.Products.SingleOrDefault(d => d.Id.Equals(key));
            var category = _dbContext.Categories.SingleOrDefault(d => d.Id.Equals(relatedKey));
            if (product == null)
            {
                return NotFound("Product Not Found");
            }
            
            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            product.Category = category;
            _dbContext.Update(product);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }

    public class CategoriesController : ODataController
    {
        private readonly StoreDbContext _dbContext;

        public CategoriesController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Categories);
        }
        
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return _dbContext.Categories.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
        }

    }
}