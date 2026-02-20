using ASP.NET_Web.Models.CustomerEntity;

namespace ASP.NET_Web.Models.ProductEntity;

public class Product
{
    public int Id {get; set;}

    required public string Name {get; set;}

    required public float Price {get; set;}

    required public int Stock {get; set;}

    public List<Customer> Customers {get; set;} = [];

    public DateTime createdAt;
}