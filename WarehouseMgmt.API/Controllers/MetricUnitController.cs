using Microsoft.AspNetCore.Mvc;
using WarehouseMgmt.Application.Models.MetricsUnits;
using WarehouseMgmt.Application.Models.Products;
using WarehouseMgmt.Application.Services.Interfaces;

namespace WarehouseMgmt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricUnitController : ControllerBase
    {
        private readonly IMetricUnitService _metricUnitService;

        public MetricUnitController(IMetricUnitService metricUnitService)
        {
            _metricUnitService = metricUnitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMetricsUnit()
        {
            var metricsUnits = await _metricUnitService.GetAll();
            return Ok(metricsUnits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var metricUnit = await _metricUnitService.GetById(id);
            return Ok(metricUnit);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MetricUnitRequestModel metricUnit)
        {
            await _metricUnitService.Add(metricUnit);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] MetricUnitRequestModel metricUnit, int id)
        {
            await _metricUnitService.Update(metricUnit, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _metricUnitService.Delete(id);
            return Ok();
        }
    }
}
