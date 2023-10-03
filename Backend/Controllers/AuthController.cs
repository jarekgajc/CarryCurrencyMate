using Backend.Data;
using Backend.Models.User;
using Common.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers; 

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IConfiguration configuration;
    private readonly DataContext dataContext;

    public AuthController(IConfiguration configuration, DataContext dataContext)
    {
        this.configuration = configuration;
        this.dataContext = dataContext;
    }

    [HttpPost("register")]
    public async Task<User> Register(UserDto userDto)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

        User user = new User
        {
            Email = userDto.Email,
            PasswordHash = passwordHash
        };

        dataContext.Users.Add(user);
        await dataContext.SaveChangesAsync();

        return user;
    }

    [HttpPost("login")]
    public ActionResult<string> Login(UserDto userDto)
    {
        User? user = dataContext.Users.FirstOrDefault(user => user.Email == userDto.Email);
        if(user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
        {
            return BadRequest("Wrong credentials");
        }

        return CreateToken(user);
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value!));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}