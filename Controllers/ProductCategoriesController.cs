using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.Models;
using PointOfSale.Request;
using PointOfSale.Resource;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductCategoriesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductCategoriesController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<ProductCategory> productCategories = await _appDbContext.ProductCategories.ToListAsync();
            return Ok(_mapper.Map<List<ProductCategoryResource>>(productCategories));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Show(int id)
        {
            ProductCategory? productCategories = await _appDbContext.ProductCategories.FindAsync(id);
            return Ok(_mapper.Map<ProductCategoryResource>(productCategories));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Store(StoreProductCategory productCategoryRequest)
        {
            ProductCategory productCategory = _mapper.Map<ProductCategory>(productCategoryRequest);
            await _appDbContext.ProductCategories.AddAsync(productCategory);
            await _appDbContext.SaveChangesAsync();
            
            return Ok(_mapper.Map<ProductCategoryResource>(productCategory));
        }
    }
}
