namespace ASP.NET_Web.Models.CustomerEntity;

public class CreateCustomerDTO
{
    required public string Name {get; set;}
    required public string Email {get; set;}
    required public string Password {get; set;}
    public DateOnly Birthday {get; set;}
    public int MembershipTypeId {get; set;}

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