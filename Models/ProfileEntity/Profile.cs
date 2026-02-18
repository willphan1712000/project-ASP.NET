using ASP.NET_Web.Models.CustomerEntity;

namespace ASP.NET_Web.Models.ProfileEntity;

public class Profile (string address, string phone, string facebook)
{
    public int Id {get; set;}
    public string Address {get; set;} = address;
    public string Phone {get; set;} = phone;
    public string Facebook {get; set;} = facebook;
    public int? Customer_id {get;set;}
    public Customer? Customer {get; set;}
}