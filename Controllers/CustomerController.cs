using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.CustomerEntity.dto;
using ASP.NET_Web.Models.CustomerEntity.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers;

public class CustomerController(IMapper mapper) : Controller
{
    private AspNetWebContext _context = new();
    private IMapper _mapper = mapper;
    
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

    [NonAction]
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
                MembershipTypes = [.. _context.MembershipType]
            };

            return View("New", modelView);
        }

        _context.Customer.Add(_mapper.Map<Customer>(createCustomerDTO));
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
            EditCustomerDTO = _mapper.Map<EditCustomerDTO>(customer),
            MembershipTypes = [.. _context.MembershipType]
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
                MembershipTypes = [.. _context.MembershipType]
            };

            return View("Edit", editCustomerViewModel);
        }

        var customerInDB = _context.Customer.Single(c => c.Id == editCustomerDTO.Id);
        _mapper.Map(
            _mapper.Map<CustomerDTO>(editCustomerDTO),
            customerInDB
        );

        _context.SaveChanges();

        return RedirectToAction("Index", "Customer");
    }
}