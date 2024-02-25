using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
