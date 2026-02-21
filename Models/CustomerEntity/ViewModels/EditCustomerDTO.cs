namespace ASP.NET_Web.Models.CustomerEntity;

public class EditCustomerDTO
{
    public int Id {get; set;}
    required public string Name {get; set;}
    required public string Email {get; set;}
    public DateOnly Birthday {get; set;}
    public int MembershipTypeId {get; set;}

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