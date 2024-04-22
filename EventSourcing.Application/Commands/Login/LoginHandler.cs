using EventSourcing.Domain.Entities;
using EventSourcingApi;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventSourcing.Application.Commands.Login;

public class LoginHandler(UserManager<User> _userManager, JwtOptions jwtOptions) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new LoginResponse
            {
                Message = "Nie znaleziono uzytkownika",
                Token = null,
                isSuccess = false
            };
        }

        if (!user.IsActive)
        {
            return new LoginResponse
            {
                Message = "Użytkownik nie aktywny",
                Token = null,
                isSuccess = false
            };
        }


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