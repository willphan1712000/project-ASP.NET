using System.Net;
using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.CustomerEntity.dto;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly AspNetWebContext _context;

    public CustomersController()
    {
        _context = new AspNetWebContext();
    }

    protected void Dispose()
    {
        _context.Dispose();
    }

    [HttpGet] // GET /api/customers
    public IEnumerable<Customer> GetCustomers()
    {
        return [.. _context.Customer];
    }

    [HttpGet("{id}")] // GET /api/customer/1
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

        if(customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(CreateCustomerDTO customer)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest("Invalid customer information.");
        }

        _context.Customer.Add(CreateCustomerDTO.ToEntity(customer));
        _context.SaveChanges();

        return Created(string.Empty, customer);
    }

    [HttpPut("{id}")] // PUT /api/customers/1 + json body
    public ActionResult UpdateCustomer(int id, EditCustomerDTO customer)
    {
        var customerInDB = _context.Customer.SingleOrDefault(c => c.Id == id);

        if(customerInDB == null)
        {
            return NotFound();
        }

        customerInDB.Name = customer.Name;
        customerInDB.Email = customer.Email;
        customerInDB.Birthday = customer.Birthday;
        customerInDB.MembershipTypeId = customer.MembershipTypeId;

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")] // DELETE /api/customers/1
    public ActionResult DeleteCustomer(int id)
    {
        var customerInDB = _context.Customer.SingleOrDefault(c => c.Id == id);

        if(customerInDB == null)
        {
            return NotFound();
        }

        _context.Customer.Remove(customerInDB);
        _context.SaveChanges();
        
        return NoContent();
    }
}