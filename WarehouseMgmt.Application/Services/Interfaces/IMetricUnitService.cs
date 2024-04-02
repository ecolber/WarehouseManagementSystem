using WarehouseMgmt.Application.Models.MetricsUnits;

namespace WarehouseMgmt.Application.Services.Interfaces
{
    public interface IMetricUnitService
    {
        Task<IEnumerable<MetricUnitResponseModel>> GetAll();
        Task<MetricUnitResponseModel> GetById(int id);
        Task Add(MetricUnitRequestModel entity);
        Task Update(MetricUnitRequestModel entity, int id);
        Task Delete(int id);
    }
}
