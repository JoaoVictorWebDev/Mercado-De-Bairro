using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.API.JWT.Interface;
using SuperMarket.API.JWT.Model;
using SuperMarket.Core.Crypt;
using SuperMarket.Core.Entities;
using SuperMarket.Data.Contexts;
using System.Security.Claims;

namespace SuperMarket.API.Controllers

{
    [ApiController]
    [Route("api/auth/v1")]
    public class AuthController:ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AuthController(ApplicationDBContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("register")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Register([FromBody] RegisterUser userCredential)
        {
            try
            {
                var existingUser =  _context.User.FirstOrDefault(x => x.Username == userCredential.Username);
                if (existingUser != null)
                    return BadRequest(new { error = true, data = "User Exists" });

                if (string.IsNullOrWhiteSpace(userCredential.Password))
                    return BadRequest(new { error = true, data = "The field password is Mandatory!" });

                if (string.IsNullOrWhiteSpace(userCredential.Role) ||
                    (userCredential.Role != "admin" && userCredential.Role != "employee"))
                {
                    return BadRequest(new { error = true, data = "The Role must be 'Admin' or 'Employee' "});
                }

                var user = new User
                {
                    Username = userCredential.Username,
                    Password = SuperMarketCrypt.HashPassword(userCredential.Password), 
                    Role = userCredential.Role,
                    Email = userCredential.Email, 
                    FullName = userCredential.FullName, 
                    CreatedAt = DateTime.UtcNow
                };

                _context.User.Add(user);
                _context.SaveChanges();

                return Ok(new { success = true, data = "User Has been Registred" });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, data = e.Message });
            }
        }

        [HttpPost("login")]
        public async Task <ActionResult> Login([FromBody]UserCredential userCredential)
        {
            var user =  _context.User.FirstOrDefault(x => x.Username == userCredential.Username);

            if (user == null)
                return BadRequest(new { error = true, Data = "User Not Found" });
            bool isPasswordValid = SuperMarketCrypt.Verify(userCredential.Password, user.Password);
            if (!isPasswordValid)
                return Unauthorized(new { error = true, Data = "Invalid Password!" });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var authResponse = _jwtAuthenticationManager.Authenticate(user.Username, claims.ToArray());
            if(authResponse == null)
                return Unauthorized(new { error = true, data = "Authentication failed" });
            return Ok(new { success = true, data = new { authResponse.JwtToken, authResponse.RefreshToken, 
                Username = user.Username, Role = user.Role } });
        }
    }
}
