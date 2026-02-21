using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity.dto;
using ASP.NET_Web.Models.CustomerEntity.ViewModels;
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
    [ValidateAntiForgeryToken]
    public IActionResult SaveNew(CreateCustomerDTO createCustomerDTO)
    {
        if(!ModelState.IsValid)
        {
            var modelView = new NewCustomerViewModel
            {
                CreateCustomerDTO = createCustomerDTO,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("New", modelView);
        }

        _context.Customer.Add(CreateCustomerDTO.ToEntity(createCustomerDTO));
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

        var modelView = new EditCustomerViewModel
        {
            EditCustomerDTO = EditCustomerDTO.ToDTO(customer),
            MembershipTypes = _context.MembershipType.ToList()
        };

        return View(modelView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveEdit(EditCustomerDTO editCustomerDTO)
    {
        if(!ModelState.IsValid)
        {
            var editCustomerViewModel = new EditCustomerViewModel
            {
                EditCustomerDTO = editCustomerDTO,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("Edit", editCustomerViewModel);
        }

        var customerInDB = _context.Customer.Single(c => c.Id == editCustomerDTO.Id);
        customerInDB.Name = editCustomerDTO.Name;
        customerInDB.Email = editCustomerDTO.Email;
        customerInDB.Birthday = editCustomerDTO.Birthday;
        customerInDB.MembershipTypeId = editCustomerDTO.MembershipTypeId;

        _context.SaveChanges();

        return RedirectToAction("Index", "Customer");
    }
}