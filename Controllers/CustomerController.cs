using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        var MembershipTypes = _context.MembershipType.ToList();
        var CustomerModelView = new NewCustomerViewModel {MembershipTypes = MembershipTypes};
        return View(CustomerModelView);
    }

    [HttpPost]
    public IActionResult Save(Customer customer)
    {
        if(!ModelState.IsValid)
        {
            var modelView = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("New", modelView);
        }
        if(customer.Id == 0)
        {
            _context.Customer.Add(customer);
        }
        else
        {
            var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);
            customerInDb.Name = customer.Name;
            customerInDb.Email = customer.Email;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Customer");
    }

    public IActionResult Edit(int id)
    {
        var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
        if(customer == null)
        {
            return NotFound();
        }

        var modelView = new NewCustomerViewModel
        {
            Customer = customer,
            MembershipTypes = _context.MembershipType.ToList()
        };

        return View("New", modelView);
    }
}