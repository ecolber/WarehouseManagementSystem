using AutoMapper;
using WarehouseMgmt.Application.Models.MetricsUnits;
using WarehouseMgmt.Application.Services.Interfaces;
using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;

namespace WarehouseMgmt.Application.Services
{
    public class MetricUnitServices : IMetricUnitService
    {
        private readonly IMetricUnitRepository _metricUnitRepository;
        private readonly IMapper _mapper;

        public MetricUnitServices(IMetricUnitRepository metricUnitRepository, IMapper mapper)
        {
            _metricUnitRepository = metricUnitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MetricUnitResponseModel>> GetAll()
        {
            var metricUnitEntity = await _metricUnitRepository.GetAllAsync();

            var metricUnitResponseModel = _mapper.Map<IEnumerable<MetricUnitResponseModel>>(metricUnitEntity);

            return metricUnitResponseModel;
        }

        public async Task<MetricUnitResponseModel> GetById(int id)
        {
            var metricUnitEntity = _metricUnitRepository.GetByIdSync(id);

            var metricUnitResponseModel = _mapper.Map<MetricUnitResponseModel>(metricUnitEntity);

            return metricUnitResponseModel;
        }

        public async Task Add(MetricUnitRequestModel entity)
        {
            var metricUnitEntity = _mapper.Map<MetricUnitEntity>(entity);
            await _metricUnitRepository.AddAsync(metricUnitEntity);
            await _metricUnitRepository.SaveChangesAsync();
        }

        public async Task Update(MetricUnitRequestModel entity, int id)
        {
            MetricUnitEntity metricUnitEntityFound = await _metricUnitRepository.GetByIdAsync(id) ?? throw new Exception("La unidad de medida no existe");

            var metricUnitEntity = _mapper.Map(entity, metricUnitEntityFound);

            await _metricUnitRepository.UpdateAsync(metricUnitEntity);
            await _metricUnitRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _metricUnitRepository.DeleteAsync(id);
            await _metricUnitRepository.SaveChangesAsync();
        }
    }
}
