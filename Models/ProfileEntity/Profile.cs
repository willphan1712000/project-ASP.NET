using ASP.NET_Web.Models.CustomerEntity;

namespace ASP.NET_Web.Models.ProfileEntity;

public class Profile
{
    public int Id {get; set;}
    public string? Address {get; set;}
    public string? Phone {get; set;}
    public string? Facebook {get; set;}
    public int? Customer_id {get;set;}
    public Customer? Customer {get; set;}
}