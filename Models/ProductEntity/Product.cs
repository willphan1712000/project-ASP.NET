using ASP.NET_Web.Models.CustomerEntity;

namespace ASP.NET_Web.Models.ProductEntity;

public class Product(String name)
{
    public int Id {get; set;}

    public string Name {get; set;} = name;

    public float Price {get; set;}

    public List<Customer> Customers {get; set;} = [];

    public DateTime createdAt;
}