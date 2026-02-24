using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.ProductEntity;

namespace ASP.NET_Web.Models.OrderItemEntity;

public class OrderItem
{
    public int Id {get; set;}
    public OrderStatus Status {get; set;}

    public int OrderId {get; set;}
    public Order? Order {get; set;}

    public int ProductId {get; set;}
    public Product? Product {get; set;}
}