using Microsoft.AspNetCore.Mvc;
using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Application.Services.Interfaces;

namespace WarehouseMgmt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]

        public async Task<IActionResult> GetAllCategories()
        {
            _logger.LogInformation("Obtener todas las categorias");
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryRequestModel category)
        {
            await _categoryService.Add(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CategoryRequestModel category, int id)
        {
            await _categoryService.Update(category, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
    }
}
