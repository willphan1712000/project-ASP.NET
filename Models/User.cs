using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Web.Models;

public class User : IdentityUser
{
    public string? Initials {get; set;}
}

public class UserRole
{
    public const string ADMIN = "Admin";
    public const string CUSTOMER = "Customer";
}