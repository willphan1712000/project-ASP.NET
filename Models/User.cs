using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Web.Models;

public class User : IdentityUser
{
    public string? Initials {get; set;}
}