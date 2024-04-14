using EventSourcing.Domain.Entities;

namespace EventSourcing.Application.Services
{
    public interface IUserContext
    {
        Task<User> GetCurrentUser();
        Task<IList<string>> GetCurrentUserRoles();
    }
}
