using AutoMapper;

namespace ASP.NET_Web.Models.CustomerEntity.dto;

public class CustomerProfile: Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, EditCustomerDTO>();
        CreateMap<CreateCustomerDTO, Customer>();
        CreateMap<CustomerDTO, Customer>();
        CreateMap<EditCustomerDTO, CustomerDTO>();
    }
}