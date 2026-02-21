using ASP.NET_Web.Models.CustomerEntity;

namespace ASP.NET_Web.Models.MembershipTypeEntity;

public class MembershipType
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public List<Customer>? Customers {get; set;}

    public static readonly byte Unknown = 0;
    public static readonly byte PayAsyouGo = 1;
}