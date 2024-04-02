using Microsoft.AspNetCore.Mvc;
using WarehouseMgmt.Application.Models.ProductsTypes;
using WarehouseMgmt.Application.Services.Interfaces;

namespace WarehouseMgmt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsTypes()
        {
            var productsTypes = await _productTypeService.GetAll();
            return Ok(productsTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productType = await _productTypeService.GetById(id);
            return Ok(productType);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductTypeRequestModel productType)
        {
            await _productTypeService.Add(productType);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProductTypeRequestModel productType, int id)
        {
            await _productTypeService.Update(productType, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productTypeService.Delete(id);
            return Ok();
        }
    }
}
