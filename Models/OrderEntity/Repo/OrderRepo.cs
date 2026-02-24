using APS.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Models.OrderEntity.Repo;

public class OrderRepo(AspNetWebContext context) : Repo<Order>(context), IOrderRepo
{
    public readonly AspNetWebContext _context = context;

    // Get order with all products - eager load
    public Order? GetOrderWithProducts(int id)
    {
        return _context.Order
            .Include(o => o.OrderItems)
            .FirstOrDefault(o => o.Id == id);
    }
}