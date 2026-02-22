using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.CustomerEntity.dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(IMapper mapper) : ControllerBase
{
    private readonly AspNetWebContext _context = new();
    private readonly IMapper _mapper = mapper;

    protected void Dispose()
    {
        _context.Dispose();
    }

    [HttpGet] // GET /api/customers
    public IEnumerable<EditCustomerDTO> GetCustomers()
    {
        return  _context.Customer.ToList().Select(_mapper.Map<EditCustomerDTO>);
    }

    [HttpGet("{id}")] // GET /api/customer/1
    public ActionResult<EditCustomerDTO> GetCustomer(int id)
    {
        var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

        if(customer == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EditCustomerDTO>(customer));
    }

    [HttpPost]
    public ActionResult<EditCustomerDTO> CreateCustomer(CreateCustomerDTO createCustomerDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var customer = _mapper.Map<Customer>(createCustomerDTO);
        _context.Customer.Add(customer);
        _context.SaveChanges();

        return Created(string.Empty, _mapper.Map<EditCustomerDTO>(customer));
    }

    [HttpPut("{id}")] // PUT /api/customers/1 + json body
    public ActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var customerInDB = _context.Customer.SingleOrDefault(c => c.Id == id);

        if(customerInDB == null)
        {
            return NotFound();
        }

        _mapper.Map(customerDTO, customerInDB);
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