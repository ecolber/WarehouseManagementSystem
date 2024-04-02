using AutoMapper;
using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryResponseModel>().ReverseMap();
            CreateMap<CategoryRequestModel, CategoryEntity>().ReverseMap();
        }
    }
}
