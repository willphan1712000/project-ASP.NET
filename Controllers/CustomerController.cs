using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.OrderEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Controllers;

public class CustomerController : Controller
{
    private AspNetWebContext _context;
    public CustomerController()
    {
        _context = new AspNetWebContext();
    }
    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
        base.Dispose(disposing);
    }
    public IActionResult Index()
    {
        var customers = _context.Customer.ToList();
        return View(customers);
    }
    [Route("Customer/Details/{Id}")]
    public IActionResult Details(int Id)
    {
        var orders = _context.Order.Where(o => o.Customer_id == Id).ToList();
        return View(orders);
    }

    public IActionResult New() {
        return View();
    }
}