using ASP.NET_Web.Models.EntityConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        var customers = new Customers();
        return View(customers);
    }
}