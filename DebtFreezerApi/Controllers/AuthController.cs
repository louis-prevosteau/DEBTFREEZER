using DebtFreezerApi.Dtos;
using DebtFreezerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebtFreezerApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwt)
        {
            _authService = authService;
            _jwtService = jwt;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = _authService.Register(dto);
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token, user });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _authService.Login(dto);
            if (user == null)
            {
                return Unauthorized();
            }
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token, user });
        }
    }
}
