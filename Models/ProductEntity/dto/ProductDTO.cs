using APS.NET_Web.Models.ProductEntity.Validation;

namespace ASP.NET_Web.Models.ProductEntity.dto;

public class ProductDTO
{
    required public string Name {get; set;}
    public float Price {get; set;}

    [Stock]
    public int Stock {get; set;}

    public static Product ToEntity(ProductDTO productDTO)
    {
        return new Product
        {
            Name = productDTO.Name,
            Price = productDTO.Price,
            Stock = productDTO.Stock
        };
    }
}