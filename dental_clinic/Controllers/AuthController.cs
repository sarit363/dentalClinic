using dental_clinic.Core.entities;
using dental_clinic.Core.services;
using dental_clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;                                         
        private readonly IUserService _userService;                                     

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;                     
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // המר את ה-object ל-User
            var user = await _userService.GetByUserNameAsync(loginModel.UserName, loginModel.Password) as User;

            // אם המשתמש נמצא
            if (user != null)
            {
                var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.ToString()) // ודא ש-Role הוא טיפוס מתאים
        };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized(); // במקרה של משתמש לא נמצא
        }

    }

}
