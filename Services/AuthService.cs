using SmartTaskTracker.API.Data;
using SmartTaskTracker.API.DTOs.Auth;
using SmartTaskTracker.API.Helpers;
using SmartTaskTracker.API.Models;

namespace SmartTaskTracker.API.Services;

public class AuthService
{
    private readonly AppDbContext _db;
    private readonly JwtTokenGenerator _jwt;

    public AuthService(AppDbContext db, JwtTokenGenerator jwt)
    {
        _db = db;
        _jwt = jwt;
    }

    public void Register(RegisterDto dto)
    {
        if (_db.Users.Any(u => u.Email == dto.Email))
            throw new Exception("User already exists");

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = PasswordHasher.Hash(dto.Password)
        };

        _db.Users.Add(user);
        _db.SaveChanges();
    }

    public string Login(LoginDto dto)
    {
        var user = _db.Users.FirstOrDefault(u => u.Email == dto.Email);

        if (user == null)
            throw new Exception("Invalid credentials");

        // ✅ VERIFY, don't re-hash
        if (!PasswordHasher.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        return _jwt.GenerateToken(user.Id, user.Email);
    }
}

