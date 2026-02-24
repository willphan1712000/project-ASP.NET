using ASP.NET_Web.Repo;

namespace ASP.NET_Web.Models.OrderEntity.Repo;

public interface IOrderRepo : IRepo<Order>
{
    public Order? GetOrderWithProducts(int id);
}