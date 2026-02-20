using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.OrderEntity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        // (new CustomerRepo()).EagerLoading();
        // (new OrderRepo()).CreateOrder();
        // (new OrderRepo()).UpdateOrder();
        // (new OrderRepo()).DeleteOrder();
        return View(new Customers());
    }
}