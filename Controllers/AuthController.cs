using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.API.DTOs.Auth;
using SmartTaskTracker.API.Services;

namespace SmartTaskTracker.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;

    public AuthController(AuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto dto)
    {
        _auth.Register(dto);
        return Ok("User registered");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var token = _auth.Login(dto);
        return Ok(new { token });
    }
}
