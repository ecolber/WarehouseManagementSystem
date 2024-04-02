using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Application.Models.Users;

namespace WarehouseMgmt.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(LoginRequestModel request);
        Task<LoginResponseModel> GetUser(string userName, string password);
    }
}
