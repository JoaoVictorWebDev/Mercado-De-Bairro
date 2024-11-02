using Microsoft.AspNetCore.Mvc;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface.Service;
using SuperMarket.Core.Services;
namespace SuperMarket.API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var result = _userService.RegisterUserAsync(userDTO);
            return Ok(new { Message = "User Created!", Data = result });
        }
        [HttpPost("/auth")]
        public async Task<IActionResult> Auth(string username, string password)
        {
                var token = TokenService.GenerateToken(new Core.Entities.User());
                return Ok(token);
            return BadRequest("Authentication Error !");
        }
    }
}
