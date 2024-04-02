using AutoMapper;
using WarehouseMgmt.Application.Models.Products;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductResponseModel>().ReverseMap();
            CreateMap<ProductRequestModel, ProductEntity>().ReverseMap();
        }
    }
}
