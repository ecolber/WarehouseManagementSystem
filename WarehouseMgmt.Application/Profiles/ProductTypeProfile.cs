using AutoMapper;
using WarehouseMgmt.Application.Models.ProductsTypes;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Application.Profiles
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductTypeEntity, ProductTypeResponseModel>().ReverseMap();
            CreateMap<ProductTypeRequestModel, ProductTypeEntity>().ReverseMap();
        }
    }
}
