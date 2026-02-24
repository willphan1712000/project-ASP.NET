using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.OrderItemEntity;

namespace ASP.NET_Web.Models.ProductEntity;

public class Product
{
    public int Id {get; set;}
    required public string Name {get; set;}
    required public float Price {get; set;}
    required public int Stock {get; set;}
    public List<Customer> Customers {get; set;} = [];
    public DateTime createdAt;
    public List<OrderItem>? Items {get; set;}
}