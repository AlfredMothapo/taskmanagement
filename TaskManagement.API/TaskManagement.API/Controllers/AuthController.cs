using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.BL.Repositories.Authentication;
using TaskManagement.BL.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            await _authRepository.RegisterAsync(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(BL.Models.LoginRequest request)
        {
            var user = await _authRepository.LoginAsync(request.EmailAddress, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            // Generate JWT token
            var token = Helpers.JwtHelper.GenerateJwtToken(user, _configuration);
            return Ok(new { Token = token });
        }

        [HttpPost("deactivate")]
        public async Task<IActionResult> Deactivate([FromBody] Guid userId)
        {
            await _authRepository.DeactivateUserAsync(userId);
            return Ok();
        }
      
    }

}
