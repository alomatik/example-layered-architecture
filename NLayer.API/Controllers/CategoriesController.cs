using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategoriesWithProducts")]
        public async Task<IActionResult> GetCategoriesWithProducts()
        {
            var cWithPDto = await _categoryService.GetCategorieswithProductsAsync();
            return StatusCode(200, cWithPDto);
        }

        [HttpGet("GetCategoryWithProducts")]
        public async Task<IActionResult> GetCategoryWithProducts(int categoryId)
        {
            var cWithPDto = await _categoryService.GetByCategoryIdwithProductsAsync(categoryId);
            return StatusCode(200, cWithPDto);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            return StatusCode(200, categories); 
        }
    }
}
