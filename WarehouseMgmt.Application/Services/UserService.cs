using AutoMapper;
using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Application.Models.Users;
using WarehouseMgmt.Application.Services.Interfaces;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Repositories;

namespace WarehouseMgmt.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IJWTService _jwtService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IJWTService jwtService, IUserRepository userRepository, IMapper mapper)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> Login(LoginRequestModel request)
        {
            var loginSuccess = _userRepository.Login(request.UserName, request.Password);

            if (loginSuccess) { return _jwtService.GenerateToken(request.UserName, request.Password); }

            return "Ha ocurrido un error al intentar logearse";
        }

        public async Task<LoginResponseModel> GetUser(string username, string password)
        {
            var userEntity = _userRepository.GetByUserName(username, password);

            var loginResponseModel = _mapper.Map<LoginResponseModel>(userEntity);

            return loginResponseModel;
        }
    }
}