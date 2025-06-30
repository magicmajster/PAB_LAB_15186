using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly TokenService _tokenService;

        public AuthController(
            IUserRepository userRepo,
            TokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var user = await _userRepo.GetByUsernameAsync(loginDto.Username);

            if (user == null || user.PasswordHash != loginDto.Password)
                return Unauthorized("Invalid credentials");

            return _tokenService.CreateToken(user);
        }
    }

    public record LoginDto(string Username, string Password);
}