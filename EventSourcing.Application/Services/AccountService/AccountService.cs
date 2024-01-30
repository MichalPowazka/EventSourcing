//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace EventSourcing.Application.Services.AccountService
//{
//    public class AccountService : IAccountService
//    {
//        private readonly MovieApiDbContext _dbContext;
//        private readonly IPasswordHasher<User> _passwordHasher;
//        private readonly AuthenticationSettings _authenticationSettings;

//        public AccountService(MovieApiDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
//        {
//            _dbContext = dbContext;
//            _passwordHasher = passwordHasher;
//            _authenticationSettings = authenticationSettings;
//        }

//        public void RegisterUser(RegisterUserDto userDto)
//        {
//            var newUser = new User()
//            {
//                UserName = userDto.UserName,
//                Email = userDto.Email,
//                PasswordHash = userDto.Password,
//                Nationality = userDto.Nationality,
//                RoleId = userDto.RoleId

//            };

//            var hasshedPassword = _passwordHasher.HashPassword(newUser, userDto.Password);

//            newUser.PasswordHash = hasshedPassword;
//            _dbContext.Users.Add(newUser);
//            _dbContext.SaveChanges();
//        }

//        public string GenerateJwt(LoginDto loginDto)
//        {
//            var user = _dbContext.Users
//                .Include(u => u.Role)
//                .FirstOrDefault(u => u.Email == loginDto.Email);

//            if (user is null)
//            {
//                throw new BadRequestException("Invalid ussername or password");
//            }

//            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

//            if (result == PasswordVerificationResult.Failed)
//            {
//                throw new BadRequestException("Invalid ussername or password");
//            }

//            var claims = new List<Claim>()
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                new Claim(ClaimTypes.Name, $"{user.UserName}"),
//                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
//                new Claim("Nationality", user.Nationality),

//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
//            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

//            var token = new JwtSecurityToken(
//                _authenticationSettings.JwtIssuer,
//                _authenticationSettings.JwtIssuer,
//                claims,
//                expires: expires,
//                signingCredentials: cred);

//            var tokenHandler = new JwtSecurityTokenHandler();
//            return tokenHandler.WriteToken(token);
//        }
//    }
//}
