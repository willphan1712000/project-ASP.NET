using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        (new CustomerRepo()).GetCustomersExtension();
        return View(new Customers());
    }
}