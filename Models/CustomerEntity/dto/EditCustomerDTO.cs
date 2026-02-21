
using APS.NET_Web.Models.CustomerEntity.dto;

namespace ASP.NET_Web.Models.CustomerEntity.dto;

public class EditCustomerDTO : CustomerDTO
{
    public int Id {get; set;}
    
    public static EditCustomerDTO ToDTO(Customer customer)
    {
        return new EditCustomerDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Birthday = customer.Birthday,
            MembershipTypeId = customer.MembershipTypeId
        };
    }
}