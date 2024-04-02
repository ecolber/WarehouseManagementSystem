using AutoMapper;
using WarehouseMgmt.Application.Models.Users;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, LoginResponseModel>().ReverseMap();
            CreateMap<LoginRequestModel, UserEntity>().ReverseMap();
        }
    }
}
