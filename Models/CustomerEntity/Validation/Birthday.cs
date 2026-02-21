using System.ComponentModel.DataAnnotations;
using APS.NET_Web.Models.CustomerEntity.dto;
using ASP.NET_Web.Models.MembershipTypeEntity;

namespace ASP.NET_Web.Models.CustomerEntity.Validation;

public class BirthdayValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var customer = (CustomerDTO) validationContext.ObjectInstance;

        if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsyouGo)
            return ValidationResult.Success;

        if(customer.Birthday == DateOnly.MinValue)
            return new ValidationResult("Birthday is required");

        int age = DateOnly.FromDateTime(DateTime.Now).Year - customer.Birthday.Year;

        if(age < 18)
            return new ValidationResult("Customer is required to be at least 18 years old to use this type of membership");

        return ValidationResult.Success;
    }
}