using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.CustomerEntity.dto;
using ASP.NET_Web.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(IMapper mapper, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet] // GET /api/customers
    public IEnumerable<EditCustomerDTO> GetCustomers()
    {
        return _unitOfWork.Customer.GetAll().Select(_mapper.Map<EditCustomerDTO>);
    }

    [HttpGet("{id}")] // GET /api/customer/1
    public ActionResult<EditCustomerDTO> GetCustomer(int id)
    {
        var customer = _unitOfWork.Customer.Get(id);

        if (customer == null)
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
        _unitOfWork.Customer.Add(customer);
        _unitOfWork.Save();

        return Created($"{new Uri(Request.GetDisplayUrl())}/{customer.Id}", _mapper.Map<EditCustomerDTO>(customer));
    }

    [HttpPut("{id}")] // PUT /api/customers/1 + json body
    public ActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var customerInDB = _unitOfWork.Customer.Get(id);

        if(customerInDB == null)
        {
            return NotFound();
        }

        _mapper.Map(customerDTO, customerInDB);
        _unitOfWork.Save();

        return Ok();
    }

    [HttpDelete("{id}")] // DELETE /api/customers/1
    public ActionResult DeleteCustomer(int id)
    {
        var customerInDB = _unitOfWork.Customer.Get(id);;

        if(customerInDB == null)
        {
            return NotFound();
        }

        _unitOfWork.Customer.Remove(customerInDB);
        _unitOfWork.Save();
        
        return NoContent();
    }
}