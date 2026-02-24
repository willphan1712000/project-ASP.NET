using APS.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Models.OrderEntity.Repo;

public class OrderRepo(DbContext context) : Repo<Order>(context), IOrderRepo
{
}