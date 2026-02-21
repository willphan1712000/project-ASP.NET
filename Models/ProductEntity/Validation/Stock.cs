using System.ComponentModel.DataAnnotations;

namespace APS.NET_Web.Models.ProductEntity.Validation;

public class Stock : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var stock = (int) value!;
        if(stock < 1 || stock > 30)
        {
            return new ValidationResult("Stock should be between 1 and 30 inclusively.");
        }
        
        return ValidationResult.Success;
    }
}