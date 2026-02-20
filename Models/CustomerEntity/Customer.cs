using System.ComponentModel.DataAnnotations;
using ASP.NET_Web.Models.MembershipTypeEntity;
using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProfileEntity;

namespace ASP.NET_Web.Models.CustomerEntity;

public class Customer
{
    public int Id {get; set;}
    required public string Name { get; set;}
    required public string Password { get; set;}
    required public string Email { get; set;}
    public List<Order> Orders {get; set;} = [];
    public List<Product> Products {get; set;} = [];
    public Profile? Profile {get; set;}

    [Display(Name = "Membership Type")]
    public int MembershipTypeId {get; set;}
    public MembershipType? MembershipType {get; set;}
}