using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        var customers = new Models.CustomerEntity.Customers();
        return View(customers);
    }
}