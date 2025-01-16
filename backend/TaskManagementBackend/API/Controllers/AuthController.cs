using Microsoft.AspNetCore.Mvc;
using TaskManagementBackend.Core.Entities;
using TaskManagementBackend.Core.Interfaces;
using TaskManagementBackend.Infrastructure.Data;

namespace TaskManagementBackend.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly TaskManagementDbContext _context;
        private readonly IAuthService _authService;

        public AuthController(TaskManagementDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
                return BadRequest("Username already exists.");

            user.PasswordHash = _authService.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginRequest.Username);
            if (user == null || !_authService.VerifyPassword(loginRequest.PasswordHash, user.PasswordHash))
                return Unauthorized("Invalid username or password.");

            var token = _authService.GenerateJwtToken(user.Id, user.Username);
            return Ok(new { Token = token });
        }
    }
}
