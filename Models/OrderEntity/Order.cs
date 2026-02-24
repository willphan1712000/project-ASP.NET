using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.OrderItemEntity;

namespace ASP.NET_Web.Models.OrderEntity;

public enum OrderStatus
{
    CHECKOUT = 1,
    RETURN = 2
}

public class Order
{
    public int Id {set; get;}

    public int Customer_id {get; set;}
    required public Customer Customer {get; set;}

    public float Price {get; set;}

    public DateTime RentDate {set; get;} = DateTime.Now;

    public DateTime ReturnDate {set; get;}

    public OrderStatus Status {set; get;}

    required public List<OrderItem> OrderItems {get;set;}
}