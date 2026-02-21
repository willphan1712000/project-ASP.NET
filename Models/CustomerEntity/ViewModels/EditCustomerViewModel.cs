using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.MembershipTypeEntity;

namespace ASP.NET_Web.ViewModels;

public class EditCustomerViewModel
{
    public EditCustomerDTO? EditCustomerDTO {get; set;}
    public IEnumerable<MembershipType>? MembershipTypes {get; set;}
}