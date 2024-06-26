﻿using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Domain.Entities;

public class User : IdentityUser<int>
{
    public string StreamId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }

}
