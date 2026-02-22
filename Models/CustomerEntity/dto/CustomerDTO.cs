using System.ComponentModel.DataAnnotations;
using ASP.NET_Web.Models.CustomerEntity.Validation;

namespace ASP.NET_Web.Models.CustomerEntity.dto;

public class CustomerDTO
{
    [Required(ErrorMessage = "Please provide a name")]
    [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} characters.", MinimumLength = 5)]
    required public string Name {get; set;}
    required public string Email {get; set;}

    [BirthdayValidation]
    public DateOnly Birthday {get; set;}
    public int MembershipTypeId {get; set;}
}