using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.DataTransferObjects;
using PointOfSale.Models;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]ProductFilterData? productFilterData)
        {
            IQueryable<Product> products = _appDbContext.Products.Include(p => p.ProductCategory);
               
            if (productFilterData?.CategoryId != null)
            {
                products = products.Where(p => p.ProductCategoryId == productFilterData.CategoryId);
            }

            if (productFilterData?.Name != null)
            {
                products = products.Where(p => p.Name.Contains(productFilterData.Name));
            }

            return Ok(await products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Store(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            product.Id = id;
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            
            if (product is null) {
                return NotFound();
            }

            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return Ok(product);
        }
    }
}
