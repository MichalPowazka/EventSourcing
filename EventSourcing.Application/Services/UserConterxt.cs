using EventSourcing.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Services
{

    public class UserConterxt(UserManager<User> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserContext
    {
        public async Task<User> GetCurrentUser()
        {
            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.User.Identity?.Name)){
                var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity?.Name);

                return user;
            }
            return null;
        }

        public async Task<IList<string>> GetCurrentUserRoles()
        {
            var user = await GetCurrentUser();
            List<string> roles = [];

            if (user != null)
            {
                roles = [.. (await _userManager.GetRolesAsync(user))];

            }
            return roles;
        }
    }
}
