namespace ASP.NET_Web.Models.OrderEntity;

public class OrderRepo
{
    private readonly AspNetWebContext Context;
    public OrderRepo()
    {
        Context = new AspNetWebContext();
    }

    public void CreateOrder()
    {
        var customer = Context.Customer.Single(c => c.Id == -1);

        // Context marks this as added state
        Context.Order.Add(
            new Order { Customer = customer, Price = 56, Status = OrderStatus.PENDING }
        );

        // Context will create insert SQL
        Context.SaveChanges();
    }

    public void UpdateOrder()
    {
        // Context marks this as unchanged state
        var order = Context.Order.Find(3)!;

        // Context marks this as modified state
        order.Price = 100;
        order.Status = OrderStatus.PENDING;

        // Context will create update SQL
        Context.SaveChanges();
    }

    public void DeleteOrder()
    {
        // Context marks this as unchanged state
        var order = Context.Order.Find(5)!;

        // Context marks this as deleted state
        Context.Remove(order);

        // Context will create delete SQL
        Context.SaveChanges();
    }
}