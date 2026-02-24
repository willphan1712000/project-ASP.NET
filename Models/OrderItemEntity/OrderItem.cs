using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.ProductEntity;

namespace ASP.NET_Web.Models.OrderItemEntity;

public class OrderItem
{
    public int Id {get; set;}

    public int OrderId {get; set;}
    required public Order Order {get; set;}

    public int ProductId {get; set;}
    required public Product Product {get; set;}
}