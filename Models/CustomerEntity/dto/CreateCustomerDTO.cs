using System.ComponentModel.DataAnnotations;
using APS.NET_Web.Models.CustomerEntity.dto;
using ASP.NET_Web.Models.CustomerEntity.Validation;

namespace ASP.NET_Web.Models.CustomerEntity.dto;

public class CreateCustomerDTO : CustomerDTO
{
    required public string Password {get; set;}

    public static Customer ToEntity(CreateCustomerDTO createCustomerDTO)
    {
        return new Customer
        {
            Name = createCustomerDTO.Name,
            Email = createCustomerDTO.Email,
            Birthday = createCustomerDTO.Birthday,
            Password = createCustomerDTO.Password,
            MembershipTypeId = createCustomerDTO.MembershipTypeId
        };
    }
}