namespace ASP.NET_Web.Models.EntityConfiguration;

public enum OrderStatus
{
    PENDING = 1,
    FAILED = 2
}

public class Order
{
    public int Id {set; get;}

    public int Customer_id {get; set;}
    required public Customer Customer {get; set;}

    public float Price {get; set;}

    public DateTime CreatedAt {set; get;}

    public OrderStatus Status {set; get;}
}