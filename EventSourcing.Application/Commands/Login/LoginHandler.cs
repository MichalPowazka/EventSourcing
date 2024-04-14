using EventSourcing.Domain.Entities;
using EventSourcingApi;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace EventSourcing.Application.Commands.Login;

public class LoginHandler(UserManager<User> _userManager, JwtOptions jwtOptions) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new ApplicationException("Invalid username or password.");
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        var roles = await _userManager.GetRolesAsync(user);
        if (!isPasswordValid)
        {
            return new LoginResponse
            {
                Message = "Niepoprawny login lub hasło",
                Token = null,
                isSuccess = false
            };
        }

        var token = GenerateJwtToken(user, roles);

        return new LoginResponse
        {
            Token = token.ToString(),
            Message = "Logowanie zakończyło się sukcesem",
            isSuccess = true
        };
    }
    private string GenerateJwtToken(User user, IList<string> roles)
    {

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };

        claims.AddRange(from role in roles select new Claim(ClaimTypes.Role, role));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,
            Audience = jwtOptions.Audience,
            Issuer = jwtOptions.Issuer,
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);



    }



}