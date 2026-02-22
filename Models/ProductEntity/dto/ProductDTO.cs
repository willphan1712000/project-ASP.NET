using APS.NET_Web.Models.ProductEntity.Validation;

namespace ASP.NET_Web.Models.ProductEntity.dto;

public class ProductDTO
{
    required public string Name {get; set;}
    public float Price {get; set;}

    [Stock]
    public int Stock {get; set;}
}