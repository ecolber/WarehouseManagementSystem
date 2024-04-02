using Microsoft.AspNetCore.Mvc;
using WarehouseMgmt.Application.Models.ProductsTypes;
using WarehouseMgmt.Application.Models.Users;
using WarehouseMgmt.Application.Services;
using WarehouseMgmt.Application.Services.Interfaces;

namespace WarehouseMgmt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService serService)
        {
            _userService = serService;
        }

        //[HttpPost]
        //public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        //{
        //    var response = _userService.Login(loginRequest);
        //    if (response == null)
        //    {
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    }

        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> GetUser([FromBody] LoginRequestModel user)
        {
           var userData = await _userService.GetUser(user.UserName, user.Password);
            return Ok(userData);
        }
    }
}