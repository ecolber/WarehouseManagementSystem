using AutoMapper;
using WarehouseMgmt.Application.Models.MetricsUnits;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Application.Profiles
{
    public class MetricUnitProfile : Profile
    {
        public MetricUnitProfile()
        {
            CreateMap<MetricUnitEntity, MetricUnitResponseModel>().ReverseMap();
            CreateMap<MetricUnitRequestModel, MetricUnitEntity>().ReverseMap();
        }
    }
}
