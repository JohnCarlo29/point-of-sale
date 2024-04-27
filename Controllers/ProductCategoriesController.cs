using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.Models;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductCategoriesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductCategoriesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productCategories = await _appDbContext.ProductCategories.ToListAsync();
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var ProductCategories = await _appDbContext.ProductCategories.FindAsync(id);
            return Ok(ProductCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Store(ProductCategory productCategory)
        {
            await _appDbContext.ProductCategories.AddAsync(productCategory);
            var category = await _appDbContext.SaveChangesAsync();
            return Ok(category);
        }
    }
}
