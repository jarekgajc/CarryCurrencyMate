using Backend.Models.Accounts;
using Backend.Models.Appsettings;
using Backend.Models.Exceptions;
using Backend.Models.Users;
using Backend.Services.AccountServices;
using Backend.Services.UserServices;
using Common.Models.Error.Api;
using Common.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers; 

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly IAccountService _accountService;

    public AuthController(IConfiguration configuration, IUserService userService, IAccountService accountService)
    {
        _configuration = configuration;
        _userService = userService;
        _accountService = accountService;
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

        await _userService.CreateUser(user);

        return user;
    }

    [HttpPost("login")]
    public async Task<string> Login(UserDto userDto)
    {
        User? user = await _userService.GetUserByEmail(userDto.Email);
        if(user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
        {
            throw new ApiException(new CredentialsNotFound());
        }

        return await CreateToken(user);
    }

    private async Task<string> CreateToken(User user)
    {
        var jwt = _configuration.GetSection(nameof(Jwt)).Get<Jwt>();

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, jwt.Aud),
            new Claim(JwtRegisteredClaimNames.Iss, jwt.Iss),
            new Claim("accountId", (await _accountService.GetOrCreateUserAccount(user)).Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: cred
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return jwtToken;
    }
}